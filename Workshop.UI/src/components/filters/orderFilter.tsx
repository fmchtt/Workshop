import { OrderFilters } from "../../services/api/order";
import { useClients } from "../../services/queries/client.queries";
import { useEmployees } from "../../services/queries/company.queries";
import { FilterProps } from "../../types/utils/filter";
import Form from "../form";

export default function OrderFilter(props: FilterProps<OrderFilters>) {
  const clientQuery = useClients();
  const employeeQuery = useEmployees();

  return (
    <Form
      initialValues={{} as OrderFilters}
      onSubmit={(value) => props.onFilter(value)}
      onReset={props.onClear}
    >
      <Form.Input label="Código" name="orderNumber" type="number" />
      <Form.Select
        label="Cliente"
        name="clientId"
        options={
          clientQuery.data?.map((c) => ({ label: c.name, value: c.id })) || []
        }
        isClearable
      />
      <Form.Select
        label="Colaborador"
        name="employeeId"
        options={
          employeeQuery.data?.map((e) => ({
            label: e.user.name,
            value: e.id,
          })) || []
        }
        isClearable
      />
      <Form.Select
        label="Situação"
        name="complete"
        options={[
          {
            label: "Aberta",
            value: false,
          },
          {
            label: "Concluída",
            value: true,
          },
        ]}
        isClearable
      />
      <Form.Submit label="Filtrar" />
      <Form.Clear label="Limpar" />
    </Form>
  );
}
