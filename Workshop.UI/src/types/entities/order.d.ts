import { Client } from "./client";
import { ResumedEmployee } from "./employee";
import { Product } from "./product";

export type ProductInOrder = {
  id: string;
  quantity: number;
  product: Product;
};

export type Order = {
  id: string;
  orderNumber: number;
  products: ProductInOrder[];
  employee: ResumedEmployee;
  client: Client;
  complete: true;
};
