import { Field, FieldProps } from "formik";
import { Description, ErrorMessage, InputGroup, Label } from "./styles";
import RCSwitch from "rc-switch";

type SwitchProps = {
  name: string;
  description: string;
  label: string;
};
export default function Switch({ label, description, name }: SwitchProps) {
  return (
    <Field name={name}>
      {({ field, form, meta }: FieldProps) => (
        <InputGroup>
          <Label>{label}</Label>
          <RCSwitch
            {...field}
            defaultValue={field.value || false}
            onChange={(value) => form.setFieldValue(field.name, value)}
          />
          {description && <Description>{description}</Description>}
          {meta.touched && meta.error && (
            <ErrorMessage>{meta.error}</ErrorMessage>
          )}
        </InputGroup>
      )}
    </Field>
  );
}
