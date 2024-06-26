import { createFileRoute } from "@tanstack/react-router";
import { ClientContainer } from "../../../components/pages/client.style";
import {
  FormContainer,
  TableContainer,
} from "../../../components/pages/stock.styles";
import { Table } from "../../../components/table";
import { useClients } from "../../../services/queries/client.queries";
import ClientForm from "../../../components/forms/clientForm";

export const Route = createFileRoute("/_protected/customer/")({
  component: CustomerHome,
});

function CustomerHome() {
  const { data } = useClients();

  return (
    <ClientContainer>
      <FormContainer>
        <ClientForm />
      </FormContainer>
      <TableContainer>
        <Table
          rows={data || []}
          columns={[{ key: "name", title: "Nome" }]}
          showDelete
          onDelete={(data) => console.log(data)}
          showEdit
          onEdit={(data) => console.log(data)}
        />
      </TableContainer>
    </ClientContainer>
  );
}
