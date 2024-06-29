import { useMutation, useQueryClient } from "@tanstack/react-query";
import { MutationProps } from "../../types/utils/mutation";
import { produce } from "immer";
import { Product } from "../../types/entities/product";
import {
  createProduct,
  CreateProductProps,
  deleteProduct,
  updateProduct,
  UpdateProductProps,
} from "../api/stock";
import { Message } from "../../types/valueObjects/message";

export function useCreateProductMutation(
  props?: MutationProps<Product, CreateProductProps>
) {
  const client = useQueryClient();

  return useMutation({
    mutationFn: createProduct,
    onSuccess: (data, variables) => {
      client.setQueryData(
        ["products", {}],
        produce<Product[]>((draft) => {
          draft.push(data);
        })
      );
      props?.onSuccess && props.onSuccess(data, variables);
    },
    onError: props?.onError && props.onError,
  });
}

export function useUpdateProductMutation(
  props?: MutationProps<Product, UpdateProductProps>
) {
  const client = useQueryClient();

  return useMutation({
    mutationFn: updateProduct,
    onSuccess: (data, variables) => {
      client.setQueryData(
        ["products", {}],
        produce<Product[]>((draft) => {
          const productIdx = draft.findIndex((x) => x.id === data.id);
          if (productIdx === -1) return;
          draft[productIdx] = data;
        })
      );
      props?.onSuccess && props.onSuccess(data, variables);
    },
    onError: props?.onError && props.onError,
  });
}

export function useDeleteProductMutation(
  props?: MutationProps<Message, string>
) {
  const client = useQueryClient();

  return useMutation({
    mutationFn: deleteProduct,
    onSuccess: (data, variables) => {
      client.setQueryData(
        ["products", {}],
        produce<Product[]>((draft) => {
          const productIdx = draft.findIndex((x) => x.id === variables);
          if (productIdx === -1) return;
          draft.splice(productIdx, 1);
        })
      );
      props?.onSuccess && props.onSuccess(data, variables);
    },
    onError: props?.onError && props.onError,
  });
}
