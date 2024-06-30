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
import { object, string } from "yup";
import { toast } from "react-toastify";

type OrderFormProps = {
  orderEdit?: Order;
  onClear: () => void;
  onSuccess: () => void;
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
      toast.success("Ordem de serviço criada!");
      formRef.current?.resetForm();
      props.onSuccess();
    },
  });
  const updateMutation = useUpdateOrderMutation({
    onSuccess: () => {
      toast.success("Ordem de serviço atualizada!");
      formRef.current?.resetForm();
      props.onSuccess();
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
      title={`${props.orderEdit ? "Editar" : "Criar nova"} ordem de serviço`}
      innerRef={(ref) => (formRef.current = ref)}
      onSubmit={(data) => {
        if (data.id !== "") {
          return updateMutation.mutate(data);
        }
        return createMutation.mutate(data);
      }}
      onReset={() => props.onClear()}
      validationSchema={object({
        clientId: string().required("O cliente é obrigatório").uuid(),
        employeeId: string().required("O cliente é obrigatório").uuid(),
      })}
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
        label={props.orderEdit ? "Editar" : "Criar"}
        $loading={createMutation.isPending || updateMutation.isPending}
      />
      <Form.Clear label="Limpar" />
    </Form>
  );
}
