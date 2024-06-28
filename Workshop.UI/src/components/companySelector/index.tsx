import { useAuth } from "../../contexts/authContext";
import { useCompanyChangeMutation } from "../../services/mutations/company.mutations";
import { useCompanies } from "../../services/queries/company.queries";
import { Select } from "../form/select";
import { Label } from "../form/styles";
import { SelectorContainer } from "./styles";

export default function CompanySelector() {
  const { data, isLoading } = useCompanies();
  const { user } = useAuth();
  const changeCompanyMutation = useCompanyChangeMutation();

  if (isLoading || (data?.length === 1 && !!user?.working)) {
    return null;
  }

  const options = data?.map((company) => ({
    label: company.name,
    value: company.id,
  }));

  return (
    <SelectorContainer>
      <Label>Selecione uma empresa para trocar</Label>
      <Select
        options={options}
        value={options?.find((c) => c.value === user?.working?.company.id)}
        isDisabled={changeCompanyMutation.isPending}
        onChange={(option) => {
          if (option) changeCompanyMutation.mutate(option.value);
        }}
      />
    </SelectorContainer>
  );
}
