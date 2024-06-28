import { Company } from "../../types/entities/company";
import { ResumedEmployee } from "../../types/entities/employee";
import { User } from "../../types/entities/user";
import { http } from "../http";

export async function getCompanies() {
  const { data } = await http.get<Company[]>("/company");
  return data;
}

export async function getCompany() {
  const { data } = await http.get<Company>("/company/active");
  return data;
}

export async function changeCompany(companyId: string) {
  const { data } = await http.post<User>(`/company/change/${companyId}`);
  return data;
}

export async function getEmployees() {
  const { data } = await http.get<ResumedEmployee[]>("/company/employee");
  return data;
}

export type UpdateCompanyProps = {
  companyId: string;
  name?: string;
};
export async function updateCompany({
  companyId,
  ...props
}: UpdateCompanyProps) {
  const { data } = await http.patch<Company>(`/company/${companyId}`, props);
  return data;
}
