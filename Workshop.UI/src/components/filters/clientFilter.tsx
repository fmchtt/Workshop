import { useQueryClient } from "@tanstack/react-query";
import { ClientFilters } from "../../services/api/client";
import { FilterProps } from "../../types/utils/filter";
import Form from "../form";
import { FormikProps } from "formik";
import { useEffect, useRef } from "react";

export default function ClientFilter(props: FilterProps<ClientFilters>) {
  const client = useQueryClient();
  const formRef = useRef<FormikProps<ClientFilters> | null>();

  useEffect(() => {
    const activeQuery = client.getQueryCache().find({
      queryKey: ["clients"],
      type: "active",
      fetchStatus: "idle",
      exact: false,
    });

    if (activeQuery?.queryKey && activeQuery.queryKey.length > 1) {
      const values = activeQuery.queryKey[1] as ClientFilters;
      formRef.current?.setValues(values);
    }
  }, [client]);

  return (
    <Form
      initialValues={{} as ClientFilters}
      onSubmit={props.onFilter}
      onReset={props.onClear}
      innerRef={(ref) => (formRef.current = ref)}
    >
      <Form.Input label="Nome" name="name" />
      <Form.Submit label="Filtrar" />
      <Form.Clear label="Limpar" />
    </Form>
  );
}
