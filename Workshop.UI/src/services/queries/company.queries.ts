import { useQuery } from "@tanstack/react-query";
import { QueryProps } from "../../types/utils/queries";
import { getCompanies, getEmployees } from "../api/company";

export function useCompanies(props?: QueryProps) {
  return useQuery({
    queryKey: ["companies"],
    queryFn: () => getCompanies(),
    ...props,
  });
}

export function useEmployees(props?: QueryProps) {
  return useQuery({
    queryKey: ["employees"],
    queryFn: () => getEmployees(),
    ...props,
  });
}
