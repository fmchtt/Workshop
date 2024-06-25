import { useMutation } from "@tanstack/react-query";
import { login, LoginProps, register, RegisterProps } from "../api/auth";
import { MutationProps } from "../../types/utils/mutation";
import { Token } from "../../types/valueObjects/token";

export function useLoginMutation(props?: MutationProps<Token, LoginProps>) {
  return useMutation({
    mutationFn: login,
    onSuccess: props?.onSuccess,
    onError: props?.onError,
  });
}

export function useRegisterMutation(
  props?: MutationProps<Token, RegisterProps>
) {
  return useMutation({
    mutationFn: register,
    onSuccess: props?.onSuccess,
    onError: props?.onError,
  });
}
