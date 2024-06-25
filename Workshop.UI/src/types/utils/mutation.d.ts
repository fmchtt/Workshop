export type MutationProps<TData, TVariables> = {
  onSuccess?: (data: TData, variables: TVariables) => void;
  onError?: () => void;
};
