import Spinner from "../spinner";
import { SpinnerContainer } from "../styles.global";

type SpinnerContainerProps = {
  $fullWindow?: boolean;
};
export default function PendingComponent(props: SpinnerContainerProps) {
  return (
    <SpinnerContainer $fullWindow={props.$fullWindow}>
      <Spinner size="60px" />
    </SpinnerContainer>
  );
}
