import { ResumedRole } from "./role";
import { ResumedUser } from "./user";

export type Employee = {
  id: "string";
  user: ResumedUser;
  role: ResumedRole;
};