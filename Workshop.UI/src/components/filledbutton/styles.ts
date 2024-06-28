import styled from "styled-components";
import { StyledButtonProps } from "./types";

export const ButtonStyle = styled.button<StyledButtonProps>`
  border: none;
  border-radius: ${(props) => props.theme.borderRadius};

  padding: 12px;
  min-width: 100px;

  background-color: ${(props) => props.theme.colors[props.$color || "primary"]};
  color: ${(props) => props.theme.colors.thernary};
  margin: ${(props) => props.$margin || "23px 0"};
  cursor: pointer;
  display: flex;
  gap: 8px;
  justify-content: center;
  align-items: center;

  font-size: ${(props) => props.theme.font.sm};

  &:hover {
    background-color: ${(props) => props.theme.colors.primary + "d1"};
  }

  &:disabled {
    cursor: not-allowed;
    background-color: ${(props) => props.theme.colors.primary + "d1"};
  }
`;
