import styled from "styled-components";
import { HEADER_SIZE } from "../header/styles";

export const StyledSidebar = styled.aside`
  width: 180px;
  height: 100%;

  background-color: ${(props) => props.theme.colors.secondary};
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  align-items: center;

  color: ${(props) => props.theme.colors.thernary};
`;

export const Logo = styled.div`
  width: 100%;
  height: ${HEADER_SIZE};

  display: flex;
  align-items: center;
  justify-content: center;

  text-decoration: none;
  color: inherit;
`;

export const ModulesWrapper = styled.div`
  width: 100%;
`;

export const ModuleButton = styled.a`
  display: flex;
  justify-content: center;
  align-items: center;
  gap: 10px;
  width: 100%;
  padding: 10px;
  color: ${(props) => props.theme.colors.thernary};
  text-decoration: none;
  font-size: ${(props) => props.theme.font.md};

  &.active {
    background-color: #ffffff40;
  }

  &:hover {
    background-color: #ffffff21;
  }
`;
