import { useQuery } from "@tanstack/react-query";
import { ClientFilters, getClients } from "../api/client";
import { QueryProps } from "../../types/utils/queries";

type UseClientProps = {
  filters: ClientFilters;
};
export function useClients(props?: QueryProps & UseClientProps) {
  return useQuery({
    queryKey: ["clients", props?.filters || {}],
    queryFn: () => getClients(props?.filters || {}),
    ...props,
  });
}
