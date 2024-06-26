import { Company } from "../../types/entities/company";
import { ResumedEmployee } from "../../types/entities/employee";
import { User } from "../../types/entities/user";
import { Message } from "../../types/valueObjects/message";
import { http, makeQueryParams } from "../http";

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

export type EmployeeFilters = {
  name?: string;
  email?: string;
};
export async function getEmployees(filters: EmployeeFilters) {
  const { data } = await http.get<ResumedEmployee[]>(
    "/company/employee" + makeQueryParams(filters)
  );
  return data;
}

export type CreateEmployeeProps = {
  name: string;
  email: string;
  roleId: string;
};
export async function createEmployee(props: CreateEmployeeProps) {
  const { data } = await http.post<ResumedEmployee>("/company/employee", props);
  return data;
}

export async function deleteEmployee(employeeId: string) {
  const { data } = await http.delete<Message>(
    `/company/employee/${employeeId}`
  );
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

export type CreateCompanyProps = {
  name?: string;
};

export async function createCompany(props: CreateCompanyProps) {
  const { data } = await http.post<Company>(`/company/`, props);
  return data;
}
