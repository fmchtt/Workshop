import { useMutation, useQueryClient } from "@tanstack/react-query";
import {
  createOrder,
  CreateOrderProps,
  deleteOrder,
  updateOrder,
  UpdateOrderProps,
} from "../api/order";
import { MutationProps } from "../../types/utils/mutation";
import { Order } from "../../types/entities/order";
import { produce } from "immer";
import { Message } from "../../types/valueObjects/message";

export function useCreateOrderMutation(
  props?: MutationProps<Order, CreateOrderProps>
) {
  const Order = useQueryClient();

  return useMutation({
    mutationFn: createOrder,
    onSuccess: (data, variables) => {
      Order.setQueryData(
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
  const Order = useQueryClient();

  return useMutation({
    mutationFn: updateOrder,
    onSuccess: (data, variables) => {
      Order.setQueryData(
        ["orders"],
        produce<Order[]>((draft) => {
          const OrderIdx = draft.findIndex((x) => x.id === data.id);
          if (OrderIdx === -1) return;
          draft[OrderIdx] = data;
        })
      );
      props?.onSuccess && props.onSuccess(data, variables);
    },
    onError: props?.onError && props.onError,
  });
}

export function useDeleteOrderMutation(props?: MutationProps<Message, string>) {
  const Order = useQueryClient();

  return useMutation({
    mutationFn: deleteOrder,
    onSuccess: (data, variables) => {
      Order.setQueryData(
        ["orders"],
        produce<Order[]>((draft) => {
          const OrderIdx = draft.findIndex((x) => x.id === variables);
          if (OrderIdx === -1) return;
          draft.splice(OrderIdx, 1);
        })
      );
      props?.onSuccess && props.onSuccess(data, variables);
    },
    onError: props?.onError && props.onError,
  });
}
