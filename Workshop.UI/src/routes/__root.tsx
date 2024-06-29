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
import { useTheme } from "styled-components";
import { Helmet } from "react-helmet";

export const Route = createRootRoute({
  component: Root,
  pendingComponent: () => <PendingComponent $fullWindow />,
  errorComponent: (props) => <ErrorComponent {...props} />,
});

function Root() {
  const theme = useTheme();

  return (
    <Container>
      <Helmet>
        <style>
          {`
            .rc-switch-checked {
              border: 1px solid ${theme.colors.secondary};
              background-color: ${theme.colors.secondary};
            };
          `}
        </style>
      </Helmet>
      <Sidebar />
      <PageWrapper>
        <Header />
        <PageContainer>
          <Outlet />
        </PageContainer>
      </PageWrapper>
      <TanStackRouterDevtools />
    </Container>
  );
}
