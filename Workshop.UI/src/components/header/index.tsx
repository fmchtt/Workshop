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
import { useMemo } from "react";

export default function Header() {
  const { user } = useAuth();
  const [showMenu, startTransition, isPending] = useDebouce(false, {
    time: 600,
  });

  const menuEntries = useMemo(
    () => [
      {
        title: "Permissões",
        icon: <FaUnlock />,
        link: "/management/roles",
        show:
          user?.working?.company.ownerId === user?.id ||
          !!user?.working?.role.permissions.find(
            (p) => p.type === "management" && p.value === "manageRole"
          ),
      },
      {
        title: "Colaboradores",
        icon: <FaUserPlus />,
        link: "/management/employees",
        show:
          user?.working?.company.ownerId === user?.id ||
          !!user?.working?.role.permissions.find(
            (p) => p.type === "management" && p.value === "manageEmployee"
          ),
      },
      {
        title: "Editar empresa",
        icon: <FaBuilding />,
        link: "/management/company",
        show:
          user?.working?.company.ownerId === user?.id ||
          !!user?.working?.role.permissions.find(
            (p) => p.type === "management" && p.value === "manageCompany"
          ),
      },
    ],
    [user]
  );

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
                {menuEntries
                  .filter((e) => e.show)
                  .map((entry) => {
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
