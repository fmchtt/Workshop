import { Formik, FormikConfig, FormikValues } from "formik";
import { PropsWithChildren } from "react";
import { FormContainer, FormProps, Title } from "./styles";
import Input from "./input";
import TextArea from "./textarea";
import Password from "./password";
import SubmitButton from "./submit";
import ClearButton from "./clear";
import FieldSelect from "./select";
import FormSwitch from "./switch";

export default function Form<T>({
  children,
  title,
  ...props
}: PropsWithChildren<
  FormikConfig<T extends FormikValues ? T : FormikValues> & FormProps
>) {
  return (
    <Formik {...props}>
      {(formProps) => (
        <FormContainer
          width={props.width}
          onSubmit={formProps.handleSubmit}
          onReset={formProps.handleReset}
        >
          {title && <Title>{title}</Title>}
          {children}
        </FormContainer>
      )}
    </Formik>
  );
}

Form.Input = Input;
Form.Select = FieldSelect;
Form.TextArea = TextArea;
Form.Password = Password;
Form.Switch = FormSwitch;
Form.Submit = SubmitButton;
Form.Clear = ClearButton;
