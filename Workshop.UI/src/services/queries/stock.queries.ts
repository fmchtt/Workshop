import { useQuery } from "@tanstack/react-query";
import { getProducts, ProductFilters } from "../api/stock";
import { QueryProps } from "../../types/utils/queries";

type UseProductProps = {
  filters: ProductFilters;
};
export function useProducts(props?: QueryProps & UseProductProps) {
  return useQuery({
    queryKey: ["products", props?.filters || {}],
    queryFn: () => getProducts(props?.filters || {}),
    ...props,
  });
}
