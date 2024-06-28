import { ComponentPropsWithoutRef } from "react";
import styled from "styled-components";

type InputGroupProps = {
  $centralized?: boolean;
  $row?: boolean;
  $gap?: number;
};
export const InputGroup = styled.div<InputGroupProps>`
  position: relative;
  display: flex;
  flex: 1;
  align-items: ${(props) => (props.$centralized ? "center" : "unset")};
  flex-direction: ${(props) => (props.$row ? "row" : "column")};
  gap: ${(props) => (props.$gap ? props.$gap + "px" : "2px")};

  .eye {
    position: absolute;
    top: 40px;
    right: 20px;
    font-size: 25px;
    color: ${(props) => props.theme.colors.primary};
    cursor: pointer;
  }
`;

type ColorProps = {
  $color?: "primary" | "secondary" | "thernary";
};
export const Title = styled.h2`
  color: ${(props) => props.theme.colors.primary};
  font-size: ${(props) => props.theme.font.md};
  font-weight: ${(props) => props.theme.font.weight.semibold};
  text-align: center;
`;

export const Label = styled.label<ColorProps>`
  color: ${(props) => props.theme.colors[props.$color || "primary"]};
  font-size: ${(props) => props.theme.font.sm};
  font-weight: ${(props) => props.theme.font.weight.medium};
`;

export const Description = styled.span`
  color: ${(props) => props.theme.colors.primary};
  font-size: 14px;
  font-weight: 100;
`;

export const ErrorMessage = styled.span`
  color: #e65555;
  font-weight: 400;
  font-size: 15px;
`;

export type FormProps = {
  width?: string;
  title?: string;
};
export const FormContainer = styled.form<FormProps>`
  width: ${(props) => props.width || "100%"};

  gap: 10px;
  display: flex;
  flex-direction: column;
  justify-content: center;
`;

type InputProps = ComponentPropsWithoutRef<"input"> & {
  flexible?: boolean;
};
export const StyledInput = styled.input<InputProps>`
  color: ${(props) => props.theme.colors.primary};

  &::placeholder {
    color: ${(props) => props.theme.colors.primary + "61"};
  }

  outline: none;

  border: 1px solid ${(props) => props.theme.colors.primary + "51"};
  border-radius: 20px;

  padding: 13px 25px;

  ${(props) => (props.flexible ? "flex: 1;" : "")}
`;

export const StyledSelect = styled.select`
  background-color: ${(props) => props.theme.colors.background};
  color: ${(props) => props.theme.colors.primary};

  &::placeholder {
    color: ${(props) => props.theme.colors.primary + "61"};
  }

  outline: none;

  border: none;
  border-radius: 20px;

  padding: 13px 25px;
`;

export const StyledTextArea = styled.textarea`
  color: ${(props) => props.theme.colors.primary};

  &::placeholder {
    color: ${(props) => props.theme.colors.primary + "61"};
  }

  outline: none;

  border: 1px solid ${(props) => props.theme.colors.primary + "51"};
  border-radius: 20px;

  padding: 13px 25px;
`;
