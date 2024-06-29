import { createLazyFileRoute } from "@tanstack/react-router";
import {
  ButtonWrapper,
  FlexibleContainer,
  IconButton,
  RouteContainer,
  SideContainer,
} from "../../../../components/styles.global";
import { Table } from "../../../../components/table";
import { useState } from "react";
import ConfirmationModal from "../../../../components/confirmationModal";
import FilledButton from "../../../../components/filledbutton";
import { FaX } from "react-icons/fa6";
import { IoPersonAdd } from "react-icons/io5";
import { useRoles } from "../../../../services/queries/roles.queries";
import { Role } from "../../../../types/entities/role";
import { useDeleteRoleMutation } from "../../../../services/mutations/role.mutations";
import RoleForm from "../../../../components/forms/roleForm";
import { Helmet } from "react-helmet";

export const Route = createLazyFileRoute("/_protected/management/roles/")({
  component: RoleManagement,
});

function RoleManagement() {
  const { data } = useRoles();
  const [roleEdit, setRoleEdit] = useState<Role | undefined>();
  const [roleDelete, setRoleDelete] = useState<Role | undefined>();
  const deleteMutation = useDeleteRoleMutation({
    onSuccess: () => {
      setRoleDelete(undefined);
    },
  });
  const [form, setForm] = useState<"add" | undefined>(undefined);

  return (
    <RouteContainer $column>
      <Helmet>
        <title>Cargos</title>
      </Helmet>
      <ButtonWrapper>
        <FilledButton
          disabled={form === "add"}
          $margin="0"
          onClick={() => setForm("add")}
        >
          <IoPersonAdd />
          Adicionar cargo
        </FilledButton>
      </ButtonWrapper>
      <RouteContainer>
        {form !== undefined && (
          <SideContainer>
            <IconButton $alignEnd>
              <FaX onClick={() => setForm(undefined)} />
            </IconButton>
            {form === "add" && (
              <RoleForm
                onClear={() => setRoleEdit(undefined)}
                roleEdit={roleEdit}
              />
            )}
          </SideContainer>
        )}
        <FlexibleContainer>
          <Table
            rows={data || []}
            columns={[{ key: "name", title: "Nome" }]}
            showDelete
            onDelete={(data) => setRoleDelete(data)}
            showEdit
            onEdit={(data) => {
              setForm("add");
              setRoleEdit(data);
            }}
            link={(role) => ({
              to: "/management/roles/$roleId",
              params: {
                roleId: role.id,
              },
            })}
          />
        </FlexibleContainer>
      </RouteContainer>
      <ConfirmationModal
        text={`Tem certeza que deseja apagar o cargo ${roleDelete?.name} ?`}
        title="Apagar cargo"
        show={!!roleDelete}
        onClose={() => setRoleDelete(undefined)}
        onSuccess={() => deleteMutation.mutate(roleDelete?.id || "")}
      />
    </RouteContainer>
  );
}
