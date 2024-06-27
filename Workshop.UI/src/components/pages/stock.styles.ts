import styled from "styled-components";

export const StockContainer = styled.div`
  width: 100%;
  height: 100%;
  display: flex;
  gap: 20px;

  overflow-y: auto;
`;

export const FormContainer = styled.div`
  width: 30%;
  height: 100%;

  padding: 20px;
  background-color: ${(props) => props.theme.colors.thernary};
  border-radius: ${(props) => props.theme.borderRadius};
`;

export const TableContainer = styled.div`
  height: 100%;
  flex: 1;

  overflow-y: auto;

  background-color: ${(props) => props.theme.colors.thernary};
  border-radius: ${(props) => props.theme.borderRadius};
  padding: 20px;

  display: flex;
  flex-direction: column;
`;
