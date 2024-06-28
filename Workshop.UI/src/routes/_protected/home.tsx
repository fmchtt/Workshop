import { createFileRoute } from "@tanstack/react-router";
import CompanySelector from "../../components/companySelector";
import CompanyForm from "../../components/forms/companyForm";
import { CompanyContainer } from "../../components/pages/company.styles";
import { FormContainer } from "../../components/pages/stock.styles";
import Spinner from "../../components/spinner";
import { useMe } from "../../services/queries/auth.queries";

export const Route = createFileRoute("/_protected/home")({
  component: Home,
});

export function Home() {
  const { data, isLoading } = useMe();

  if (isLoading) {
    return <Spinner />;
  }
  
  return (
    <>
      {data?.working?.company ? (
        <>
          <h3>Seja bem vindo ao sistema Workshop!</h3>
          <p>Selecione o modulo deseja na barra lateral para iniciar!</p>
          <CompanySelector />
        </>)
      : (
        <>
        <CompanyContainer>
          <FormContainer>
            <CompanyForm />
          </FormContainer>
        </CompanyContainer>
        </>
      )}
      
    </>
  );
}
