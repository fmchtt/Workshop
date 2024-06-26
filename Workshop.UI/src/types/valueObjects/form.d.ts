export type FormInputProps = {
  label: string;
  name: string;
  description?: string;
  placeholder?: string;
  type?: "number" | "text" | "email";
  isClearable?: boolean;
};
