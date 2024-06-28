import { useTheme } from "styled-components";
import Spinner from "../spinner";
import { ButtonStyle } from "./styles";
import { StyledButtonProps } from "./types";

export default function FilledButton(props: StyledButtonProps) {
  const theme = useTheme();

  return (
    <ButtonStyle {...props} type={props.type}>
      {props.$loading ? (
        <Spinner color={theme.colors.thernary} size={props.$size} />
      ) : (
        props.children
      )}
    </ButtonStyle>
  );
}
