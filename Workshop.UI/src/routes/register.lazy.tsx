import { createLazyFileRoute, Link, useNavigate } from "@tanstack/react-router";
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
import { Helmet } from "react-helmet";

export const Route = createLazyFileRoute("/register")({
  component: Register,
});

function Register() {
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
        <title>Registrar</title>
      </Helmet>
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
