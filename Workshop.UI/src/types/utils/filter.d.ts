export type FilterProps<T> = {
  onFilter: (values: T) => void;
  onClear: () => void;
};
