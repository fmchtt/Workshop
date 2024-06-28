import styled from "styled-components";

export const ModuleContainer = styled.div`
  display: flex;
  flex-direction: column;
`;

export const PermissionContainer = styled.div`
  display: grid;
  grid-template-columns: 1fr 1fr 1fr 1fr;
  gap: 10px;
  margin: 2px 0;
`;

export const PermissionGroup = styled.div`
  display: flex;
  gap: 10px;
`;
