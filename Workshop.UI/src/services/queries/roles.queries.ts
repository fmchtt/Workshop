import { useQuery } from "@tanstack/react-query";
import { getRole, getRoles } from "../api/roles";
import { QueryProps } from "../../types/utils/queries";

export function useRoles(props?: QueryProps) {
  return useQuery({
    queryKey: ["roles"],
    queryFn: () => getRoles(),
    ...props,
  });
}

export function useRole(roleId: string, props?: QueryProps) {
  return useQuery({
    queryKey: ["roles", roleId],
    queryFn: () => getRole(roleId),
    ...props,
  });
}
