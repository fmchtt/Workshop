import { createLazyFileRoute, useNavigate } from "@tanstack/react-router";
import { useOrder } from "../../../services/queries/order.queries";
import {
  FooterContainer,
  InformationContainer,
  OrderContainer,
} from "../../../components/pages/order.style";
import { TableContainer } from "../../../components/pages/stock.styles";
import { Table } from "../../../components/table";
import { Detail, Text } from "../../../components/styles.global";
import FilledButton from "../../../components/filledbutton";
import { useState } from "react";
import Modal from "../../../components/modal";
import AddProductInOrderForm from "../../../components/forms/addProductInOrderForm";
import ConfirmationModal from "../../../components/confirmationModal";
import {
  useConcludeOrderMutation,
  useDeleteOrderMutation,
} from "../../../services/mutations/order.mutations";

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

  const concludeMutation = useConcludeOrderMutation({
    onSuccess: () => setShowConclusion(false),
  });
  const deleteMutation = useDeleteOrderMutation({
    onSuccess: () => {
      navigate({
        to: "/order",
      });
    },
  });

  return (
    <OrderContainer $column>
      <TableContainer>
        <Text $weight="bold" $size="md">
          Dados da ordem de serviço:
        </Text>
        <InformationContainer>
          <Text $weight="semibold">
            Código: <Detail>{data?.orderNumber}</Detail>
          </Text>
          <Text $weight="semibold">
            Total do serviço:{" "}
            <Detail>
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
          showDelete
          onDelete={(data) => console.log(data)}
          showEdit
          onEdit={(data) => console.log(data)}
        />
        <FooterContainer>
          {!data?.complete && (
            <FilledButton onClick={() => setShowCreateForm(true)}>
              Adicionar produto
            </FilledButton>
          )}
        </FooterContainer>
      </TableContainer>
      <FooterContainer>
        {data?.complete ? (
          <>
            <FilledButton $margin="0" onClick={() => print()}>
              Imprimir
            </FilledButton>
          </>
        ) : (
          <>
            <FilledButton $margin="0" onClick={() => setShowConclusion(true)}>
              Concluir
            </FilledButton>
            <FilledButton
              $margin="0"
              $color="light"
              onClick={() => setShowDelete(true)}
            >
              Excluir
            </FilledButton>
          </>
        )}
      </FooterContainer>
      <Modal show={showCreateForm} onClose={() => setShowCreateForm(false)}>
        <AddProductInOrderForm
          orderId={params.orderId}
          onSuccess={() => setShowCreateForm(false)}
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
    </OrderContainer>
  );
}
