import { useMutation, useQueryClient } from "@tanstack/react-query";
import { User } from "../../types/entities/user";
import { MutationProps } from "../../types/utils/mutation";
import {
  changeCompany,
  updateCompany,
  UpdateCompanyProps,
} from "../api/company";
import { Company } from "../../types/entities/company";
import { produce } from "immer";

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

export function useUpdateCompanyMutation(
  props?: MutationProps<Company, UpdateCompanyProps>
) {
  const client = useQueryClient();

  return useMutation({
    mutationFn: updateCompany,
    onSuccess: (data, variables) => {
      client.setQueryData(
        ["companies"],
        produce<Company[]>((draft) => {
          const companyIdx = draft.findIndex((x) => x.id === data.id);
          if (companyIdx === -1) return;
          draft[companyIdx] = data;
        })
      );

      client.setQueryData(["company"], data);

      client.setQueryData(
        ["me"],
        produce<User>((draft) => {
          if (!draft.working) return;
          draft.working.company = data;
        })
      );
      props?.onSuccess && props.onSuccess(data, variables);
    },
    onError: props?.onError,
  });
}
