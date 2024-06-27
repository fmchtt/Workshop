import { createLazyFileRoute } from "@tanstack/react-router";

export const Route = createLazyFileRoute("/_protected/management/employees")({
  component: () => <div>Hello /_protected/management/employees!</div>,
});
