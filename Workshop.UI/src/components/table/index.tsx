import { FaEdit, FaTrash } from "react-icons/fa";
import { Text } from "../styles.global";
import {
  ActionContainer,
  BodyCell,
  BodyRow,
  HeadCell,
  HeadRow,
  StyledTable,
} from "./styles";
import { ReactNode } from "react";

type Values<T> = T[keyof T];

type ColumnDefinition<T> = Values<{
  [Key in keyof T]: {
    key: Key;
    title: string;
    parser?: (data: T[Key]) => ReactNode;
  };
}>;

type TableProps<T> = {
  columns: ColumnDefinition<T>[];
  rows: T[];
  showEdit?: boolean;
  onEdit?: (props: T) => void;
  showDelete?: boolean;
  onDelete?: (props: T) => void;
};
export function Table<T>(props: TableProps<T>) {
  return (
    <StyledTable>
      <thead>
        <HeadRow>
          {props.columns.map((column) => (
            <HeadCell key={column.key.toString()}>{column.title}</HeadCell>
          ))}
          {(props.showEdit || props.showDelete) && <HeadCell>Ações</HeadCell>}
        </HeadRow>
      </thead>
      <tbody>
        {props.rows.map((row, index) => (
          <BodyRow key={"row_" + index}>
            {props.columns.map((column) => (
              <BodyCell key={"row_" + index + column.key.toString()}>
                {column.parser ? (
                  column.parser(row[column.key])
                ) : (
                  <Text>{String(row[column.key])}</Text>
                )}
              </BodyCell>
            ))}
            {(props.showDelete || props.showEdit) && (
              <BodyCell>
                <ActionContainer>
                  {props.showEdit && (
                    <FaEdit
                      onClick={() => props.onEdit && props.onEdit(row)}
                      cursor="pointer"
                      size={18}
                    />
                  )}
                  {props.showDelete && (
                    <FaTrash
                      onClick={() => props.onDelete && props.onDelete(row)}
                      cursor="pointer"
                      size={18}
                    />
                  )}
                </ActionContainer>
              </BodyCell>
            )}
          </BodyRow>
        ))}
      </tbody>
    </StyledTable>
  );
}
