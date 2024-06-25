import { createFileRoute, Outlet, redirect } from "@tanstack/react-router";
import {
  Container,
  PageContainer,
  PageWrapper,
} from "../components/styles.global";
import Header from "../components/header";
import Sidebar from "../components/sidebar";

export const Route = createFileRoute("/_protected")({
  component: ProtectedLayout,
  beforeLoad: ({ context }) => {
    if (!context.auth.user) {
      throw redirect({ to: "/login" });
    }
  },
});

function ProtectedLayout() {
  return (
    <Container>
      <Sidebar />
      <PageWrapper>
        <Header />
        <PageContainer>
          <Outlet />
        </PageContainer>
      </PageWrapper>
    </Container>
  );
}
