import { createLazyFileRoute } from "@tanstack/react-router";
import {
  StockContainer,
  FormContainer,
  TableContainer,
} from "../../../components/pages/stock.styles";
import ProductForm from "../../../components/forms/productForm";
import { Table } from "../../../components/table";
import { useProducts } from "../../../services/queries/stock.queries";
import { useState } from "react";
import { Product } from "../../../types/entities/product";
import ConfirmationModal from "../../../components/confirmationModal";
import { useDeleteProductMutation } from "../../../services/mutations/product.mutations";
import usePermissions from "../../../hooks/usePermissions";
import PendingComponent from "../../../components/pendingComponent";

export const Route = createLazyFileRoute("/_protected/stock/")({
  component: StockHome,
});

function StockHome() {
  const [productEdit, setProductEdit] = useState<Product | undefined>();
  const [productDelete, setProductDelete] = useState<Product | undefined>();
  const validatingPermission = usePermissions();
  const { data } = useProducts();

  const deleteMutation = useDeleteProductMutation({
    onSuccess: () => setProductDelete(undefined),
  });

  if (validatingPermission([{ type: "stock", value: "manageProduct" }])) {
    return <PendingComponent />;
  }

  return (
    <StockContainer>
      <FormContainer>
        <ProductForm
          productEdit={productEdit}
          onClear={() => setProductEdit(undefined)}
        />
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
          onDelete={(data) => setProductDelete(data)}
          showEdit
          onEdit={(data) => setProductEdit(data)}
        />
      </TableContainer>
      <ConfirmationModal
        title="Deletar produto"
        text={`Tem certeza que deseja apagar o produto ${productDelete?.name} ?`}
        onSuccess={() => {
          productDelete && deleteMutation.mutate(productDelete.id);
        }}
        onClose={() => {
          setProductDelete(undefined);
        }}
        show={!!productDelete}
      />
    </StockContainer>
  );
}
