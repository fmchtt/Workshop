import { Employee } from "./employee";

export type User = {
  id: "string";
  name: "string";
  working?: Employee;
};

export type ResumedUser = {
  id: "string";
  name: "string";
  email: "string";
};
