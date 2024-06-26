import { useTheme } from "styled-components";
import { StyledSpinner } from "./styles";
import { SpinnerProps } from "./types";

export default function Spinner(props: SpinnerProps) {
  const theme = useTheme();

  return (
    <StyledSpinner size={props.size} viewBox="0 0 50 50">
      <circle
        className="path"
        cx="25"
        cy="25"
        r="20"
        fill="none"
        strokeWidth="4"
        stroke={props.color || theme.colors.primary}
      />
    </StyledSpinner>
  );
}
