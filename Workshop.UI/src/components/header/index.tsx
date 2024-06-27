import { FaBuilding, FaCog, FaUnlock, FaUserPlus } from "react-icons/fa";
import { useAuth } from "../../contexts/authContext";
import {
  MenuContainer,
  MenuItem,
  MenuItemContainer,
  StyledHeader,
} from "./styles";
import useDebouce from "../../hooks/useDebouce";
import { Link } from "@tanstack/react-router";
import { RxCaretLeft } from "react-icons/rx";

export default function Header() {
  const { user } = useAuth();
  const [showMenu, startTransition, isPending] = useDebouce(false, {
    time: 600,
  });

  const menuEntries = [
    {
      title: "Permissões",
      icon: <FaUnlock />,
      link: "/management/roles",
    },
    {
      title: "Colaboradores",
      icon: <FaUserPlus />,
      link: "/management/employees",
    },
    {
      title: "Editar empresa",
      icon: <FaBuilding />,
      link: "/management/company",
    },
  ];

  return (
    <StyledHeader>
      {user && (
        <h3>
          {user?.working ? user.working.company.name : "Selecione uma empresa"}
        </h3>
      )}
      {user && (
        <MenuContainer>
          {(showMenu || isPending) && (
            <>
              <MenuItemContainer className={isPending ? "closed" : ""}>
                {menuEntries.map((entry) => {
                  return (
                    <MenuItem key={entry.title} as={Link} to={entry.link}>
                      {entry.title} {entry.icon}
                    </MenuItem>
                  );
                })}
              </MenuItemContainer>
              <RxCaretLeft />
            </>
          )}
          <MenuItem onClick={() => startTransition((prev) => !prev)}>
            {user.name} <FaCog />
          </MenuItem>
        </MenuContainer>
      )}
    </StyledHeader>
  );
}
