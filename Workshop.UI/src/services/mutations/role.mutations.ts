import { useMutation, useQueryClient } from "@tanstack/react-query";
import { MutationProps } from "../../types/utils/mutation";
import { Message } from "../../types/valueObjects/message";
import {
  createPermission,
  CreatePermissionProps,
  createRole,
  CreateRoleProps,
  deletePermission,
  DeletePermissionProps,
  deleteRole,
  updateRole,
  UpdateRoleProps,
} from "../api/roles";
import { produce } from "immer";
import { Role } from "../../types/entities/role";

export function useCreateRoleMutation(
  props?: MutationProps<Role, CreateRoleProps>
) {
  const client = useQueryClient();

  return useMutation({
    mutationFn: createRole,
    onSuccess: (data, variables) => {
      client.setQueryData(
        ["roles"],
        produce<Role[]>((draft) => {
          draft.push(data);
        })
      );

      props?.onSuccess && props.onSuccess(data, variables);
    },
    onError: props?.onError,
  });
}

export function useUpdateRoleMutation(
  props?: MutationProps<Role, UpdateRoleProps>
) {
  const client = useQueryClient();

  return useMutation({
    mutationFn: updateRole,
    onSuccess: (data, variables) => {
      client.setQueriesData(
        {
          queryKey: ["roles", {}],
          exact: true,
        },
        produce<Role[]>((draft) => {
          const roleIdx = draft.findIndex((r) => r.id === data.id);
          if (roleIdx === -1) return;
          draft[roleIdx] = data;
        })
      );

      props?.onSuccess && props.onSuccess(data, variables);
    },
    onError: props?.onError,
  });
}

export function useDeleteRoleMutation(props?: MutationProps<Message, string>) {
  const client = useQueryClient();

  return useMutation({
    mutationFn: deleteRole,
    onSuccess: (data, variables) => {
      client.setQueriesData(
        {
          queryKey: ["roles", {}],
          exact: true,
        },
        produce<Role[]>((draft) => {
          const roleIdx = draft.findIndex((r) => r.id === variables);
          if (roleIdx === -1) return;
          draft.splice(roleIdx, 1);
        })
      );

      props?.onSuccess && props.onSuccess(data, variables);
    },
    onError: props?.onError,
  });
}

export function useCreatePermissionMutation(
  props?: MutationProps<Role, CreatePermissionProps>
) {
  const client = useQueryClient();

  return useMutation({
    mutationFn: createPermission,
    onSuccess: (data, variables) => {
      client.setQueryData(
        ["roles", {}],
        produce<Role[]>((draft) => {
          const roleIdx = draft.findIndex((r) => r.id === variables.roleId);
          if (roleIdx === -1) return;
          draft[roleIdx] = data;
        })
      );

      client.setQueryData(["roles", variables.roleId], data);

      props?.onSuccess && props.onSuccess(data, variables);
    },
    onError: props?.onError,
  });
}

export function useDeletePermissionMutation(
  props?: MutationProps<Message, DeletePermissionProps>
) {
  const client = useQueryClient();

  return useMutation({
    mutationFn: deletePermission,
    onSuccess: (data, variables) => {
      client.setQueryData(
        ["roles", {}],
        produce<Role[]>((draft) => {
          const roleIdx = draft.findIndex((r) => r.id === variables.roleId);
          if (roleIdx === -1) return;
          const permissionIdx = draft[roleIdx].permissions.findIndex(
            (p) => p.type === variables.type && p.value === variables.value
          );
          if (permissionIdx === -1) return;

          draft[roleIdx].permissions.splice(permissionIdx, 1);
        })
      );

      client.setQueryData(
        ["roles", variables.roleId],
        produce<Role>((draft) => {
          const permissionIdx = draft.permissions.findIndex(
            (p) => p.type === variables.type && p.value === variables.value
          );
          if (permissionIdx === -1) return;

          draft.permissions.splice(permissionIdx, 1);
        })
      );

      props?.onSuccess && props.onSuccess(data, variables);
    },
    onError: props?.onError,
  });
}
