import { FaCog } from "react-icons/fa";
import { useAuth } from "../../contexts/authContext";
import { StyledHeader, UserWrapper } from "./styles";

export default function Header() {
  const { user } = useAuth();

  return (
    <StyledHeader>
      {user && (
        <UserWrapper>
          {user.name} <FaCog />
        </UserWrapper>
      )}
    </StyledHeader>
  );
}
