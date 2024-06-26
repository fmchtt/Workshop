import styled from "styled-components";

export const SelectorContainer = styled.div`
  display: flex;
  flex-direction: column;
  gap: 10px;
  width: fit-content;
  margin: 30px 0;
  padding: 20px;
  border-radius: ${(props) => props.theme.borderRadius};
  background-color: ${(props) => props.theme.colors.thernary};
`;
