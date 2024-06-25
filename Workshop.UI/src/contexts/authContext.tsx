import { createContext, useContext, useEffect, useState } from "react";
import { User } from "../types/entities/user";
import { ReactNode } from "@tanstack/react-router";
import { useMe } from "../services/queries/auth.queries";
import {
  useLoginMutation,
  useRegisterMutation,
} from "../services/mutations/auth.mutations";
import { LoginProps, RegisterProps } from "../services/api/auth";
import { http } from "../services/http";
import { UseMutationResult } from "@tanstack/react-query";
import { Token } from "../types/valueObjects/token";

export type AuthContextProps = {
  user?: User;
  login: UseMutationResult<Token, Error, LoginProps, unknown>;
  register: UseMutationResult<Token, Error, RegisterProps, unknown>;
};
const authContext = createContext<AuthContextProps>({} as AuthContextProps);

export function AuthContextProvider(props: { children: ReactNode }) {
  const [authToken, setAuthToken] = useState<string | undefined>();

  const { data } = useMe({ enabled: !!authToken });

  const loginMutation = useLoginMutation({
    onSuccess: (data) => {
      http.defaults.headers.common.Authorization = `Bearer ${data.accessToken}`;
      setAuthToken(data.accessToken);
    },
  });
  const registerMutation = useRegisterMutation({
    onSuccess: (data) => {
      http.defaults.headers.common.Authorization = `Bearer ${data.accessToken}`;
      setAuthToken(data.accessToken);
    },
  });

  useEffect(() => {
    if (authToken) {
      http.defaults.headers.common.Authorization = `Bearer ${authToken}`;
    } else {
      http.defaults.headers.common.Authorization = undefined;
    }
  }, [authToken]);

  return (
    <authContext.Provider
      value={{ user: data, login: loginMutation, register: registerMutation }}
    >
      {props.children}
    </authContext.Provider>
  );
}

export function useAuth() {
  return useContext(authContext);
}
