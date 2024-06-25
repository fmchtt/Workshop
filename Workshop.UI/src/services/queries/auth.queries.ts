import { useQuery } from "@tanstack/react-query";
import { getMe } from "../api/auth";
import { QueryProps } from "../../types/utils/queries";

export function useMe(props?: QueryProps) {
  return useQuery({
    queryKey: ["me"],
    queryFn: () => getMe(),
    retry: false,
    ...props,
  });
}
