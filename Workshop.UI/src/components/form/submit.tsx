import FilledButton from "../filledbutton";
import { StyledButtonProps } from "../filledbutton/types";

type SubmitProps = StyledButtonProps & {
  label: string;
  $loading?: boolean;
};
export default function SubmitButton({
  label,
  $loading,
  ...props
}: SubmitProps) {
  return (
    <FilledButton
      {...props}
      $color="secondary"
      $margin="0"
      type="submit"
      $loading={$loading}
    >
      {label}
    </FilledButton>
  );
}
