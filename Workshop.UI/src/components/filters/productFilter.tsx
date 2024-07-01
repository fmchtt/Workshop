import { useQueryClient } from "@tanstack/react-query";
import { ProductFilters } from "../../services/api/stock";
import { FilterProps } from "../../types/utils/filter";
import Form from "../form";
import { FormikProps } from "formik";
import { useEffect, useRef } from "react";

export default function ProductFilter(props: FilterProps<ProductFilters>) {
  const client = useQueryClient();
  const formRef = useRef<FormikProps<ProductFilters> | null>();

  useEffect(() => {
    const activeQuery = client.getQueryCache().find({
      queryKey: ["products"],
      type: "active",
      fetchStatus: "idle",
      exact: false,
    });

    if (activeQuery?.queryKey && activeQuery.queryKey.length > 1) {
      const values = activeQuery.queryKey[1] as ProductFilters;
      formRef.current?.setValues(values);
    }
  }, [client]);

  return (
    <Form
      initialValues={{} as ProductFilters}
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
