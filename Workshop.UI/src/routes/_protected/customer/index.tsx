import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/_protected/customer/")({
  component: () => <div>Hello /_protected/customer/!</div>,
});
