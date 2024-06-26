import styled from "styled-components";

export const Container = styled.main`
  width: 100vw;
  height: 100vh;

  background-color: ${(props) => props.theme.colors.background};

  display: flex;
`;

export const PageWrapper = styled.div`
  height: 100%;
  display: flex;
  flex-direction: column;

  flex: 1;
`;

export const PageContainer = styled.div`
  display: flex;
  flex-direction: column;
  flex: 1;

  padding: 15px;
  overflow-y: auto;
`;

export type TextProps = {
  $size?: "sm" | "md" | "lg" | "xl";
  $color?: "primary" | "secondary" | "thernary";
  $weight?: "light" | "medium" | "bold";
};
export const Text = styled.p<TextProps>`
  font-size: ${(props) => props.theme.font[props.$size || "sm"]};
  color: ${(props) => props.theme.colors[props.$color || "primary"]};
  font-weight: ${(props) => props.theme.font.weight[props.$weight || "medium"]};
`;
