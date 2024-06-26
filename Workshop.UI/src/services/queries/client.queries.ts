import { useQuery } from "@tanstack/react-query";
import { getClients } from "../api/client";
import { QueryProps } from "../../types/utils/queries";

export function useClients(props?: QueryProps) {
  return useQuery({
    queryKey: ["clients"],
    queryFn: () => getClients(),
    ...props,
  });
}
