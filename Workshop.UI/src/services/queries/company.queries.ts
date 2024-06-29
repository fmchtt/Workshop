import { useQuery } from "@tanstack/react-query";
import { QueryProps } from "../../types/utils/queries";
import {
  EmployeeFilters,
  getCompanies,
  getCompany,
  getEmployees,
} from "../api/company";

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

type UseEmployeeProps = {
  filters: EmployeeFilters;
};
export function useEmployees(props?: QueryProps & UseEmployeeProps) {
  return useQuery({
    queryKey: ["employees", props?.filters || {}],
    queryFn: () => getEmployees(props?.filters || {}),
    ...props,
  });
}
