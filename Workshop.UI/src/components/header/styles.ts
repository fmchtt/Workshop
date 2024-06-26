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

export const UserWrapper = styled.div`
  display: flex;
  justify-content: center;
  align-items: center;
  gap: 15px;
  height: 60%;
  padding: 0 25px;
  cursor: pointer;

  background-color: #00000009;
  border-radius: ${(props) => props.theme.borderRadius};

  &:hover {
    background-color: #00000019;
  }
`;
