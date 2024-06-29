import axios from "axios";

export const http = axios.create({
  baseURL: import.meta.env.VITE_BASE_URL || "",
});

type QueryItemParams = {
  [key: string]: string | number | boolean | Array<string | number>;
};
export function makeQueryParams(queryItems: QueryItemParams) {
  let accumulator = "?";
  Object.keys(queryItems).forEach((key, index, arr) => {
    const isLast = index === arr.length - 1;
    let value = queryItems[key];
    if (value instanceof Array) {
      value = value.join(",");
    }

    accumulator += `${key}=${value}${isLast ? "" : "&"}`;
  });

  return accumulator === "?" ? "" : accumulator;
}
