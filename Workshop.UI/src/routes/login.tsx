import {
  createFileRoute,
  Link,
  redirect,
  useNavigate,
} from "@tanstack/react-router";
import LoginForm from "../components/forms/login";
import { useAuth } from "../contexts/authContext";
import { useEffect } from "react";
import {
  RouteContainer,
  SideContainer,
  Text,
} from "../components/styles.global";
import { LoginSideContainer } from "../components/pages/login.style";
import WorkshopImage from "../assets/images/bicicle-workshop.png";

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

  useEffect(() => {
    if (user) {
      navigate({ to: "/home" });
    }
  }, [user, navigate]);

  return (
    <RouteContainer>
      <SideContainer>
        <LoginForm />
        <Text $margin="8px">
          Não possui conta ?{" "}
          <Text as={Link} to="/register" $weight="bold">
            Registrar
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
