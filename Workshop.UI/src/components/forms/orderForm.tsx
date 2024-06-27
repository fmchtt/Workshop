import { useEffect, useRef } from "react";
import {
  useCreateOrderMutation,
  useUpdateOrderMutation,
} from "../../services/mutations/order.mutations";
import { useClients } from "../../services/queries/client.queries";
import { useEmployees } from "../../services/queries/company.queries";
import Form from "../form";
import { FormikProps } from "formik";
import { Order } from "../../types/entities/order";

type OrderFormProps = {
  orderEdit?: Order;
  onClear: () => void;
};
export default function OrderForm(props: OrderFormProps) {
  const employeeQuery = useEmployees();
  const clientQuery = useClients();

  const formRef = useRef<FormikProps<{
    id: string;
    clientId: string;
    employeeId: string;
  }> | null>();

  const createMutation = useCreateOrderMutation({
    onSuccess: () => {
      formRef.current?.resetForm();
      props.onClear();
    },
  });
  const updateMutation = useUpdateOrderMutation({
    onSuccess: () => {
      formRef.current?.resetForm();
      props.onClear();
    },
  });

  function setOrderEdit(order: Order) {
    formRef.current?.setValues({
      id: order.id,
      clientId: order.client.id,
      employeeId: order.employee.id,
    });
  }

  useEffect(() => {
    props.orderEdit && setOrderEdit(props.orderEdit);
  }, [props.orderEdit]);

  return (
    <Form
      initialValues={{
        id: "",
        clientId: "",
        employeeId: "",
      }}
      title="Criar nova ordem de serviço"
      innerRef={(ref) => (formRef.current = ref)}
      onSubmit={(data) => {
        if (data.id !== "") {
          return updateMutation.mutate(data);
        }
        return createMutation.mutate(data);
      }}
      onReset={() => props.onClear}
    >
      <Form.Select
        label="Cliente"
        name="clientId"
        options={
          clientQuery.data?.map((client) => {
            return {
              label: client.name,
              value: client.id,
            };
          }) || []
        }
      />
      <Form.Select
        label="Colaborador"
        name="employeeId"
        options={
          employeeQuery.data?.map((employee) => {
            return {
              label: employee.user.name,
              value: employee.id,
            };
          }) || []
        }
      />
      <Form.Submit
        label="Criar"
        $loading={createMutation.isPending || updateMutation.isPending}
      />
      <Form.Clear label="Limpar" />
    </Form>
  );
}
