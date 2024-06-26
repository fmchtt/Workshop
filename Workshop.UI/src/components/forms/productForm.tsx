import Form from "../form";

export default function ProductForm() {
  return (
    <Form
      initialValues={{
        name: "",
        description: "",
        price: 0,
        quantity: 0,
      }}
      onSubmit={() => {}}
      title="Criar novo produto"
    >
      <Form.Input label="Nome" name="name" />
      <Form.TextArea label="Descrição" name="description" />
      <Form.Input label="Preço" name="price" type="number" />
      <Form.Input label="Quantidade" name="quantity" type="number" />
      <Form.Submit label="Criar" />
    </Form>
  );
}
