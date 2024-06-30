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
  ButtonWrapper,
  FlexibleContainer,
  IconButton,
  RouteContainer,
  SideContainer,
} from "../../../components/styles.global";
import FilledButton from "../../../components/filledbutton";
import { FaX } from "react-icons/fa6";
import { FaBuilding, FaFilter } from "react-icons/fa";
import ClientFilter from "../../../components/filters/clientFilter";
import { Helmet } from "react-helmet";
import { ClientFilters } from "../../../services/api/client";
import { toast } from "react-toastify";

export const Route = createLazyFileRoute("/_protected/customer/")({
  component: CustomerHome,
});

function CustomerHome() {
  const [clientEdit, setClientEdit] = useState<Client | undefined>();
  const [clientDelete, setClientDelete] = useState<Client | undefined>();
  const validatingPermission = usePermissions();
  const [form, setForm] = useState<"add" | "filter" | undefined>(undefined);
  const [filters, setFilters] = useState({} as ClientFilters);
  const { data } = useClients({ filters: filters });

  const deleteMutation = useDeleteClientMutation({
    onSuccess: () => {
      toast.success("Clinte removido!");
      setClientDelete(undefined);
    },
  });

  if (validatingPermission([{ type: "management", value: "manageClient" }])) {
    return <PendingComponent />;
  }

  return (
    <RouteContainer $column>
      <Helmet>
        <title>Clientes</title>
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
          onClick={() => {
            setForm("add");
            setClientEdit(undefined);
          }}
        >
          <FaBuilding />
          Adicionar cliente
        </FilledButton>
      </ButtonWrapper>
      <RouteContainer>
        {form !== undefined && (
          <SideContainer>
            <IconButton $alignEnd>
              <FaX onClick={() => setForm(undefined)} />
            </IconButton>
            {form === "add" && (
              <ClientForm
                clientEdit={clientEdit}
                onClear={() => setClientEdit(undefined)}
                onSuccess={() => {
                  setClientEdit(undefined);
                  setFilters({});
                }}
              />
            )}
            {form === "filter" && (
              <ClientFilter
                onFilter={(values) => setFilters(values)}
                onClear={() => setFilters({})}
              />
            )}
          </SideContainer>
        )}
        <FlexibleContainer>
          <Table
            rows={data || []}
            columns={[{ key: "name", title: "Nome" }]}
            showDelete
            onDelete={(data) => setClientDelete(data)}
            showEdit
            onEdit={(data) => {
              setForm("add");
              setClientEdit(data);
            }}
          />
        </FlexibleContainer>
        <ConfirmationModal
          title="Deletar cliente"
          text={`Tem certeza que deseja apagar o cliente ${clientDelete?.name} ?`}
          onSuccess={() => {
            clientDelete && deleteMutation.mutate(clientDelete.id);
            setFilters({});
          }}
          onClose={() => setClientDelete(undefined)}
          show={!!clientDelete}
          $loading={deleteMutation.isPending}
        />
      </RouteContainer>
    </RouteContainer>
  );
}
