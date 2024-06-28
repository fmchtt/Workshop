import { useUpdateCompanyMutation } from "../../services/mutations/company.mutations";
import { useCompany } from "../../services/queries/company.queries";
import Form from "../form";
import Spinner from "../spinner";

export default function CompanyForm() {
  const { data, isLoading } = useCompany();
  const updateMutation = useUpdateCompanyMutation();

  if (isLoading || !data) {
    return <Spinner />;
  }

  return (
    <Form
      initialValues={{ name: data?.name }}
      onSubmit={(values) => {
        updateMutation.mutate({ ...values, companyId: data.id });
      }}
    >
      <Form.Input label="Nome" name="name" />
      <Form.Submit label="Editar" />
    </Form>
  );
}
