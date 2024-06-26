import styled from "styled-components";

export const StyledTable = styled.table`
  width: 100%;
`;

export const HeadRow = styled.tr``;

export const HeadCell = styled.th`
  border-bottom: 1px solid ${(props) => props.theme.colors.primary};
  padding: 15px 0;
`;

export const BodyRow = styled.tr``;
export const BodyCell = styled.td`
  border-bottom: 1px solid ${(props) => props.theme.colors.primary};
  padding: 15px 0;
`;

export const ActionContainer = styled.div`
  width: 100%;
  height: 100%;

  display: flex;
  justify-content: center;
  align-items: center;
  gap: 10px;
`;
