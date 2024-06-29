import { Client } from "../../types/entities/client";
import { Message } from "../../types/valueObjects/message";
import { http, makeQueryParams } from "../http";

export type ClientFilters = {
  name?: string;
};
export async function getClients(filters: ClientFilters) {
  const { data } = await http.get<Client[]>(
    "/clients" + makeQueryParams(filters)
  );
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

export async function deleteClient(id: string) {
  const { data } = await http.delete<Message>(`/clients/${id}`);
  return data;
}
