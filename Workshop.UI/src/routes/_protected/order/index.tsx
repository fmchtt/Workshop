import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/_protected/order/")({
  component: () => <div>Hello /_protected/order/!</div>,
});
