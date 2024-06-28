import {
  createFileRoute,
  Outlet,
  redirect,
  useNavigate,
} from "@tanstack/react-router";
import { useEffect } from "react";
import { useAuth } from "../contexts/authContext";

export const Route = createFileRoute("/_protected")({
  component: ProtectedLayout,
  beforeLoad: ({ context }) => {
    if (!context.auth.authed) {
      throw redirect({ to: "/login" });
    }
  },
});

function ProtectedLayout() {
  const navigate = useNavigate({ from: Route.fullPath });
  const { authed } = useAuth();

  useEffect(() => {
    if (!authed) {
      navigate({
        to: "/login",
      });
    }
  }, [authed, navigate]);

  return <Outlet />;
}
