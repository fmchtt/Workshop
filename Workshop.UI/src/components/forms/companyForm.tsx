import { object, string } from "yup";
import { useAuth } from "../../contexts/authContext";
import {
  useCreateCompanyMutation,
  useUpdateCompanyMutation,
} from "../../services/mutations/company.mutations";
import { useCompany } from "../../services/queries/company.queries";
import Form from "../form";
import Spinner from "../spinner";
import { toast } from "react-toastify";

export default function CompanyForm() {
  const { user } = useAuth();
  const { data, isLoading } = useCompany({ enabled: !!user?.working });
  const updateMutation = useUpdateCompanyMutation({
    onSuccess: () => {
      toast.success("Empresa atualizada!");
    },
  });
  const createMutation = useCreateCompanyMutation({
    onSuccess: () => {
      toast.success("Empresa criada!");
    },
  });

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
      validationSchema={object({
        name: string()
          .required("O nome é obrigatório")
          .min(4, "O nome deve ter no mínimo 4 letras"),
      })}
    >
      <Form.Input label="Nome" name="name" />
      <Form.Submit label={data ? "Editar" : "Criar"} />
    </Form>
  );
}
