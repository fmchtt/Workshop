import { createLazyFileRoute } from "@tanstack/react-router";
import { OrderContainer } from "../../../components/pages/order.style";
import {
  FormContainer,
  TableContainer,
} from "../../../components/pages/stock.styles";
import { Table } from "../../../components/table";
import { useOrders } from "../../../services/queries/order.queries";
import OrderForm from "../../../components/forms/orderForm";
import { useState } from "react";
import { Order } from "../../../types/entities/order";
import ConfirmationModal from "../../../components/confirmationModal";
import { useDeleteOrderMutation } from "../../../services/mutations/order.mutations";

export const Route = createLazyFileRoute("/_protected/order/")({
  component: OrderHome,
});

function OrderHome() {
  const [orderEdit, setOrderEdit] = useState<Order | undefined>();
  const [orderDelete, setOrderDelete] = useState<Order | undefined>();
  const { data } = useOrders();

  const deleteMutation = useDeleteOrderMutation({
    onSuccess: () => setOrderDelete(undefined),
  });

  return (
    <OrderContainer>
      <FormContainer>
        <OrderForm
          orderEdit={orderEdit}
          onClear={() => setOrderEdit(undefined)}
        />
      </FormContainer>
      <TableContainer>
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
          onEdit={(data) => setOrderEdit(data)}
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
          onSuccess={() => orderDelete && deleteMutation.mutate(orderDelete.id)}
          onClose={() => setOrderDelete(undefined)}
          show={!!orderDelete}
          $loading={deleteMutation.isPending}
        />
      </TableContainer>
    </OrderContainer>
  );
}
