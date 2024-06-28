import { Company } from "./company";
import { Role } from "./role";
import { ResumedUser } from "./user";

export type Employee = {
  id: "string";
  user: ResumedUser;
  role: Role;
  company: Company;
};

export type ResumedEmployee = Omit<Employee, "company">;
