import { EmployeeFilters } from "../../services/api/company";
import Form from "../form";

type EmployeeFilterProps = {
  onFilter: (values: EmployeeFilters) => void;
};
export default function EmployeeFilter(props: EmployeeFilterProps) {
  return (
    <Form initialValues={{} as EmployeeFilters} onSubmit={props.onFilter}>
      <Form.Input label="Nome" name="name" />
      <Form.Input label="Email" name="email" type="email" />
      <Form.Submit label="Filtrar" />
    </Form>
  );
}
