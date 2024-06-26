import { FaCog } from "react-icons/fa";
import { useAuth } from "../../contexts/authContext";
import { StyledHeader, UserWrapper } from "./styles";

export default function Header() {
  const { user } = useAuth();

  return (
    <StyledHeader>
      {user && (
        <h3>
          {user?.working ? user.working.company.name : "Selecione uma empresa"}
        </h3>
      )}
      {user && (
        <UserWrapper>
          {user.name} <FaCog />
        </UserWrapper>
      )}
    </StyledHeader>
  );
}
