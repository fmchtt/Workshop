import { ProductFilters } from "../../services/api/stock";
import { FilterProps } from "../../types/utils/filter";
import Form from "../form";

export default function ProductFilter(props: FilterProps<ProductFilters>) {
  return (
    <Form
      initialValues={{} as ProductFilters}
      onSubmit={props.onFilter}
      onReset={props.onClear}
    >
      <Form.Input label="Nome" name="name" />
      <Form.Submit label="Filtrar" />
      <Form.Clear label="Limpar" />
    </Form>
  );
}
