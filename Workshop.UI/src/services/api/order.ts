import { Order } from "../../types/entities/order";
import { http } from "../http";

export async function getOrders() {
  const { data } = await http.get<Order[]>("/orders");
  return data;
}
