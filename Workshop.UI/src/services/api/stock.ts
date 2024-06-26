import { Product } from "../../types/entities/product";
import { http } from "../http";

export async function getProducts() {
  const { data } = await http.get<Product[]>("/products");
  return data;
}
