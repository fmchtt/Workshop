import styled from "styled-components";

export const Container = styled.main`
  width: 100vw;
  height: 100vh;

  background-color: ${(props) => props.theme.colors.background};

  display: flex;
`;

export const PageWrapper = styled.div`
  height: 100%;
  flex: 1;
`;

export const PageContainer = styled.div`
  padding: 15px;
  flex: 1;

  overflow-y: auto;
`;
