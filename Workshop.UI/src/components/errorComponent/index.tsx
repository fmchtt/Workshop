import { ErrorComponentProps } from "@tanstack/react-router";
import { useEffect } from "react";

export default function ErrorPage(props: ErrorComponentProps) {
  useEffect(() => {
    console.error(props.error);
  }, [props.error]);

  return <p>Error</p>;
}
