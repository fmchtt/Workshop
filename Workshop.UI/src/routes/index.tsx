import { createFileRoute, redirect } from "@tanstack/react-router";

export const Route = createFileRoute("/")({
  component: () => <></>,
  beforeLoad: ({ context }) => {
    if (!context.auth.user) {
      throw redirect({ to: "/login" });
    } else {
      throw redirect({ to: "/home" });
    }
  },
});
