import Form from "../form";

type ClientFilters = {
  name?: string;
};
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
