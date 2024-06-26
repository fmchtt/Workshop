import { FaEdit, FaTrash } from "react-icons/fa";
import { IconButton, Text } from "../styles.global";
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
  actionsDisabled?: boolean;
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
                    <IconButton
                      onClick={() => props.onEdit && props.onEdit(row)}
                      disabled={props.actionsDisabled}
                    >
                      <FaEdit size={18} />
                    </IconButton>
                  )}
                  {props.showDelete && (
                    <IconButton
                      onClick={() => props.onDelete && props.onDelete(row)}
                      disabled={props.actionsDisabled}
                    >
                      <FaTrash size={18} />
                    </IconButton>
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
