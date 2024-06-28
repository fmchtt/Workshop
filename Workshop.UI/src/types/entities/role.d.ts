export type ResumedRole = {
  id: string;
  name: string;
};

export type Permission = {
  id: string;
  type: string;
  value: string;
};

export type Role = {
  id: string;
  name: string;
  permissions: Permission[];
};
