import { createFileRoute } from "@tanstack/react-router";
import {
  StockContainer,
  FormContainer,
  TableContainer,
} from "../../../components/pages/stock.styles";
import ProductForm from "../../../components/forms/productForm";
import { Table } from "../../../components/table";
import { useProducts } from "../../../services/queries/stock.queries";

export const Route = createFileRoute("/_protected/stock/")({
  component: StockHome,
});

function StockHome() {
  const { data } = useProducts();

  return (
    <StockContainer>
      <FormContainer>
        <ProductForm />
      </FormContainer>
      <TableContainer>
        <Table
          rows={data || []}
          columns={[
            { key: "name", title: "Nome" },
            {
              key: "price",
              title: "Preço",
              parser: (data) => `R$ ${data.toFixed(2)}`,
            },
            { key: "quantityInStock", title: "Quantidade" },
          ]}
          showDelete
          onDelete={(data) => console.log(data)}
          showEdit
          onEdit={(data) => console.log(data)}
        />
      </TableContainer>
    </StockContainer>
  );
}
