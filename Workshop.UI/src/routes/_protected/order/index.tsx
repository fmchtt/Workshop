import { createFileRoute } from "@tanstack/react-router";
import { OrderContainer } from "../../../components/pages/order.style";
import {
  FormContainer,
  TableContainer,
} from "../../../components/pages/stock.styles";
import { Table } from "../../../components/table";
import { useOrders } from "../../../services/queries/order.queries";
import OrderForm from "../../../components/forms/orderForm";

export const Route = createFileRoute("/_protected/order/")({
  component: OrderHome,
});

function OrderHome() {
  const { data } = useOrders();

  return (
    <OrderContainer>
      <FormContainer>
        <OrderForm />
      </FormContainer>
      <TableContainer>
        <Table
          rows={data || []}
          columns={[
            { key: "orderNumber", title: "Número" },
            { key: "client", title: "Cliente", parser: (data) => data.name },
            {
              key: "employee",
              title: "Mecânico",
              parser: (data) => data.user.name,
            },
            {
              key: "products",
              title: "Quantidade de produtos",
              parser: (data) => data.length,
            },
          ]}
          showDelete
          onDelete={(data) => console.log(data)}
          showEdit
          onEdit={(data) => console.log(data)}
        />
      </TableContainer>
    </OrderContainer>
  );
}
