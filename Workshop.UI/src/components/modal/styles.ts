import styled from "styled-components";

export const StyledModal = styled.aside`
  position: absolute;
  right: 0;
  top: 0;

  padding: 20px;

  background-color: ${(props) => props.theme.colors.thernary};
  height: 100vh;
  width: 30%;

  box-shadow: -5px 0px 26px -12px rgba(0, 0, 0, 0.75);
`;
