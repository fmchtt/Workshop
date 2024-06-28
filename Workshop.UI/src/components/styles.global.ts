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
  $weight?: "light" | "medium" | "semibold" | "bold";
  $margin?: string;
};
export const Text = styled.p<TextProps>`
  font-size: ${(props) => props.theme.font[props.$size || "sm"]};
  color: ${(props) => props.theme.colors[props.$color || "primary"]};
  font-weight: ${(props) => props.theme.font.weight[props.$weight || "medium"]};
  margin: ${(props) => props.$margin || "unset"};
`;

export type DetailProps = {
  $size?: "sm" | "md" | "lg" | "xl";
  $color?: "primary" | "secondary" | "thernary";
  $weight?: "light" | "medium" | "semibold" | "bold";
  $margin?: string;
};
export const Detail = styled.span<DetailProps>`
  font-size: ${(props) => props.theme.font[props.$size || "sm"]};
  color: ${(props) => props.theme.colors[props.$color || "primary"]};
  font-weight: ${(props) => props.theme.font.weight[props.$weight || "medium"]};
`;

export const IconButton = styled.button`
  background-color: transparent;
  border: none;
  cursor: pointer;
`;

export const SpinnerContainer = styled.main`
  width: 100vw;
  height: 100vh;

  position: absolute;
  left: 0;
  top: 0;

  display: flex;
  justify-content: center;
  align-items: center;

  background-color: ${(props) => props.theme.colors.background};
`;

export const Divider = styled.hr`
  height: 1px;
  background-color: ${(props) => props.theme.colors.primary};
  margin: 15px 0;
  border: none;
`;

type RouteContainerProps = {
  $column?: boolean;
};
export const RouteContainer = styled.div<RouteContainerProps>`
  width: 100%;
  height: 100%;
  display: flex;
  gap: 20px;

  overflow-y: auto;
  flex-direction: ${(props) => (props.$column ? "column" : "row")};
`;

export const SideContainer = styled.div`
  width: 30%;
  height: 100%;

  padding: 20px;
  background-color: ${(props) => props.theme.colors.thernary};
  border-radius: ${(props) => props.theme.borderRadius};
`;

export const FlexibleContainer = styled.div`
  height: 100%;
  flex: 1;

  overflow-y: auto;

  background-color: ${(props) => props.theme.colors.thernary};
  border-radius: ${(props) => props.theme.borderRadius};
  padding: 20px;

  display: flex;
  flex-direction: column;
`;
