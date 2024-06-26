import { useQuery } from "@tanstack/react-query";
import { getOrders } from "../api/order";
import { QueryProps } from "../../types/utils/queries";

export function useOrders(props?: QueryProps) {
  return useQuery({
    queryKey: ["orders"],
    queryFn: () => getOrders(),
    ...props,
  });
}
