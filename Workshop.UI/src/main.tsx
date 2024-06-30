import { StrictMode } from "react";
import ReactDOM from "react-dom/client";
import { RouterProvider, createRouter } from "@tanstack/react-router";
import { ReactQueryDevtools } from "@tanstack/react-query-devtools";
import { routeTree } from "./routeTree.gen";
import {
  QueryClient,
  QueryClientProvider,
  useQueryClient,
} from "@tanstack/react-query";
import { defaultTheme } from "./themes";
import { ThemeProvider } from "styled-components";
import "./assets/index.css";
import {
  AuthContextProps,
  AuthContextProvider,
  useAuth,
} from "./contexts/authContext";
import "rc-switch/assets/index.css";
import "react-toastify/dist/ReactToastify.css";
import { ToastContainer } from "react-toastify";

const router = createRouter({
  routeTree,
  defaultPreload: "intent",
  context: { auth: undefined, queryClient: undefined },
});

declare module "@tanstack/react-router" {
  interface Register {
    router: typeof router;
  }
  interface RouteContext {
    auth: AuthContextProps;
    queryClient: QueryClient;
  }
}

const queryClient = new QueryClient({
  defaultOptions: {
    queries: {
      refetchOnWindowFocus: false,
    },
  },
});

export function AuthedRouter() {
  return (
    <RouterProvider
      router={router}
      context={{ auth: useAuth(), queryClient: useQueryClient() }}
    />
  );
}

const rootElement = document.getElementById("root")!;
if (!rootElement.innerHTML) {
  const root = ReactDOM.createRoot(rootElement);
  root.render(
    <StrictMode>
      <QueryClientProvider client={queryClient}>
        <ThemeProvider theme={defaultTheme}>
          <AuthContextProvider>
            <AuthedRouter />
            <ToastContainer position="bottom-right" autoClose={2000} />
          </AuthContextProvider>
        </ThemeProvider>
        <ReactQueryDevtools />
      </QueryClientProvider>
    </StrictMode>
  );
}
