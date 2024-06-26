import Form from "../form";

export default function ClientForm() {
  return (
    <Form
      initialValues={{
        name: "",
      }}
      onSubmit={() => {}}
      title="Criar novo cliente"
    >
      <Form.Input label="Nome" name="name" />
      <Form.Submit label="Criar" />
    </Form>
  );
}
