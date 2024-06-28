import { createLazyFileRoute } from "@tanstack/react-router";
import {
  FlexibleContainer,
  RouteContainer,
  SideContainer,
} from "../../../components/styles.global";
import { useEmployees } from "../../../services/queries/company.queries";
import { Table } from "../../../components/table";
import EmployeeForm from "../../../components/forms/employeeForm";
import { useDeleteEmployeeMutation } from "../../../services/mutations/company.mutations";
import { useState } from "react";
import { ResumedEmployee } from "../../../types/entities/employee";
import ConfirmationModal from "../../../components/confirmationModal";

export const Route = createLazyFileRoute("/_protected/management/employees")({
  component: EmployeeManagement,
});

function EmployeeManagement() {
  const { data } = useEmployees();
  const [employeeDelete, setEmployeeDelete] = useState<
    ResumedEmployee | undefined
  >();
  const deleteMutation = useDeleteEmployeeMutation({
    onSuccess: () => {
      setEmployeeDelete(undefined);
    },
  });

  return (
    <RouteContainer>
      <SideContainer>
        <EmployeeForm />
      </SideContainer>
      <FlexibleContainer>
        <Table
          rows={data || []}
          columns={[
            { key: "user", title: "Nome", parser: (user) => user.name },
            { key: "user", title: "Email", parser: (user) => user.email },
            { key: "role", title: "Cargo", parser: (role) => role.name },
          ]}
          showDelete
          onDelete={(data) => setEmployeeDelete(data)}
        />
      </FlexibleContainer>
      <ConfirmationModal
        text={`Tem certeza que deseja apagar o colaborador ${employeeDelete?.user.name} ?`}
        title="Apagar colaborador"
        show={!!employeeDelete}
        onClose={() => setEmployeeDelete(undefined)}
        onSuccess={() => deleteMutation.mutate(employeeDelete?.id || "")}
      />
    </RouteContainer>
  );
}
