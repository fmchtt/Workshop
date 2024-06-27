import {
  createFileRoute,
  Link,
  redirect,
  useNavigate,
} from "@tanstack/react-router";
import RegisterForm from "../components/forms/register";
import { Text } from "../components/styles.global";
import { FormContainer } from "../components/pages/stock.styles";
import { useEffect } from "react";
import { useAuth } from "../contexts/authContext";
import { LoginContainer, SideContainer } from "../components/pages/login.style";
import WorkshopImage from "../assets/images/bicicle-workshop.png";

export const Route = createFileRoute("/register")({
  component: Register,
  beforeLoad: ({ context }) => {
    if (context.auth.user) {
      throw redirect({ to: "/home" });
    }
  },
});

function Register() {
  const { user } = useAuth();
  const navigate = useNavigate({ from: Route.fullPath });

  useEffect(() => {
    if (user) {
      navigate({ to: "/home" });
    }
  }, [user, navigate]);

  return (
    <LoginContainer>
      <FormContainer>
        <RegisterForm />
        <Text $margin="8px">
          Já possui conta ?{" "}
          <Text as={Link} to="/login" $weight="bold">
            Entrar
          </Text>
        </Text>
      </FormContainer>
      <SideContainer>
        <Text $size="xl" $weight="bold">
          Bem vindo ao Workshop
        </Text>
        <img src={WorkshopImage} />
      </SideContainer>
    </LoginContainer>
  );
}
