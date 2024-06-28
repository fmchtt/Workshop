import { createLazyFileRoute } from "@tanstack/react-router";
import { CompanyContainer } from "../../../components/pages/company.styles";
import { FormContainer } from "../../../components/pages/stock.styles";
import CompanyForm from "../../../components/forms/companyForm";

export const Route = createLazyFileRoute("/_protected/management/company")({
  component: UpdateCompany,
});

function UpdateCompany() {
  return (
    <CompanyContainer>
      <FormContainer>
        <CompanyForm />
      </FormContainer>
    </CompanyContainer>
  );
}
