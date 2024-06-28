import {
  createFileRoute,
  Link,
  redirect,
  useNavigate,
} from "@tanstack/react-router";
import RegisterForm from "../components/forms/register";
import {
  RouteContainer,
  SideContainer,
  Text,
} from "../components/styles.global";
import { useEffect } from "react";
import { useAuth } from "../contexts/authContext";
import { LoginSideContainer } from "../components/pages/login.style";
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
    <RouteContainer>
      <SideContainer>
        <RegisterForm />
        <Text $margin="8px">
          Já possui conta ?{" "}
          <Text as={Link} to="/login" $weight="bold">
            Entrar
          </Text>
        </Text>
      </SideContainer>
      <LoginSideContainer>
        <Text $size="xl" $weight="bold">
          Bem vindo ao Workshop
        </Text>
        <img src={WorkshopImage} />
      </LoginSideContainer>
    </RouteContainer>
  );
}
