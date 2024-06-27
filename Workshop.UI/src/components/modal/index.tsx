import { ComponentPropsWithoutRef } from "react";
import { createPortal } from "react-dom";
import { StyledModal } from "./styles";
import { FaX } from "react-icons/fa6";
import { IconButton } from "../styles.global";

type ModalProps = {
  show: boolean;
  hideClose?: boolean;
  onClose?: () => void;
};
export default function Modal(
  props: ComponentPropsWithoutRef<"div"> & ModalProps
) {
  if (props.show)
    return createPortal(
      <StyledModal>
        {props.hideClose !== true && (
          <IconButton>
            <FaX onClick={props.onClose} />
          </IconButton>
        )}
        {props.children}
      </StyledModal>,
      document.body
    );
  return null;
}
