import { useQuery } from "@tanstack/react-query";
import { getOrder, getOrders } from "../api/order";
import { QueryProps } from "../../types/utils/queries";

export function useOrders(props?: QueryProps) {
  return useQuery({
    queryKey: ["orders"],
    queryFn: () => getOrders(),
    ...props,
  });
}

export function useOrder(orderId: string, props?: QueryProps) {
  return useQuery({
    queryKey: ["orders", orderId],
    queryFn: () => getOrder(orderId),
    ...props,
  });
}
