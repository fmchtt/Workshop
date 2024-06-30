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
  ButtonWrapper,
  FlexibleContainer,
  IconButton,
  RouteContainer,
  SideContainer,
} from "../../../components/styles.global";
import { FaX } from "react-icons/fa6";
import FilledButton from "../../../components/filledbutton";
import { FaBoxes, FaFilter } from "react-icons/fa";
import ProductFilter from "../../../components/filters/productFilter";
import { Helmet } from "react-helmet";
import { ProductFilters } from "../../../services/api/stock";
import { toast } from "react-toastify";

export const Route = createLazyFileRoute("/_protected/stock/")({
  component: StockHome,
});

function StockHome() {
  const [productEdit, setProductEdit] = useState<Product | undefined>();
  const [productDelete, setProductDelete] = useState<Product | undefined>();
  const [form, setForm] = useState<"add" | "filter" | undefined>(undefined);
  const validatingPermission = usePermissions();
  const [filters, setFilters] = useState({} as ProductFilters);
  const { data } = useProducts({ filters });

  const deleteMutation = useDeleteProductMutation({
    onSuccess: () => {
      setProductDelete(undefined);
      toast.success("Produto removido!");
    },
  });

  if (validatingPermission([{ type: "stock", value: "manageProduct" }])) {
    return <PendingComponent />;
  }

  return (
    <RouteContainer $column>
      <Helmet>
        <title>Estoque</title>
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
            setProductEdit(undefined);
          }}
        >
          <FaBoxes />
          Adicionar produto
        </FilledButton>
      </ButtonWrapper>
      <RouteContainer>
        {form !== undefined && (
          <SideContainer>
            <IconButton $alignEnd>
              <FaX onClick={() => setForm(undefined)} />
            </IconButton>
            {form === "add" && (
              <ProductForm
                productEdit={productEdit}
                onClear={() => setProductEdit(undefined)}
                onSuccess={() => {
                  setProductEdit(undefined);
                  setFilters({});
                }}
              />
            )}
            {form === "filter" && (
              <ProductFilter
                onFilter={(values) => setFilters(values)}
                onClear={() => setFilters({})}
              />
            )}
          </SideContainer>
        )}
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
            onEdit={(data) => {
              setForm("add");
              setProductEdit(data);
            }}
          />
        </FlexibleContainer>
        <ConfirmationModal
          title="Deletar produto"
          text={`Tem certeza que deseja apagar o produto ${productDelete?.name} ?`}
          onSuccess={() => {
            productDelete && deleteMutation.mutate(productDelete.id);
            setFilters({});
          }}
          onClose={() => {
            setProductDelete(undefined);
          }}
          show={!!productDelete}
        />
      </RouteContainer>
    </RouteContainer>
  );
}
