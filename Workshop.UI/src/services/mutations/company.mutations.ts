import { useMutation, useQueryClient } from "@tanstack/react-query";
import { User } from "../../types/entities/user";
import { MutationProps } from "../../types/utils/mutation";
import { changeCompany } from "../api/company";

export function useCompanyChangeMutation(props?: MutationProps<User, string>) {
  const client = useQueryClient();

  return useMutation({
    mutationFn: changeCompany,
    onSuccess: (data, variables) => {
      client.setQueryData(["me"], data);
      props?.onSuccess && props.onSuccess(data, variables);
    },
    onError: props?.onError,
  });
}
