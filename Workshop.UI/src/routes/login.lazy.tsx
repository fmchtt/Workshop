import { createLazyFileRoute, Link, useNavigate } from "@tanstack/react-router";
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
import { Helmet } from "react-helmet";

export const Route = createLazyFileRoute("/login")({
  component: Login,
});

function Login() {
  const { authed } = useAuth();
  const navigate = useNavigate();

  useEffect(() => {
    if (authed) {
      navigate({ to: "/home" });
    }
  }, [authed, navigate]);

  return (
    <RouteContainer>
      <Helmet>
        <title>Entrar</title>
      </Helmet>
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
