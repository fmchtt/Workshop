import { useEffect, useRef } from "react";
import {
  useCreateClientMutation,
  useUpdateClientMutation,
} from "../../services/mutations/client.mutations";
import Form from "../form";
import { FormikProps } from "formik";
import { Client } from "../../types/entities/client";
import { object, string } from "yup";
import { toast } from "react-toastify";

export default function ClientForm(props: {
  clientEdit?: Client;
  onClear: () => void;
  onSuccess: () => void;
}) {
  const createMutation = useCreateClientMutation({
    onSuccess: () => {
      toast.success("Cliente adicionado!");
      formRef.current?.resetForm();
      props.onSuccess();
    },
  });
  const updateMutation = useUpdateClientMutation({
    onSuccess: () => {
      toast.success("Cliente atualizado!");
      formRef.current?.resetForm();
      props.onSuccess();
    },
  });

  const formRef = useRef<FormikProps<{
    name: string;
    id: string;
  }> | null>();

  function setClientEdit(client: Client) {
    formRef.current?.setValues({
      id: client.id,
      name: client.name,
    });
  }

  useEffect(() => {
    props.clientEdit && setClientEdit(props.clientEdit);
  }, [props.clientEdit]);

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
      title={`${props.clientEdit ? "Editar" : "Criar novo"} cliente`}
      validationSchema={object({
        name: string()
          .required("O nome é obrigatório")
          .min(4, "O nome deve ter no mínimo 4 letras"),
      })}
    >
      <Form.Input label="Nome" name="name" placeholder="Ex: Empresa 1" />
      <Form.Submit
        label={props.clientEdit ? "Editar" : "Criar"}
        $loading={createMutation.isPending || updateMutation.isPending}
      />
      <Form.Clear
        label="Limpar"
        $loading={createMutation.isPending || updateMutation.isPending}
      />
    </Form>
  );
}
