import { useQueryClient } from "@tanstack/react-query";
import { EmployeeFilters } from "../../services/api/company";
import { FilterProps } from "../../types/utils/filter";
import Form from "../form";
import { useEffect, useRef } from "react";
import { FormikProps } from "formik";

export default function EmployeeFilter(props: FilterProps<EmployeeFilters>) {
  const client = useQueryClient();
  const formRef = useRef<FormikProps<EmployeeFilters> | null>();

  useEffect(() => {
    const activeQuery = client.getQueryCache().find({
      queryKey: ["employees"],
      type: "active",
      fetchStatus: "idle",
      exact: false,
    });

    if (activeQuery?.queryKey && activeQuery.queryKey.length > 1) {
      const values = activeQuery.queryKey[1] as EmployeeFilters;
      formRef.current?.setValues(values);
    }
  }, [client]);

  return (
    <Form
      initialValues={{} as EmployeeFilters}
      onSubmit={props.onFilter}
      onReset={props.onClear}
      innerRef={(ref) => (formRef.current = ref)}
    >
      <Form.Input label="Nome" name="name" />
      <Form.Input label="Email" name="email" type="email" />
      <Form.Submit label="Filtrar" />
      <Form.Clear label="Limpar" />
    </Form>
  );
}
