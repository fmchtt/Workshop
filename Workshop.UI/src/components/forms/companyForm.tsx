import { useAuth } from "../../contexts/authContext";
import {
  useCreateCompanyMutation,
  useUpdateCompanyMutation,
} from "../../services/mutations/company.mutations";
import { useCompany } from "../../services/queries/company.queries";
import Form from "../form";
import Spinner from "../spinner";

export default function CompanyForm() {
  const { user } = useAuth();
  const { data, isLoading } = useCompany({ enabled: !!user?.working });
  const updateMutation = useUpdateCompanyMutation();
  const createMutation = useCreateCompanyMutation();

  if (!!user?.working && isLoading) {
    return <Spinner />;
  }

  return (
    <Form
      initialValues={{ name: data?.name || "" }}
      onSubmit={(values) => {
        if (data) {
          updateMutation.mutate({ ...values, companyId: data.id });
          return;
        }
        createMutation.mutate(values);
      }}
      title={`${data ? "Editar" : "Criar nova"} empresa`}
    >
      <Form.Input label="Nome" name="name" />
      <Form.Submit label={data ? "Editar" : "Criar"} />
    </Form>
  );
}
