import { useRef } from "react";
import { useCreateEmployeeMutation } from "../../services/mutations/company.mutations";
import { useRoles } from "../../services/queries/roles.queries";
import Form from "../form";
import { FormikProps } from "formik";
import { object, string } from "yup";
import { toast } from "react-toastify";

export default function EmployeeForm(props: { onSuccess: () => void }) {
  const formRef = useRef<FormikProps<{
    name: string;
    email: string;
    roleId: string;
  }> | null>();
  const rolesQuery = useRoles();

  const createMutation = useCreateEmployeeMutation({
    onSuccess: () => {
      toast.success("Colaborador adicionado!");
      props.onSuccess();
      formRef.current?.resetForm();
    },
  });

  return (
    <Form
      initialValues={{ name: "", email: "", roleId: "" }}
      onSubmit={(data) => {
        createMutation.mutate(data);
      }}
      innerRef={(ref) => (formRef.current = ref)}
      validationSchema={object({
        name: string()
          .required("O nome é obrigatório")
          .min(4, "O nome deve ter no mínimo 4 letras"),
        email: string()
          .required("O email é obrigatório")
          .email("Email inválido"),
        roleId: string().required("O cargo é obrigatório").uuid(),
      })}
    >
      <Form.Input label="Nome" name="name" />
      <Form.Input label="Email" name="email" type="email" />
      <Form.Select
        options={
          rolesQuery.data?.map((r) => ({ label: r.name, value: r.id })) || []
        }
        label="Cargo"
        name="roleId"
      />
      <Form.Submit label="Criar" $loading={createMutation.isPending} />
      <Form.Clear label="Limpar" />
    </Form>
  );
}
