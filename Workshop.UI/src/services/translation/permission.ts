type TranslationDefinition = {
  name: string;
  label: string;
};
type PermissionTranslationDefinition = {
  type: TranslationDefinition;
  values: TranslationDefinition[];
};

export const permissions: PermissionTranslationDefinition[] = [
  {
    type: {
      name: "management",
      label: "Gerenciamento",
    },
    values: [
      {
        name: "manageRole",
        label: "Gerenciar cargos",
      },
      {
        name: "manageEmployee",
        label: "Gerenciar colaboradores",
      },
      {
        name: "addPermission",
        label: "Adicionar permissões",
      },
      {
        name: "manageClient",
        label: "Gerenciar cliente",
      },
      {
        name: "manageCompany",
        label: "Gerenciar empresa",
      },
    ],
  },
  {
    type: {
      name: "stock",
      label: "Estoque",
    },
    values: [
      {
        name: "manageProduct",
        label: "Gerenciar produtos",
      },
    ],
  },
  {
    type: {
      name: "service",
      label: "Serviços",
    },
    values: [{ name: "manageOrder", label: "Gerenciar ordem de serviços" }],
  },
];

export function getPermissionTranslation(type: string, value: string) {
  const typeSet = permissions.find((x) => x.type.name === type);
  if (!typeSet) return value;
  const valueSet = typeSet.values.find((x) => x.name === value);
  if (!valueSet) return value;

  return valueSet.label;
}

export function getModuleTranslation(type: string) {
  const typeSet = permissions.find((x) => x.type.name === type);
  if (!typeSet) return type;

  return typeSet.type.label;
}
