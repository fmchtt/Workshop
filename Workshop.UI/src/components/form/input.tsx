import { Field, FieldProps } from "formik";
import {
  Description,
  ErrorMessage,
  InputGroup,
  Label,
  StyledInput,
} from "./styles";
import { FormInputProps } from "../../types/valueObjects/form";

export default function Input({
  label,
  description,
  name,
  placeholder,
  type,
}: FormInputProps) {
  return (
    <Field name={name}>
      {({ field, form, meta }: FieldProps) => (
        <InputGroup>
          <Label>{label}</Label>
          <StyledInput
            {...field}
            placeholder={placeholder}
            onChange={form.handleChange}
            type={type || "text"}
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
