import { createLazyFileRoute } from "@tanstack/react-router";
import { ClientContainer } from "../../../components/pages/client.style";
import {
  FormContainer,
  TableContainer,
} from "../../../components/pages/stock.styles";
import { Table } from "../../../components/table";
import { useClients } from "../../../services/queries/client.queries";
import ClientForm from "../../../components/forms/clientForm";
import { useState } from "react";
import { Client } from "../../../types/entities/client";
import ConfirmationModal from "../../../components/confirmationModal";
import { useDeleteClientMutation } from "../../../services/mutations/client.mutations";
import usePermissions from "../../../hooks/usePermissions";
import PendingComponent from "../../../components/pendingComponent";

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
    <ClientContainer>
      <FormContainer>
        <ClientForm
          clientEdit={clientEdit}
          onClear={() => setClientEdit(undefined)}
        />
      </FormContainer>
      <TableContainer>
        <Table
          rows={data || []}
          columns={[{ key: "name", title: "Nome" }]}
          showDelete
          onDelete={(data) => setClientDelete(data)}
          showEdit
          onEdit={(data) => setClientEdit(data)}
        />
      </TableContainer>
      <ConfirmationModal
        title="Deletar cliente"
        text={`Tem certeza que deseja apagar o cliente ${clientDelete?.name} ?`}
        onSuccess={() => clientDelete && deleteMutation.mutate(clientDelete.id)}
        onClose={() => setClientDelete(undefined)}
        show={!!clientDelete}
        $loading={deleteMutation.isPending}
      />
    </ClientContainer>
  );
}
