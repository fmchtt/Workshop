import { Link } from "@tanstack/react-router";
import { Logo, ModuleButton, ModulesWrapper, StyledSidebar } from "./styles";
import { FaBoxes, FaRegUser, FaWrench } from "react-icons/fa";

export default function Sidebar() {
  const modules = [
    {
      name: "Estoque",
      icon: <FaBoxes />,
      link: "/stock",
    },
    {
      name: "Serviços",
      icon: <FaWrench />,
      link: "/order",
    },
    {
      name: "Clientes",
      icon: <FaRegUser />,
      link: "/customer",
    },
  ];

  return (
    <StyledSidebar>
      <Logo as={Link} to="/home">
        <h1>Workshop</h1>
      </Logo>
      <ModulesWrapper>
        {modules.map((m) => (
          <ModuleButton key={m.name} as={Link} to={m.link}>
            {m.icon}
            {m.name}
          </ModuleButton>
        ))}
      </ModulesWrapper>
      <ModuleButton>Sair</ModuleButton>
    </StyledSidebar>
  );
}
