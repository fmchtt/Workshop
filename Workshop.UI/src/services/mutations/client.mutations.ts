import { useMutation, useQueryClient } from "@tanstack/react-query";
import {
  createClient,
  CreateClientProps,
  deleteClient,
  updateClient,
  UpdateClientProps,
} from "../api/client";
import { MutationProps } from "../../types/utils/mutation";
import { Client } from "../../types/entities/client";
import { produce } from "immer";
import { Message } from "../../types/valueObjects/message";

export function useCreateClientMutation(
  props?: MutationProps<Client, CreateClientProps>
) {
  const client = useQueryClient();

  return useMutation({
    mutationFn: createClient,
    onSuccess: (data, variables) => {
      client.setQueryData(
        ["clients"],
        produce<Client[]>((draft) => {
          draft.push(data);
        })
      );
      props?.onSuccess && props.onSuccess(data, variables);
    },
    onError: props?.onError && props.onError,
  });
}

export function useUpdateClientMutation(
  props?: MutationProps<Client, UpdateClientProps>
) {
  const client = useQueryClient();

  return useMutation({
    mutationFn: updateClient,
    onSuccess: (data, variables) => {
      client.setQueryData(
        ["clients"],
        produce<Client[]>((draft) => {
          const clientIdx = draft.findIndex((x) => x.id === data.id);
          if (clientIdx === -1) return;
          draft[clientIdx] = data;
        })
      );
      props?.onSuccess && props.onSuccess(data, variables);
    },
    onError: props?.onError && props.onError,
  });
}

export function useDeleteClientMutation(
  props?: MutationProps<Message, string>
) {
  const client = useQueryClient();

  return useMutation({
    mutationFn: deleteClient,
    onSuccess: (data, variables) => {
      client.setQueryData(
        ["clients"],
        produce<Client[]>((draft) => {
          const clientIdx = draft.findIndex((x) => x.id === variables);
          if (clientIdx === -1) return;
          draft.splice(clientIdx, 1);
        })
      );
      props?.onSuccess && props.onSuccess(data, variables);
    },
    onError: props?.onError && props.onError,
  });
}
