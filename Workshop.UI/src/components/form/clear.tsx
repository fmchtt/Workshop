import FilledButton from "../filledbutton";
import { StyledButtonProps } from "../filledbutton/types";

type SubmitProps = StyledButtonProps & {
  label: string;
  $loading?: boolean;
};
export default function ClearButton({
  label,
  $loading,
  ...props
}: SubmitProps) {
  return (
    <FilledButton
      {...props}
      $margin="0"
      $color="primary"
      type="reset"
      $loading={$loading}
    >
      {label}
    </FilledButton>
  );
}
