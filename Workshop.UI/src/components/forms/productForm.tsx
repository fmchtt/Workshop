import { useEffect, useRef } from "react";
import { Product } from "../../types/entities/product";
import Form from "../form";
import { FormikProps } from "formik";
import {
  useCreateProductMutation,
  useUpdateProductMutation,
} from "../../services/mutations/product.mutations";
import { number, object, string } from "yup";
import { toast } from "react-toastify";

export default function ProductForm(props: {
  productEdit: Product | undefined;
  onClear: () => void;
}) {
  const createMutation = useCreateProductMutation({
    onSuccess: () => {
      toast.success("Produto criado!");
      formRef.current?.resetForm();
      props.onClear();
    },
  });
  const updateMuration = useUpdateProductMutation({
    onSuccess: () => {
      toast.success("Produto atualizado!");
      formRef.current?.resetForm();
      props.onClear();
    },
  });

  const formRef = useRef<FormikProps<{
    id: string;
    name: string;
    description: string;
    price: number;
    quantity: number;
  }> | null>();

  function setProductEdit(product: Product) {
    formRef.current?.setValues({
      id: product.id,
      name: product.name,
      description: product.description,
      price: product.price,
      quantity: product.quantityInStock,
    });
  }

  useEffect(() => {
    props.productEdit && setProductEdit(props.productEdit);
  }, [props.productEdit]);

  return (
    <Form
      initialValues={{
        id: "",
        name: "",
        description: "",
        price: 0,
        quantity: 0,
      }}
      onSubmit={(data) => {
        if (data.id !== "") {
          return updateMuration.mutate(data);
        }
        return createMutation.mutate(data);
      }}
      onReset={() => props.onClear()}
      title={`${props.productEdit ? "Editar" : "Criar novo"} produto`}
      innerRef={(ref) => (formRef.current = ref)}
      validationSchema={object({
        name: string()
          .required("O nome é obrigatório")
          .min(4, "O nome deve ter no mínimo 4 letras"),
        description: string(),
        price: number()
          .required("O preço é obrigatório")
          .min(0, "O preço deve ser maior que 0"),
        quantity: number()
          .required("O preço é obrigatório")
          .min(0, "A quantidade deve ser maior que 0"),
      })}
    >
      <Form.Input label="Nome" name="name" placeholder="Ex: Lâmpada H4" />
      <Form.TextArea
        label="Descrição"
        name="description"
        placeholder="Ex: Serve nos veiculos X, Y e Z"
      />
      <Form.Input label="Preço" name="price" type="number" />
      <Form.Input label="Quantidade" name="quantity" type="number" />
      <Form.Submit label={props.productEdit ? "Editar" : "Criar"} />
      <Form.Clear label="Limpar" />
    </Form>
  );
}
