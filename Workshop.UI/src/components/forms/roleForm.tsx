import { useEffect, useRef } from "react";
import Form from "../form";
import { FormikProps } from "formik";
import { Client } from "../../types/entities/client";
import {
  useCreateRoleMutation,
  useUpdateRoleMutation,
} from "../../services/mutations/role.mutations";
import { object, string } from "yup";
import { toast } from "react-toastify";

export default function RoleForm(props: {
  roleEdit?: Client;
  onClear: () => void;
}) {
  const createMutation = useCreateRoleMutation({
    onSuccess: () => {
      toast.success("Cargo criado!");
      formRef.current?.resetForm();
      props.onClear();
    },
  });
  const updateMutation = useUpdateRoleMutation({
    onSuccess: () => {
      toast.success("Cargo atualizado!");
      formRef.current?.resetForm();
      props.onClear();
    },
  });

  const formRef = useRef<FormikProps<{
    name: string;
    id: string;
  }> | null>();

  function setRoleEdit(client: Client) {
    formRef.current?.setValues({
      id: client.id,
      name: client.name,
    });
  }

  useEffect(() => {
    props.roleEdit && setRoleEdit(props.roleEdit);
  }, [props.roleEdit]);

  return (
    <Form
      initialValues={{
        id: "",
        name: "",
      }}
      onSubmit={(data) => {
        if (data.id !== "") {
          return updateMutation.mutate(data);
        }
        return createMutation.mutate(data);
      }}
      onReset={() => props.onClear()}
      innerRef={(ref) => (formRef.current = ref)}
      title={`${props.roleEdit ? "Editar" : "Criar novo"} cargo`}
      validationSchema={object({
        name: string()
          .required("O nome é obrigatório")
          .min(4, "O nome deve ter no mínimo 4 letras"),
      })}
    >
      <Form.Input label="Nome" name="name" placeholder="Ex: Cargo 1" />
      <Form.Submit
        label={props.roleEdit ? "Editar" : "Criar"}
        $loading={createMutation.isPending || updateMutation.isPending}
      />
      <Form.Clear
        label="Limpar"
        $loading={createMutation.isPending || updateMutation.isPending}
      />
    </Form>
  );
}
