import { createLazyFileRoute } from "@tanstack/react-router";
import {
  ButtonWrapper,
  FlexibleContainer,
  IconButton,
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
import FilledButton from "../../../components/filledbutton";
import { FaX } from "react-icons/fa6";
import { FaFilter } from "react-icons/fa";
import { IoPersonAdd } from "react-icons/io5";
import { useAuth } from "../../../contexts/authContext";
import EmployeeFilter from "../../../components/filters/employeeFilter";
import { Helmet } from "react-helmet";

export const Route = createLazyFileRoute("/_protected/management/employees")({
  component: EmployeeManagement,
});

function EmployeeManagement() {
  const { user } = useAuth();
  const { data } = useEmployees();
  const [employeeDelete, setEmployeeDelete] = useState<
    ResumedEmployee | undefined
  >();
  const deleteMutation = useDeleteEmployeeMutation({
    onSuccess: () => {
      setEmployeeDelete(undefined);
    },
  });
  const [form, setForm] = useState<"add" | "filter" | undefined>(undefined);

  return (
    <RouteContainer $column>
      <Helmet>
        <title>Colaboradores</title>
      </Helmet>
      <ButtonWrapper>
        <FilledButton
          disabled={form === "filter"}
          $margin="0"
          onClick={() => setForm("filter")}
        >
          <FaFilter />
          Filtros
        </FilledButton>
        <FilledButton
          disabled={form === "add"}
          $margin="0"
          onClick={() => setForm("add")}
        >
          <IoPersonAdd />
          Adicionar colaborador
        </FilledButton>
      </ButtonWrapper>
      <RouteContainer>
        {form !== undefined && (
          <SideContainer>
            <IconButton $alignEnd>
              <FaX onClick={() => setForm(undefined)} />
            </IconButton>
            {form === "add" && <EmployeeForm />}
            {form === "filter" && (
              <EmployeeFilter onFilter={(values) => console.log(values)} />
            )}
          </SideContainer>
        )}
        <FlexibleContainer>
          <Table
            rows={data || []}
            columns={[
              { key: "user", title: "Nome", parser: (user) => user.name },
              { key: "user", title: "Email", parser: (user) => user.email },
              { key: "role", title: "Cargo", parser: (role) => role.name },
            ]}
            showDelete={(employee) =>
              employee.user.id !== user?.id &&
              employee.user.id !== user?.working?.company.ownerId
            }
            onDelete={(data) => setEmployeeDelete(data)}
          />
        </FlexibleContainer>
      </RouteContainer>
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
