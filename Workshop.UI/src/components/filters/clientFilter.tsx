import { ClientFilters } from "../../services/api/client";
import Form from "../form";

type ClientFilterProps = {
  onFilter: (values: ClientFilters) => void;
};
export default function ClientFilter(props: ClientFilterProps) {
  return (
    <Form initialValues={{} as ClientFilters} onSubmit={props.onFilter}>
      <Form.Input label="Nome" name="name" />
      <Form.Submit label="Filtrar" />
    </Form>
  );
}
