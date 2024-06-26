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

export const Route = createLazyFileRoute("/_protected/customer/")({
  component: CustomerHome,
});

function CustomerHome() {
  const [clientEdit, setClientEdit] = useState<Client | undefined>();
  const { data } = useClients();

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
          onDelete={(data) => console.log(data)}
          showEdit
          onEdit={(data) => setClientEdit(data)}
        />
      </TableContainer>
    </ClientContainer>
  );
}
