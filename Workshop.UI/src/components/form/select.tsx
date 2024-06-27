import { Field, FieldProps } from "formik";
import { Description, ErrorMessage, InputGroup, Label } from "./styles";
import { FormInputProps } from "../../types/valueObjects/form";
import RSelect, { GroupBase, Props as RSelectProps } from "react-select";
import { useTheme } from "styled-components";

type Option = {
  label: string;
  value: string | number;
};

type SelectProps = {
  options: Option[];
};

export default function FieldSelect({
  label,
  description,
  name,
  options,
}: FormInputProps & SelectProps) {
  return (
    <Field name={name}>
      {({ field, form, meta }: FieldProps) => (
        <InputGroup>
          <Label>{label}</Label>
          <Select
            {...field}
            options={options}
            value={field.value && options.find((x) => x.value === field.value)}
            onChange={(option) => form.setFieldValue(field.name, option?.value)}
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

export function Select<
  Option,
  IsMulti extends boolean = false,
  Group extends GroupBase<Option> = GroupBase<Option>,
>(props: RSelectProps<Option, IsMulti, Group>) {
  const theme = useTheme();

  return (
    <RSelect
      {...props}
      placeholder="Escolher"
      styles={{
        control: (base) => ({
          ...base,
          padding: "5px",
          fontSize: theme.font.sm,
          border: `1px solid ${theme.colors.primary + "51"}`,
        }),
        menu: (base) => ({
          ...base,
          fontSize: theme.font.sm,
        }),
      }}
      theme={(style) => ({
        ...style,
        borderRadius: 20,
        colors: {
          ...style.colors,
          primary: theme.colors.primary,
          primary25: theme.colors.primary + "40",
          primary50: theme.colors.primary + "7F",
          primary75: theme.colors.primary + "C0",
        },
      })}
    />
  );
}
