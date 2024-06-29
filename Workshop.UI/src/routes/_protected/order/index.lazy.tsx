import { createLazyFileRoute } from "@tanstack/react-router";
import { Table } from "../../../components/table";
import { useOrders } from "../../../services/queries/order.queries";
import OrderForm from "../../../components/forms/orderForm";
import { useState } from "react";
import { Order } from "../../../types/entities/order";
import ConfirmationModal from "../../../components/confirmationModal";
import { useDeleteOrderMutation } from "../../../services/mutations/order.mutations";
import usePermissions from "../../../hooks/usePermissions";
import PendingComponent from "../../../components/pendingComponent";
import {
  ButtonWrapper,
  FlexibleContainer,
  IconButton,
  RouteContainer,
  SideContainer,
} from "../../../components/styles.global";
import FilledButton from "../../../components/filledbutton";
import { FaX } from "react-icons/fa6";
import { FaFileContract, FaFilter } from "react-icons/fa";
import OrderFilter from "../../../components/filters/orderFilter";
import { Helmet } from "react-helmet";
import { OrderFilters } from "../../../services/api/order";

export const Route = createLazyFileRoute("/_protected/order/")({
  component: OrderHome,
});

function OrderHome() {
  const [orderEdit, setOrderEdit] = useState<Order | undefined>();
  const [orderDelete, setOrderDelete] = useState<Order | undefined>();
  const validatingPermission = usePermissions();
  const [form, setForm] = useState<"add" | "filter" | undefined>(undefined);
  const [filters, setFilters] = useState({} as OrderFilters);
  const { data } = useOrders({ filters });

  const deleteMutation = useDeleteOrderMutation({
    onSuccess: () => setOrderDelete(undefined),
  });

  if (validatingPermission([{ type: "service", value: "manageOrder" }])) {
    return <PendingComponent />;
  }

  return (
    <RouteContainer $column>
      <Helmet>
        <title>Serviços</title>
      </Helmet>
      <ButtonWrapper>
        <FilledButton
          disabled={form === "filter"}
          $margin="0"
          onClick={() => setForm("filter")}
        >
          <FaFilter />
          Filtros
        </FilledButton>
        <FilledButton
          disabled={form === "add"}
          $margin="0"
          onClick={() => {
            setForm("add");
            setOrderEdit(undefined);
          }}
        >
          <FaFileContract />
          Adicionar order de serviço
        </FilledButton>
      </ButtonWrapper>
      <RouteContainer>
        {form !== undefined && (
          <SideContainer>
            <IconButton $alignEnd>
              <FaX onClick={() => setForm(undefined)} />
            </IconButton>
            {form === "add" && (
              <OrderForm
                orderEdit={orderEdit}
                onClear={() => setOrderEdit(undefined)}
              />
            )}
            {form === "filter" && (
              <OrderFilter onFilter={(value) => setFilters(value)} />
            )}
          </SideContainer>
        )}
        <FlexibleContainer>
          <Table
            rows={data || []}
            columns={[
              { key: "orderNumber", title: "Número" },
              { key: "client", title: "Cliente", parser: (data) => data.name },
              {
                key: "employee",
                title: "Colaborador",
                parser: (data) => data.user.name,
              },
              {
                key: "products",
                title: "Quantidade de produtos",
                parser: (data) => data.length,
              },
              {
                key: "products",
                title: "Total",
                parser: (data) =>
                  `R$ ${data.reduce((prev, actual) => prev + actual.product.price * actual.quantity, 0).toFixed(2)}`,
              },
              {
                key: "complete",
                title: "Situação",
                parser: (data) => (data == true ? "Concluída" : "Aberta"),
              },
            ]}
            showDelete={(data) => !data.complete}
            onDelete={(data) => setOrderDelete(data)}
            showEdit={(data) => !data.complete}
            onEdit={(data) => {
              setForm("add");
              setOrderEdit(data);
            }}
            link={(p) => {
              return {
                to: "/order/$orderId",
                params: {
                  orderId: p.id,
                },
              };
            }}
          />
          <ConfirmationModal
            title="Deletar ordem de serviço"
            text={`Tem certeza que deseja apagar a ordem de serviço ${orderDelete?.orderNumber} ?`}
            onSuccess={() =>
              orderDelete && deleteMutation.mutate(orderDelete.id)
            }
            onClose={() => setOrderDelete(undefined)}
            show={!!orderDelete}
            $loading={deleteMutation.isPending}
          />
        </FlexibleContainer>
      </RouteContainer>
    </RouteContainer>
  );
}
