import { createFileRoute, redirect, useNavigate } from "@tanstack/react-router";
import {
  Container as LoginContainer,
  FormContainer,
} from "../components/pages/login.styles";
import LoginForm from "../components/forms/login";
import Header from "../components/header";
import { useAuth } from "../contexts/authContext";
import { useEffect, useState } from "react";
import RegisterForm from "../components/forms/register";
import { Text } from "../components/styles.global";

export const Route = createFileRoute("/login")({
  component: Login,
  beforeLoad: ({ context }) => {
    if (context.auth.user) {
      throw redirect({ to: "/home" });
    }
  },
});

function Login() {
  const { user } = useAuth();
  const navigate = useNavigate({ from: Route.fullPath });
  const [isLogin, setLogin] = useState(true);

  useEffect(() => {
    if (user) {
      navigate({ to: "/home" });
    }
  }, [user, navigate]);

  return (
    <>
      <Header />
      <LoginContainer>
        <FormContainer>
          {isLogin ? (
            <>
              <LoginForm />
              <Text>
                Não possui conta ?{" "}
                <Text as="a" $weight="bold" onClick={() => setLogin((x) => !x)}>
                  Registrar
                </Text>
              </Text>
            </>
          ) : (
            <>
              <RegisterForm />
              <Text>
                Já possui conta ?{" "}
                <Text as="a" $weight="bold" onClick={() => setLogin((x) => !x)}>
                  Entrar
                </Text>
              </Text>
            </>
          )}
        </FormContainer>
      </LoginContainer>
    </>
  );
}
