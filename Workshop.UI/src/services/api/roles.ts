import { Role } from "../../types/entities/role";
import { Message } from "../../types/valueObjects/message";
import { http } from "../http";

export async function getRoles() {
  const { data } = await http.get<Role[]>("/roles");
  return data;
}

export async function getRole(roleId: string) {
  const { data } = await http.get<Role>(`/roles/${roleId}`);
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

export async function getPermissions() {
  const { data } = await http.patch<Role>("/roles/permission");
  return data;
}

export async function deleteRole(roleId: string) {
  const { data } = await http.delete<Message>(`/roles/${roleId}`);
  return data;
}

export type CreatePermissionProps = {
  roleId: string;
  type: string;
  value: string;
};
export async function createPermission({
  roleId,
  ...props
}: CreatePermissionProps) {
  const { data } = await http.post<Role>(`/roles/${roleId}/permission`, props);
  return data;
}

export type DeletePermissionProps = {
  roleId: string;
  type: string;
  value: string;
};
export async function deletePermission({
  roleId,
  ...props
}: DeletePermissionProps) {
  const { data } = await http.post<Message>(
    `/roles/${roleId}/permission/remove`,
    props
  );
  return data;
}
