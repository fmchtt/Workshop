import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/_protected/home")({
  component: Home,
});

export function Home() {
  return (
    <>
      <h3>Seja bem vindo ao sistema Workshop!</h3>
      <p>Selecione o modulo deseja na barra lateral para iniciar!</p>
    </>
  );
}
