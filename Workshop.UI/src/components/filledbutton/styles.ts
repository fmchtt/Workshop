import styled from "styled-components";
import { StyledButtonProps } from "./types";

export const ButtonStyle = styled.button<StyledButtonProps>`
  border: none;
  border-radius: 20px;

  height: ${(props) => props.$height || "60px"};
  padding: 10px;
  min-width: 100px;

  background-color: ${(props) =>
    props.$color === "light"
      ? props.theme.colors.secondary
      : props.theme.colors.primary};
  color: ${(props) => props.theme.colors.thernary};
  margin: ${(props) => props.$margin || "23px 0"};
  cursor: pointer;
  display: flex;
  justify-content: center;
  align-items: center;

  font-size: 1rem;

  &:hover {
    background-color: ${(props) => props.theme.colors.primary + "d1"};
  }
`;
