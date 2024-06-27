import styled from "styled-components";

export const HEADER_SIZE = "80px";

export const StyledHeader = styled.header`
  width: 100%;
  height: ${HEADER_SIZE};

  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 0 20px;

  background-color: ${(props) => props.theme.colors.thernary};
  color: ${(props) => props.theme.colors.primary};
`;

export const MenuContainer = styled.div`
  display: flex;
  align-items: center;
  height: 100%;
  gap: 15px;
`;

export const MenuItemContainer = styled.div`
  display: flex;
  align-items: center;
  height: 100%;
  gap: 15px;
  transition: 0.8s;
  opacity: 1;

  &.closed {
    opacity: 0;
  }
`;

export const MenuItem = styled.a`
  display: flex;
  justify-content: center;
  align-items: center;
  gap: 15px;
  height: 60%;
  padding: 0 25px;
  cursor: pointer;
  text-decoration: none;
  color: ${(props) => props.theme.colors.primary};

  background-color: #00000009;
  border-radius: ${(props) => props.theme.borderRadius};

  &.active {
    background-color: #00000040;
  }

  &:hover {
    background-color: #00000019;
  }
`;
