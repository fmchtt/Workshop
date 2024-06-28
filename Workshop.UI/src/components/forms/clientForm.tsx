import { useEffect, useRef } from "react";
import {
  useCreateClientMutation,
  useUpdateClientMutation,
} from "../../services/mutations/client.mutations";
import Form from "../form";
import { FormikProps } from "formik";
import { Client } from "../../types/entities/client";

export default function ClientForm(props: {
  clientEdit?: Client;
  onClear: () => void;
}) {
  const createMutation = useCreateClientMutation({
    onSuccess: () => {
      formRef.current?.resetForm();
      props.onClear();
    },
  });
  const updateMutation = useUpdateClientMutation({
    onSuccess: () => {
      formRef.current?.resetForm();
      props.onClear();
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
