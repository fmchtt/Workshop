import { useMutation, useQueryClient } from "@tanstack/react-query";
import { User } from "../../types/entities/user";
import { MutationProps } from "../../types/utils/mutation";
import {
  changeCompany,
  createEmployee,
  CreateEmployeeProps,
  deleteEmployee,
  updateCompany,
  UpdateCompanyProps,
} from "../api/company";
import { Company } from "../../types/entities/company";
import { produce } from "immer";
import { ResumedEmployee } from "../../types/entities/employee";
import { Message } from "../../types/valueObjects/message";

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

      setCompanyUserWorking(client, data);
      props?.onSuccess && props.onSuccess(data, variables);
    },
    onError: props?.onError,
  });
}

export function useCreateEmployeeMutation(
  props?: MutationProps<ResumedEmployee, CreateEmployeeProps>
) {
  const client = useQueryClient();

  return useMutation({
    mutationFn: createEmployee,
    onSuccess: (data, variables) => {
      client.setQueryData(
        ["employees"],
        produce<ResumedEmployee[]>((draft) => {
          draft.push(data);
        })
      );
      props?.onSuccess && props.onSuccess(data, variables);
    },
    onError: props?.onError,
  });
}

export function useDeleteEmployeeMutation(
  props?: MutationProps<Message, string>
) {
  const client = useQueryClient();

  return useMutation({
    mutationFn: deleteEmployee,
    onSuccess: (data, variables) => {
      client.setQueryData(
        ["employees"],
        produce<ResumedEmployee[]>((draft) => {
          const employeeIdx = draft.findIndex((x) => x.id === variables);
          if (employeeIdx === -1) return;
          draft.splice(employeeIdx, 1);
        })
      );
      props?.onSuccess && props.onSuccess(data, variables);
    },
    onError: props?.onError,
  });
}
