import FilledButton from "../filledbutton";
import Modal from "../modal";
import { Text } from "../styles.global";
import { ConfirmationWrapper } from "./styles";

type ConfirmationModalProps = {
  title: string;
  text: string;
  show: boolean;
  $loading?: boolean;
  onSuccess: () => void;
  onClose: () => void;
};
export default function ConfirmationModal(props: ConfirmationModalProps) {
  return (
    <Modal show={props.show} hideClose={true}>
      <ConfirmationWrapper>
        <Text $size="lg" $weight="bold">
          {props.title}
        </Text>
        <Text $size="md">{props.text}</Text>
        <FilledButton
          $loading={props.$loading}
          $margin="0"
          $color="danger"
          onClick={props.onSuccess}
        >
          Confirmar
        </FilledButton>
        <FilledButton
          $loading={props.$loading}
          $margin="0"
          $color="primary"
          onClick={props.onClose}
        >
          Cancelar
        </FilledButton>
      </ConfirmationWrapper>
    </Modal>
  );
}
