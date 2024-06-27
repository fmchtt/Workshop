import { useAddProductOrderMutation } from "../../services/mutations/order.mutations";
import { useProducts } from "../../services/queries/stock.queries";
import Form from "../form";

type AddProductInOrderFormProps = {
  orderId: string;
  onSuccess: () => void;
};
export default function AddProductInOrderForm(
  props: AddProductInOrderFormProps
) {
  const productsQuery = useProducts();

  const addProductMutation = useAddProductOrderMutation({
    onSuccess: () => props.onSuccess(),
  });

  return (
    <Form
      initialValues={{
        quantity: 0,
        productId: "",
      }}
      onSubmit={(data) => {
        addProductMutation.mutate({ ...data, orderId: props.orderId });
      }}
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
      />
      <Form.Input label="Quantidade" name="quantity" />
      <Form.Submit label="Criar" $loading={addProductMutation.isPending} />
    </Form>
  );
}
