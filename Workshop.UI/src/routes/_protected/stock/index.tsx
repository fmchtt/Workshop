import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/_protected/stock/")({
  component: StockHome,
});

function StockHome() {
  return <>Estoque</>;
}
