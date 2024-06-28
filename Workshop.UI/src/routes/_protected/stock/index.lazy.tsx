import { createLazyFileRoute } from "@tanstack/react-router";
import ProductForm from "../../../components/forms/productForm";
import { Table } from "../../../components/table";
import { useProducts } from "../../../services/queries/stock.queries";
import { useState } from "react";
import { Product } from "../../../types/entities/product";
import ConfirmationModal from "../../../components/confirmationModal";
import { useDeleteProductMutation } from "../../../services/mutations/product.mutations";
import usePermissions from "../../../hooks/usePermissions";
import PendingComponent from "../../../components/pendingComponent";
import {
  FlexibleContainer,
  RouteContainer,
  SideContainer,
} from "../../../components/styles.global";

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
    <RouteContainer>
      <SideContainer>
        <ProductForm
          productEdit={productEdit}
          onClear={() => setProductEdit(undefined)}
        />
      </SideContainer>
      <FlexibleContainer>
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
      </FlexibleContainer>
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
    </RouteContainer>
  );
}
