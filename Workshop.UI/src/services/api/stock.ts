import { Product } from "../../types/entities/product";
import { Message } from "../../types/valueObjects/message";
import { http, makeQueryParams } from "../http";

export type ProductFilters = {
  name?: string;
};
export async function getProducts(filters: ProductFilters) {
  const { data } = await http.get<Product[]>(
    "/products" + makeQueryParams(filters)
  );
  return data;
}
export type CreateProductProps = {
  name: string;
  description: string;
  price: number;
  quantity: number;
};
export async function createProduct(props: CreateProductProps) {
  const { data } = await http.post<Product>("/products", props);
  return data;
}

export type UpdateProductProps = {
  id: string;
  name?: string;
  description?: string;
  price?: number;
  quantity?: number;
};
export async function updateProduct({ id, ...props }: UpdateProductProps) {
  const { data } = await http.patch<Product>(`/products/${id}`, props);
  return data;
}

export async function deleteProduct(id: string) {
  const { data } = await http.delete<Message>(`/products/${id}`);
  return data;
}
