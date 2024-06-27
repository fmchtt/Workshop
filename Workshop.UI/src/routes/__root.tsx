import { createRootRoute, Outlet } from "@tanstack/react-router";
import { TanStackRouterDevtools } from "@tanstack/router-devtools";
import {
  Container,
  PageContainer,
  PageWrapper,
} from "../components/styles.global";
import Sidebar from "../components/sidebar";
import Header from "../components/header";
import ErrorComponent from "../components/errorComponent";
import PendingComponent from "../components/pendingComponent";

export const Route = createRootRoute({
  component: () => (
    <Container>
      <Sidebar />
      <PageWrapper>
        <Header />
        <PageContainer>
          <Outlet />
        </PageContainer>
      </PageWrapper>
      <TanStackRouterDevtools />
    </Container>
  ),
  pendingComponent: () => <PendingComponent />,
  errorComponent: (props) => <ErrorComponent {...props} />,
});
