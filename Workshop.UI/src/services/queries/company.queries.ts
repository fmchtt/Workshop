import { useQuery } from "@tanstack/react-query";
import { QueryProps } from "../../types/utils/queries";
import { getCompanies, getCompany, getEmployees } from "../api/company";

export function useCompanies(props?: QueryProps) {
  return useQuery({
    queryKey: ["companies"],
    queryFn: () => getCompanies(),
    ...props,
  });
}

export function useCompany(props?: QueryProps) {
  return useQuery({
    queryKey: ["company"],
    queryFn: () => getCompany(),
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
