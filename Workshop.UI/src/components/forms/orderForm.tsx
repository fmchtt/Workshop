import { useClients } from "../../services/queries/client.queries";
import { useEmployees } from "../../services/queries/company.queries";
import Form from "../form";

export default function OrderForm() {
  const employeeQuery = useEmployees();
  const clientQuery = useClients();

  return (
    <Form
      initialValues={{
        name: "",
      }}
      onSubmit={() => {}}
      title="Criar nova ordem de serviço"
    >
      <Form.Select
        label="Cliente"
        name="clientId"
        options={
          clientQuery.data?.map((client) => {
            return {
              label: client.name,
              value: client.id,
            };
          }) || []
        }
      />
      <Form.Select
        label="Mecânico"
        name="employeeId"
        options={
          employeeQuery.data?.map((employee) => {
            return {
              label: employee.user.name,
              value: employee.id,
            };
          }) || []
        }
      />
      <Form.Submit label="Criar" />
    </Form>
  );
}
