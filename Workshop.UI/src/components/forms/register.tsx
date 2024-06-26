import { useAuth } from "../../contexts/authContext";
import Form from "../form";

export default function RegisterForm() {
  const { register } = useAuth();

  return (
    <Form
      initialValues={{ email: "", password: "", name: "" }}
      title="Registrar"
      onSubmit={(values) => register.mutate(values)}
    >
      <Form.Input label="Nome" name="name" />
      <Form.Input label="Email" name="email" />
      <Form.Password label="Senha" name="password" />
      <Form.Submit label="Entrar" $loading={register.isPending} />
    </Form>
  );
}
