import { ComponentPropsWithoutRef } from "react";
import { defaultTheme } from "../../themes";

export type StyledButtonProps = ComponentPropsWithoutRef<"button"> &
  FilledButtonProps;

export interface FilledButtonProps {
  $loading?: boolean;
  $size?: string;
  disabled?: boolean;
  type?: "button" | "reset" | "submit" | undefined;
  $margin?: string;
  $height?: string;
  $color?: keyof typeof defaultTheme.colors;
}
