import { useQuery } from "@tanstack/react-query";
import { getRoles } from "../api/roles";
import { QueryProps } from "../../types/utils/queries";

export function useRoles(props?: QueryProps) {
  return useQuery({
    queryKey: ["roles"],
    queryFn: () => getRoles(),
    ...props,
  });
}
