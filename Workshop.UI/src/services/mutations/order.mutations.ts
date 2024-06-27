import { useMutation, useQueryClient } from "@tanstack/react-query";
import {
  addProduct,
  AddProductProps,
  concludeOrder,
  createOrder,
  CreateOrderProps,
  deleteOrder,
  updateOrder,
  UpdateOrderProps,
} from "../api/order";
import { MutationProps } from "../../types/utils/mutation";
import { Order, ProductInOrder } from "../../types/entities/order";
import { produce } from "immer";
import { Message } from "../../types/valueObjects/message";

export function useCreateOrderMutation(
  props?: MutationProps<Order, CreateOrderProps>
) {
  const client = useQueryClient();

  return useMutation({
    mutationFn: createOrder,
    onSuccess: (data, variables) => {
      client.setQueryData(
        ["orders"],
        produce<Order[]>((draft) => {
          draft.push(data);
        })
      );
      props?.onSuccess && props.onSuccess(data, variables);
    },
    onError: props?.onError && props.onError,
  });
}

export function useUpdateOrderMutation(
  props?: MutationProps<Order, UpdateOrderProps>
) {
  const client = useQueryClient();

  return useMutation({
    mutationFn: updateOrder,
    onSuccess: (data, variables) => {
      client.setQueryData(
        ["orders"],
        produce<Order[]>((draft) => {
          const orderIdx = draft.findIndex((x) => x.id === data.id);
          if (orderIdx === -1) return;
          draft[orderIdx] = data;
        })
      );
      props?.onSuccess && props.onSuccess(data, variables);
    },
    onError: props?.onError && props.onError,
  });
}

export function useDeleteOrderMutation(props?: MutationProps<Message, string>) {
  const client = useQueryClient();

  return useMutation({
    mutationFn: deleteOrder,
    onSuccess: (data, variables) => {
      client.setQueryData(
        ["orders"],
        produce<Order[]>((draft) => {
          const orderIdx = draft.findIndex((x) => x.id === variables);
          if (orderIdx === -1) return;
          draft.splice(orderIdx, 1);
        })
      );
      props?.onSuccess && props.onSuccess(data, variables);
    },
    onError: props?.onError && props.onError,
  });
}

export function useAddProductOrderMutation(
  props?: MutationProps<ProductInOrder, AddProductProps>
) {
  const client = useQueryClient();

  return useMutation({
    mutationFn: addProduct,
    onSuccess: (data, variables) => {
      client.setQueryData(
        ["orders"],
        produce<Order[]>((draft) => {
          const orderIdx = draft.findIndex((x) => x.id === variables.orderId);
          if (orderIdx === -1) return;
          draft[orderIdx].products.push(data);
        })
      );

      client.setQueryData(
        ["orders", variables.orderId],
        produce<Order>((draft) => {
          const productIdx = draft.products.findIndex(
            (p) => p.product.id === variables.productId
          );
          if (productIdx === -1) {
            draft.products.push(data);
            return;
          }

          draft.products[productIdx] = data;
        })
      );
      props?.onSuccess && props.onSuccess(data, variables);
    },
    onError: props?.onError && props.onError,
  });
}

export function useConcludeOrderMutation(props?: MutationProps<Order, string>) {
  const client = useQueryClient();

  return useMutation({
    mutationFn: concludeOrder,
    onSuccess: (data, variables) => {
      client.setQueryData(
        ["orders"],
        produce<Order[]>((draft) => {
          const orderIdx = draft.findIndex((x) => x.id === variables);
          if (orderIdx === -1) return;
          draft[orderIdx] = data;
        })
      );

      client.setQueryData(["orders", variables], data);

      props?.onSuccess && props.onSuccess(data, variables);
    },
    onError: props?.onError && props.onError,
  });
}
