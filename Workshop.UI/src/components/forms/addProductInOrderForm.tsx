import { number, object, string } from "yup";
import {
  useAddProductOrderMutation,
  useUpdateProductOrderMutation,
} from "../../services/mutations/order.mutations";
import { useProducts } from "../../services/queries/stock.queries";
import Form from "../form";

type AddProductInOrderFormProps = {
  orderId: string;
  productEdit?: { id: string; quantity: number };
  onSuccess: () => void;
};
export default function AddProductInOrderForm(
  props: AddProductInOrderFormProps
) {
  const productsQuery = useProducts();

  const addProductMutation = useAddProductOrderMutation({
    onSuccess: () => props.onSuccess(),
  });

  const updateProductMutation = useUpdateProductOrderMutation({
    onSuccess: () => props.onSuccess(),
  });

  return (
    <Form
      initialValues={{
        quantity: props.productEdit?.quantity || 0,
        productId: props.productEdit?.id || "",
      }}
      onSubmit={(data) => {
        if (props.productEdit) {
          updateProductMutation.mutate({
            orderId: props.orderId,
            productId: props.productEdit.id,
            quantity: data.quantity,
          });
          return;
        }

        addProductMutation.mutate({ ...data, orderId: props.orderId });
      }}
      validationSchema={object({
        productId: string()
          .required("Selecione um produto")
          .uuid("Selecione um produto"),
        quantity: number()
          .required("A quantidade é obrigatória")
          .min(0, "A quantidade tem que ser maior que 0"),
      })}
    >
      <Form.Select
        label="Produto"
        name="productId"
        options={
          productsQuery.data
            ?.filter((p) => p.quantityInStock > 0)
            .map((p) => {
              return {
                label: p.name,
                value: p.id,
              };
            }) || []
        }
        disabled={!!props.productEdit}
      />
      <Form.Input label="Quantidade" name="quantity" />
      <Form.Submit
        label={props.productEdit ? "Editar" : "Criar"}
        $loading={
          addProductMutation.isPending || updateProductMutation.isPending
        }
      />
    </Form>
  );
}
