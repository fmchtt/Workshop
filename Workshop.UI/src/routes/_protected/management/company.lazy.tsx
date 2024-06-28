import { createLazyFileRoute } from "@tanstack/react-router";
import CompanyForm from "../../../components/forms/companyForm";
import {
  RouteContainer,
  SideContainer,
} from "../../../components/styles.global";
import PendingComponent from "../../../components/pendingComponent";
import usePermissions from "../../../hooks/usePermissions";

export const Route = createLazyFileRoute("/_protected/management/company")({
  component: UpdateCompany,
});

function UpdateCompany() {
  const validatingPermission = usePermissions();

  if (validatingPermission([{ type: "management", value: "manageCompany" }])) {
    return <PendingComponent />;
  }

  return (
    <RouteContainer>
      <SideContainer>
        <CompanyForm />
      </SideContainer>
    </RouteContainer>
  );
}
