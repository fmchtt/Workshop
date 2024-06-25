import Spinner from "../spinner";
import { ButtonStyle } from "./styles";
import { StyledButtonProps } from "./types";

export default function FilledButton(props: StyledButtonProps) {
  return (
    <ButtonStyle {...props} type={props.type}>
      {props.$loading ? <Spinner size={props.$size} /> : props.children}
    </ButtonStyle>
  );
}
