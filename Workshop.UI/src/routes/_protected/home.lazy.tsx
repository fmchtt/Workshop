import { createLazyFileRoute } from "@tanstack/react-router";
import CompanySelector from "../../components/companySelector";
import CompanyForm from "../../components/forms/companyForm";
import Spinner from "../../components/spinner";
import { useMe } from "../../services/queries/auth.queries";
import { useCompanies } from "../../services/queries/company.queries";
import { RouteContainer, SideContainer } from "../../components/styles.global";
import { Helmet } from "react-helmet";

export const Route = createLazyFileRoute("/_protected/home")({
  component: Home,
});

export function Home() {
  const { data, isLoading } = useMe();
  const companiesQuery = useCompanies();

  if (isLoading || companiesQuery.isLoading) {
    return <Spinner />;
  }

  return (
    <>
      <Helmet>
        <title>Dashboard</title>
      </Helmet>
      {!data?.working && companiesQuery.data?.length == 0 ? (
        <RouteContainer>
          <SideContainer>
            <CompanyForm />
          </SideContainer>
        </RouteContainer>
      ) : (
        <RouteContainer $column>
          <div>
            <h3>Seja bem vindo ao sistema Workshop!</h3>
            <p>Selecione o modulo deseja na barra lateral para iniciar!</p>
          </div>
          <CompanySelector />
        </RouteContainer>
      )}
    </>
  );
}
