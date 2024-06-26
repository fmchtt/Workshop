import { createRootRoute, Outlet } from "@tanstack/react-router";
import { TanStackRouterDevtools } from "@tanstack/router-devtools";
import { SpinnerContainer } from "../components/styles.global";
import Spinner from "../components/spinner";

export const Route = createRootRoute({
  component: () => (
    <>
      <Outlet />
      <TanStackRouterDevtools />
    </>
  ),
  pendingComponent: () => (
    <SpinnerContainer>
      <Spinner size="60px" />
    </SpinnerContainer>
  ),
});
