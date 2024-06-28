import { Field, FieldProps } from "formik";
import { Description, ErrorMessage, InputGroup, Label } from "./styles";
import RCSwitch from "rc-switch";

type FormSwitchProps = {
  name: string;
  description: string;
  label: string;
};
export default function FormSwitch({
  label,
  description,
  name,
}: FormSwitchProps) {
  return (
    <Field name={name}>
      {({ field, form, meta }: FieldProps) => (
        <InputGroup>
          <Label>{label}</Label>
          <RCSwitch
            {...field}
            checked={field.value}
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

type SwitchProps = {
  checked?: boolean;
  defaultChecked?: boolean;
  onChange?: (value: boolean) => void;
  disabled?: boolean;
};
export function Switch(props: SwitchProps) {
  return (
    <RCSwitch
      checked={props.checked}
      defaultChecked={props.defaultChecked}
      onChange={props.onChange}
      disabled={props.disabled}
    />
  );
}
