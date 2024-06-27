import { createLazyFileRoute } from "@tanstack/react-router";
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

export const Route = createLazyFileRoute("/_protected/order/$orderId")({
  component: OrderView,
});

function OrderView() {
  const params = Route.useParams();
  const { data } = useOrder(params.orderId);

  return (
    <OrderContainer>
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
        </InformationContainer>
        <Text $weight="bold" $size="md">
          Produtos utilizados:
        </Text>
        <Table
          rows={
            data?.products.map((p) => {
              return { ...p.product, quantity: p.quantity };
            }) || []
          }
          columns={[
            { key: "name", title: "Nome" },
            {
              key: "price",
              title: "Preço",
              parser: (data) => `R$ ${data.toFixed(2)}`,
            },
            { key: "quantity", title: "Quantidade" },
          ]}
          showDelete
          onDelete={(data) => console.log(data)}
          showEdit
          onEdit={(data) => console.log(data)}
        />
        <FooterContainer>
          {data?.complete ? (
            <Text $margin="15px 0" $weight="bold">
              Ordem de serviço concluida!
            </Text>
          ) : (
            <FilledButton>Concluir</FilledButton>
          )}
        </FooterContainer>
      </TableContainer>
    </OrderContainer>
  );
}
