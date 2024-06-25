import { createFileRoute, redirect, useNavigate } from "@tanstack/react-router";
import {
  Container as LoginContainer,
  FormContainer,
} from "../components/pages/login.styles";
import LoginForm from "../components/forms/login";
import Header from "../components/header";
import { useAuth } from "../contexts/authContext";
import { useEffect } from "react";

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
    <>
      <Header />
      <LoginContainer>
        <FormContainer>
          <LoginForm />
        </FormContainer>
      </LoginContainer>
    </>
  );
}
