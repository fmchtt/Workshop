import { User } from "../../types/entities/user";
import { Token } from "../../types/valueObjects/token";
import { http } from "../http";

export async function getMe() {
  const { data } = await http.get<User>("/auth/me");
  return data;
}

export type LoginProps = {
  email: string;
  password: string;
};
export async function login(properties: LoginProps) {
  const { data } = await http.post<Token>("/auth/login", properties);
  return data;
}

export type RegisterProps = LoginProps & {
  name: string;
};
export async function register(properties: RegisterProps) {
  const { data } = await http.post<Token>("/auth/register", properties);
  return data;
}
