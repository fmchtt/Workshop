import { createLazyFileRoute } from "@tanstack/react-router";
import CompanyForm from "../../../components/forms/companyForm";
import {
  RouteContainer,
  SideContainer,
} from "../../../components/styles.global";

export const Route = createLazyFileRoute("/_protected/management/company")({
  component: UpdateCompany,
});

function UpdateCompany() {
  return (
    <RouteContainer>
      <SideContainer>
        <CompanyForm />
      </SideContainer>
    </RouteContainer>
  );
}
