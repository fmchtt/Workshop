import { createLazyFileRoute } from "@tanstack/react-router";
import { Table } from "../../../components/table";
import { useClients } from "../../../services/queries/client.queries";
import ClientForm from "../../../components/forms/clientForm";
import { useState } from "react";
import { Client } from "../../../types/entities/client";
import ConfirmationModal from "../../../components/confirmationModal";
import { useDeleteClientMutation } from "../../../services/mutations/client.mutations";
import usePermissions from "../../../hooks/usePermissions";
import PendingComponent from "../../../components/pendingComponent";
import {
  FlexibleContainer,
  RouteContainer,
  SideContainer,
} from "../../../components/styles.global";

export const Route = createLazyFileRoute("/_protected/customer/")({
  component: CustomerHome,
});

function CustomerHome() {
  const [clientEdit, setClientEdit] = useState<Client | undefined>();
  const [clientDelete, setClientDelete] = useState<Client | undefined>();
  const validatingPermission = usePermissions();
  const { data } = useClients();

  const deleteMutation = useDeleteClientMutation({
    onSuccess: () => setClientDelete(undefined),
  });

  if (validatingPermission([{ type: "management", value: "manageClient" }])) {
    return <PendingComponent />;
  }

  return (
    <RouteContainer>
      <SideContainer>
        <ClientForm
          clientEdit={clientEdit}
          onClear={() => setClientEdit(undefined)}
        />
      </SideContainer>
      <FlexibleContainer>
        <Table
          rows={data || []}
          columns={[{ key: "name", title: "Nome" }]}
          showDelete
          onDelete={(data) => setClientDelete(data)}
          showEdit
          onEdit={(data) => setClientEdit(data)}
        />
      </FlexibleContainer>
      <ConfirmationModal
        title="Deletar cliente"
        text={`Tem certeza que deseja apagar o cliente ${clientDelete?.name} ?`}
        onSuccess={() => clientDelete && deleteMutation.mutate(clientDelete.id)}
        onClose={() => setClientDelete(undefined)}
        show={!!clientDelete}
        $loading={deleteMutation.isPending}
      />
    </RouteContainer>
  );
}
