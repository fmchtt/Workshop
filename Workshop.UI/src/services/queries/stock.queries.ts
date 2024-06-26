import { useQuery } from "@tanstack/react-query";
import { getProducts } from "../api/stock";
import { QueryProps } from "../../types/utils/queries";

export function useProducts(props?: QueryProps) {
  return useQuery({
    queryKey: ["products"],
    queryFn: () => getProducts(),
    ...props,
  });
}
