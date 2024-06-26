import { Client } from "../../types/entities/client";
import { http } from "../http";

export async function getClients() {
  const { data } = await http.get<Client[]>("/clients");
  return data;
}
