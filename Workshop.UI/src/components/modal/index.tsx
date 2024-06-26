import { ComponentPropsWithoutRef } from "react";
import { createPortal } from "react-dom";
import { StyledModal } from "./styles";

type ModalProps = {
  show: boolean;
};
export default function Modal(
  props: ComponentPropsWithoutRef<"div"> & ModalProps
) {
  if (props.show)
    return createPortal(
      <StyledModal>{props.children}</StyledModal>,
      document.body
    );
  return null;
}
