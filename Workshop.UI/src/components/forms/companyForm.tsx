import { useCreateCompanyMutation, useUpdateCompanyMutation } from "../../services/mutations/company.mutations";
import { useCompany } from "../../services/queries/company.queries";
import Form from "../form";
import Spinner from "../spinner";

export default function CompanyForm() {
  const { data, isLoading } = useCompany();
  const updateMutation = useUpdateCompanyMutation();
  const createMutation = useCreateCompanyMutation();

  if (isLoading) {
    return <Spinner />;
  }

  return (
    <Form
      initialValues={{ name: data?.name }}
      onSubmit={(values) => {
        if(data){
          updateMutation.mutate({ ...values, companyId: data.id });
          return;
        }
        createMutation.mutate({...values});
        return;
      }}
    >
      <Form.Input label="Nome" name="name" />
      <Form.Submit label={data ? "Editar" : "Criar"} />
    </Form>
  );
}
