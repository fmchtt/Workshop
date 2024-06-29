import { useQuery } from "@tanstack/react-query";
import { getOrder, getOrders, OrderFilters } from "../api/order";
import { QueryProps } from "../../types/utils/queries";

type UseOrderProps = {
  filters: OrderFilters;
};
export function useOrders(props?: QueryProps & UseOrderProps) {
  return useQuery({
    queryKey: ["orders", props?.filters || {}],
    queryFn: () => getOrders(props?.filters || {}),
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
