import { createContext, useContext, useState } from "react";
import { User } from "../types/entities/user";
import { ReactNode } from "@tanstack/react-router";
import { useMe } from "../services/queries/auth.queries";
import {
  useLoginMutation,
  useRegisterMutation,
} from "../services/mutations/auth.mutations";
import { LoginProps, RegisterProps } from "../services/api/auth";
import { http } from "../services/http";
import { UseMutationResult, useQueryClient } from "@tanstack/react-query";
import { Token } from "../types/valueObjects/token";
import Spinner from "../components/spinner";
import { SpinnerContainer } from "../components/styles.global";

export type AuthContextProps = {
  user?: User;
  login: UseMutationResult<Token, Error, LoginProps, unknown>;
  register: UseMutationResult<Token, Error, RegisterProps, unknown>;
};
const authContext = createContext<AuthContextProps>({} as AuthContextProps);

export function AuthContextProvider(props: { children: ReactNode }) {
  const [authToken, setAuthToken] = useState<string | null>(getToken());

  const { data, isLoading } = useMe({ enabled: !!authToken });
  const client = useQueryClient();

  http.interceptors.response.use(
    (success) => {
      return success;
    },
    (error) => {
      if (error.response.status === 401 || error.response.status === 403) {
        setAuthToken(null);
        localStorage.removeItem("token");
        client.removeQueries();
      }

      return Promise.reject(error);
    }
  );

  const loginMutation = useLoginMutation({
    onSuccess: (data) => {
      setToken(data.accessToken);
    },
  });
  const registerMutation = useRegisterMutation({
    onSuccess: (data) => {
      setToken(data.accessToken);
    },
  });

  function setToken(token: string) {
    http.defaults.headers.common.Authorization = `Bearer ${token}`;
    localStorage.setItem("token", token);
    setAuthToken(token);
  }

  function getToken() {
    const token = localStorage.getItem("token");
    if (token) http.defaults.headers.common.Authorization = `Bearer ${token}`;
    return token;
  }

  return (
    <authContext.Provider
      value={{ user: data, login: loginMutation, register: registerMutation }}
    >
      {isLoading ? (
        <SpinnerContainer>
          <Spinner size="60px" />
        </SpinnerContainer>
      ) : (
        props.children
      )}
    </authContext.Provider>
  );
}

export function useAuth() {
  return useContext(authContext);
}
