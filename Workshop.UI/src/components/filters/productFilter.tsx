import { ProductFilters } from "../../services/api/stock";
import Form from "../form";

type ProductFilterProps = {
  onFilter: (values: ProductFilters) => void;
};
export default function ProductFilter(props: ProductFilterProps) {
  return (
    <Form initialValues={{} as ProductFilters} onSubmit={props.onFilter}>
      <Form.Input label="Nome" name="name" />
      <Form.Submit label="Filtrar" />
    </Form>
  );
}
