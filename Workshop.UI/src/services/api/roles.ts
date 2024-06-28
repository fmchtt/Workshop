import { Role } from "../../types/entities/role";
import { http } from "../http";

export async function getRoles() {
  const { data } = await http.get<Role[]>("/roles");
  return data;
}

export type CreateRoleProps = {
  name: string;
};
export async function createRole(props: CreateRoleProps) {
  const { data } = await http.post<Role>("/roles", props);
  return data;
}

export type UpdateRoleProps = {
  id: string;
  name?: string;
};
export async function updateRole({ id, ...props }: UpdateRoleProps) {
  const { data } = await http.patch<Role>(`/roles/${id}`, props);
  return data;
}
