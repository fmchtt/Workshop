import { ComponentPropsWithoutRef } from "react";
import styled, { css } from "styled-components";

export const StyledTable = styled.table`
  width: 100%;

  color: ${(props) => props.theme.colors.primary};
`;

export const HeadRow = styled.tr``;

export const HeadCell = styled.th`
  border-bottom: 1px solid ${(props) => props.theme.colors.primary};
  padding: 15px 0;
  font-size: ${(props) => props.theme.font.sm};
`;

type BodyRowProps = ComponentPropsWithoutRef<"tr"> & {
  $clickable?: boolean;
};
export const BodyRow = styled.tr<BodyRowProps>`
  ${(props) =>
    props.$clickable &&
    css`
      cursor: pointer;
      &:hover {
        background-color: #00000019;
      }
    `}
`;
export const BodyCell = styled.td`
  border-bottom: 1px solid ${(props) => props.theme.colors.primary};
  padding: 15px 0;
  text-align: center;
`;

export const ActionContainer = styled.div`
  width: 100%;
  height: 100%;

  display: flex;
  justify-content: center;
  align-items: center;
  gap: 10px;
`;
