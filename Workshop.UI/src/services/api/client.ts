import { Client } from "../../types/entities/client";
import { http } from "../http";

export async function getClients() {
  const { data } = await http.get<Client[]>("/clients");
  return data;
}

export type CreateClientProps = {
  name: string;
};
export async function createClient(props: CreateClientProps) {
  const { data } = await http.post<Client>("/clients", props);
  return data;
}

export type UpdateClientProps = {
  id: string;
  name?: string;
};
export async function updateClient({ id, ...props }: UpdateClientProps) {
  const { data } = await http.patch<Client>(`/clients/${id}`, props);
  return data;
}
