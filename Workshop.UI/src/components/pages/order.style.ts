import styled from "styled-components";

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
