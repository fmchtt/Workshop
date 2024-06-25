import styled from "styled-components";
import { HEADER_SIZE } from "../header/styles";

export const Container = styled.div`
  display: flex;
  width: 100%;
  height: calc(100vh - ${HEADER_SIZE});

  background-color: ${(props) => props.theme.colors.background};
`;

export const FormContainer = styled.div`
  width: 300px;
  height: 100%;
  padding: 20px;

  background-color: ${(props) => props.theme.colors.secondary};
`;
