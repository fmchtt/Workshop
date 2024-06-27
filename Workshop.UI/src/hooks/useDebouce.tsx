import { useRef, useState } from "react";

type Updater<T> = (value: T) => T;
type DebouceProps = {
  time?: number;
};

export default function useDebouce<T>(
  initialValue: T,
  props: DebouceProps
): [T, (value: T | Updater<T>) => void, boolean] {
  const [state, setState] = useState(initialValue);
  const [pending, setPending] = useState(false);
  const ref = useRef<number | undefined>();

  function startDebouce(updater: T | Updater<T>) {
    if (ref.current !== undefined) {
      clearTimeout(ref.current);
    }

    setPending(true);
    ref.current = setTimeout(() => {
      setState(updater);
      setPending(false);
    }, props?.time || 1000);
  }

  return [state, startDebouce, pending];
}
