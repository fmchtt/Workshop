import { createLazyFileRoute } from "@tanstack/react-router";

export const Route = createLazyFileRoute("/_protected/management/roles")({
  component: () => <div>Hello /_protected/management/roles!</div>,
});
