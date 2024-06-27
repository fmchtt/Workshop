import styled from "styled-components";

type ContainerProps = {
  $column?: boolean;
};
export const OrderContainer = styled.div<ContainerProps>`
  width: 100%;
  height: 100%;
  display: flex;
  gap: 20px;

  overflow-y: auto;
  flex-direction: ${(props) => (props.$column ? "column" : "row")};
`;

export const InformationContainer = styled.div`
  margin: 15px 0;
  display: grid;
  grid-template-columns: 1fr 1fr;
`;

type FooterContainerProps = {
  $justifyBetween?: boolean;
};
export const FooterContainer = styled.div<FooterContainerProps>`
  display: flex;
  gap: 10px;

  justify-content: ${(props) =>
    props.$justifyBetween ? "space-between" : "unset"};
`;
