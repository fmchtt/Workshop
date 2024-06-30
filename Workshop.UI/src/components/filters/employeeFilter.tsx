import { EmployeeFilters } from "../../services/api/company";
import { FilterProps } from "../../types/utils/filter";
import Form from "../form";

export default function EmployeeFilter(props: FilterProps<EmployeeFilters>) {
  return (
    <Form
      initialValues={{} as EmployeeFilters}
      onSubmit={props.onFilter}
      onReset={props.onClear}
    >
      <Form.Input label="Nome" name="name" />
      <Form.Input label="Email" name="email" type="email" />
      <Form.Submit label="Filtrar" />
      <Form.Clear label="Limpar" />
    </Form>
  );
}
