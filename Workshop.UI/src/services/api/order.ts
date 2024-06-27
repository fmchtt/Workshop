import { Order, ProductInOrder } from "../../types/entities/order";
import { Message } from "../../types/valueObjects/message";
import { http } from "../http";

export async function getOrders() {
  const { data } = await http.get<Order[]>("/orders");
  return data;
}

export async function getOrder(orderId: string) {
  const { data } = await http.get<Order>(`/orders/${orderId}`);
  return data;
}

export type CreateOrderProps = {
  employeeId: string;
  clientId: string;
};
export async function createOrder(props: CreateOrderProps) {
  const { data } = await http.post<Order>("/orders", props);
  return data;
}

export type UpdateOrderProps = {
  id: string;
  employeeId?: string;
  clientId?: string;
};
export async function updateOrder({ id, ...props }: UpdateOrderProps) {
  const { data } = await http.patch<Order>(`/orders/${id}`, props);
  return data;
}

export async function deleteOrder(id: string) {
  const { data } = await http.delete<Message>(`/orders/${id}`);
  return data;
}

export type AddProductProps = {
  orderId: string;
  productId: string;
  quantity: number;
};
export async function addProduct({ orderId, ...props }: AddProductProps) {
  const { data } = await http.post<ProductInOrder>(
    `/orders/${orderId}/product`,
    props
  );
  return data;
}

export async function concludeOrder(orderId: string) {
  const { data } = await http.post<Order>(`/orders/${orderId}/complete`);
  return data;
}
