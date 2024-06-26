import { Company } from "../../types/entities/company";
import { ResumedEmployee } from "../../types/entities/employee";
import { User } from "../../types/entities/user";
import { http } from "../http";

export async function getCompanies() {
  const { data } = await http.get<Company[]>("/company");
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
