import { useRef } from "react";
import { useCreateEmployeeMutation } from "../../services/mutations/company.mutations";
import { useRoles } from "../../services/queries/roles.queries";
import Form from "../form";
import { FormikProps } from "formik";

export default function EmployeeForm() {
  const formRef = useRef<FormikProps<{
    name: string;
    email: string;
    roleId: string;
  }> | null>();
  const rolesQuery = useRoles();

  const createMutation = useCreateEmployeeMutation({
    onSuccess: () => {
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
