import { Link } from "@tanstack/react-router";
import { Logo, ModuleButton, ModulesWrapper, StyledSidebar } from "./styles";
import { FaBoxes, FaUser, FaWrench } from "react-icons/fa";
import { useAuth } from "../../contexts/authContext";
import { Text } from "../styles.global";
import { useMemo } from "react";

export default function Sidebar() {
  const { user } = useAuth();

  const modules = useMemo(() => {
    return [
      {
        name: "Estoque",
        icon: <FaBoxes />,
        link: "/stock",
        show:
          user?.id === user?.working?.company.ownerId ||
          !!user?.working?.role.permissions.find(
            (p) => p.type === "stock" && p.value === "manageProduct"
          ),
      },
      {
        name: "Serviços",
        icon: <FaWrench />,
        link: "/order",
        show:
          user?.id === user?.working?.company.ownerId ||
          !!user?.working?.role.permissions.find(
            (p) => p.type === "service" && p.value === "manageOrder"
          ),
      },
      {
        name: "Clientes",
        icon: <FaUser />,
        link: "/customer",
        show:
          user?.id === user?.working?.company.ownerId ||
          !!user?.working?.role.permissions.find(
            (p) => p.type === "management" && p.value === "manageClient"
          ),
      },
    ];
  }, [user]);

  return (
    <StyledSidebar>
      <Logo as={Link} to="/home">
        <Text $size="lg" $color="thernary" $weight="bold">
          Workshop
        </Text>
      </Logo>
      <ModulesWrapper>
        {user?.working &&
          modules
            .filter((m) => m.show)
            .map((m) => (
              <ModuleButton key={m.name} as={Link} to={m.link}>
                {m.icon}
                {m.name}
              </ModuleButton>
            ))}
      </ModulesWrapper>
      <div></div>
    </StyledSidebar>
  );
}
