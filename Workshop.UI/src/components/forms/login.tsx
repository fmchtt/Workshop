import { useAuth } from "../../contexts/authContext";
import Form from "../form";

export default function LoginForm() {
  const { login } = useAuth();

  return (
    <Form
      initialValues={{ email: "", password: "" }}
      title="Entrar"
      onSubmit={(values) => login.mutate(values)}
    >
      <Form.Input label="Email" name="email" />
      <Form.Password label="Senha" name="password" />
      <Form.Submit label="Entrar" $loading={login.isPending} />
    </Form>
  );
}
