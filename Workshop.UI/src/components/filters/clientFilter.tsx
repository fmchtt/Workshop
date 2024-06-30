import { ClientFilters } from "../../services/api/client";
import { FilterProps } from "../../types/utils/filter";
import Form from "../form";

export default function ClientFilter(props: FilterProps<ClientFilters>) {
  return (
    <Form
      initialValues={{} as ClientFilters}
      onSubmit={props.onFilter}
      onReset={props.onClear}
    >
      <Form.Input label="Nome" name="name" />
      <Form.Submit label="Filtrar" />
      <Form.Clear label="Limpar" />
    </Form>
  );
}
