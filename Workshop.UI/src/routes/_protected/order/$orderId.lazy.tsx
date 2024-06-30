import { createLazyFileRoute, useNavigate } from "@tanstack/react-router";
import { useOrder } from "../../../services/queries/order.queries";
import {
  FooterContainer,
  InformationContainer,
  TableFooter,
} from "../../../components/pages/order.style";
import { Table } from "../../../components/table";
import {
  Detail,
  FlexibleContainer,
  RouteContainer,
  Text,
} from "../../../components/styles.global";
import FilledButton from "../../../components/filledbutton";
import { useState } from "react";
import Modal from "../../../components/modal";
import ConfirmationModal from "../../../components/confirmationModal";
import {
  useConcludeOrderMutation,
  useDeleteOrderMutation,
  useDeleteProductOrderMutation,
} from "../../../services/mutations/order.mutations";
import AddProductInOrderForm from "../../../components/forms/addProductInOrderForm";
import PendingComponent from "../../../components/pendingComponent";
import usePermissions from "../../../hooks/usePermissions";
import { Helmet } from "react-helmet";
import { Product } from "../../../types/entities/product";
import { toast } from "react-toastify";

export const Route = createLazyFileRoute("/_protected/order/$orderId")({
  component: OrderView,
});

function OrderView() {
  const params = Route.useParams();
  const { data } = useOrder(params.orderId);
  const navigate = useNavigate();
  const [showCreateForm, setShowCreateForm] = useState(false);
  const [showConclusion, setShowConclusion] = useState(false);
  const [showDelete, setShowDelete] = useState(false);
  const validatingPermission = usePermissions();

  const [productDelete, setProductDelete] = useState<Product | undefined>();
  const deleteProductMutation = useDeleteProductOrderMutation({
    onSuccess: () => {
      toast.success("Produto removida da ordem de serviço!");
      setProductDelete(undefined);
    },
  });

  const [productEdit, setProductEdit] = useState<
    { id: string; quantity: number } | undefined
  >();

  const concludeMutation = useConcludeOrderMutation({
    onSuccess: () => {
      toast.success("Ordem de serviço concluída");
      setShowConclusion(false);
    },
  });
  const deleteMutation = useDeleteOrderMutation({
    onSuccess: () => {
      toast.success("Ordem de serviço removida!");
      navigate({
        to: "/order",
      });
    },
  });

  if (validatingPermission([{ type: "service", value: "manageOrder" }])) {
    return <PendingComponent />;
  }

  return (
    <RouteContainer $column>
      <Helmet>
        <title>Serviços - {data?.client.name || ""}</title>
      </Helmet>
      <FlexibleContainer>
        <Text $weight="bold" $size="md">
          Dados da ordem de serviço:
        </Text>
        <InformationContainer>
          <Text $weight="semibold">
            Código: <Detail>{data?.orderNumber}</Detail>
          </Text>
          <Text $weight="semibold">
            Colaborador: <Detail>{data?.employee.user.name}</Detail>
          </Text>
          <Text $weight="semibold">
            Cliente: <Detail>{data?.client.name}</Detail>
          </Text>
          <Text $weight="semibold">
            Situação: <Detail>{data?.complete ? "Concluída" : "Aberta"}</Detail>
          </Text>
        </InformationContainer>
        <Text $weight="bold" $size="md">
          Produtos utilizados:
        </Text>
        <Table
          rows={
            data?.products.map((p) => {
              return {
                ...p.product,
                quantity: p.quantity,
                subtotal: p.product.price * p.quantity,
              };
            }) || []
          }
          columns={[
            { key: "name", title: "Nome" },
            { key: "quantity", title: "Quantidade" },
            {
              key: "price",
              title: "Preço",
              parser: (data) => `R$ ${data.toFixed(2)}`,
            },
            {
              key: "subtotal",
              title: "Sub Total",
              parser: (data) => `R$ ${data.toFixed(2)}`,
            },
          ]}
          showDelete={!data?.complete}
          onDelete={(product) => setProductDelete(product)}
          showEdit={!data?.complete}
          onEdit={(product) => setProductEdit(product)}
        />
        <TableFooter>
          <Text $weight="semibold" $size="md">
            Total:{" "}
            <Detail $size="md">
              R${" "}
              {data?.products
                .reduce(
                  (prev, actual) =>
                    prev + actual.product.price * actual.quantity,
                  0
                )
                .toFixed(2)}
            </Detail>
          </Text>
        </TableFooter>
      </FlexibleContainer>
      <FooterContainer $justifyBetween>
        {data?.complete ? (
          <>
            <FilledButton
              $color="secondary"
              $margin="0"
              onClick={() => print()}
            >
              Imprimir
            </FilledButton>
          </>
        ) : (
          <>
            <div>
              <FilledButton
                $margin="0"
                $color="secondary"
                onClick={() => setShowCreateForm(true)}
              >
                Adicionar produto
              </FilledButton>
            </div>
            <FooterContainer>
              <FilledButton
                $margin="0"
                $color="secondary"
                onClick={() => setShowConclusion(true)}
              >
                Concluir
              </FilledButton>
              <FilledButton
                $margin="0"
                $color="danger"
                onClick={() => setShowDelete(true)}
              >
                Excluir
              </FilledButton>
            </FooterContainer>
          </>
        )}
      </FooterContainer>
      <Modal
        show={showCreateForm || !!productEdit}
        onClose={() => {
          setShowCreateForm(false);
          setProductEdit(undefined);
        }}
      >
        <AddProductInOrderForm
          orderId={params.orderId}
          onSuccess={() => {
            setShowCreateForm(false);
            setProductEdit(undefined);
          }}
          productEdit={productEdit}
        />
      </Modal>
      <ConfirmationModal
        show={showConclusion}
        text={`Tem certeza que deseja concluir a ordem de serviço código: ${data?.orderNumber} ?`}
        title="Concluir ordem de serviço"
        onClose={() => setShowConclusion(false)}
        onSuccess={() => concludeMutation.mutate(data?.id || "")}
      />
      <ConfirmationModal
        title="Deletar ordem de serviço"
        text={`Tem certeza que deseja apagar a ordem de serviço ${data?.orderNumber} ?`}
        onSuccess={() => deleteMutation.mutate(data?.id || "")}
        onClose={() => setShowDelete(false)}
        show={showDelete}
        $loading={deleteMutation.isPending}
      />
      <ConfirmationModal
        title="Deletar produto da ordem de serviço"
        text={`Tem certeza que deseja apagar o produto ${productDelete?.name} da ordem de serviço ${data?.orderNumber} ?`}
        onSuccess={() =>
          data?.id &&
          productDelete?.id &&
          deleteProductMutation.mutate({
            orderId: data.id,
            productId: productDelete.id,
          })
        }
        onClose={() => setProductDelete(undefined)}
        show={!!productDelete}
        $loading={deleteProductMutation.isPending}
      />
    </RouteContainer>
  );
}
