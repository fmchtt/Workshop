import Spinner from "../spinner";
import { SpinnerContainer } from "../styles.global";

export default function PendingComponent() {
  return (
    <SpinnerContainer>
      <Spinner size="60px" />
    </SpinnerContainer>
  );
}
