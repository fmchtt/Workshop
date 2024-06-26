import { useAuth } from "../../contexts/authContext";
import { useCompanyChangeMutation } from "../../services/mutations/company.mutations";
import { useCompanies } from "../../services/queries/company.queries";
import { Label, StyledSelect } from "../form/styles";
import { SelectorContainer } from "./styles";

export default function CompanySelector() {
  const { data, isLoading } = useCompanies();
  const { user } = useAuth();
  const changeCompanyMutation = useCompanyChangeMutation();

  if (isLoading || data?.length === 1) {
    return null;
  }

  return (
    <SelectorContainer>
      <Label>Selecione uma empresa para trocar</Label>
      <StyledSelect
        onChange={(e) => {
          e.preventDefault();
          const companyId = e.target.value;
          changeCompanyMutation.mutate(companyId);
        }}
        value={user?.working?.company.id}
        disabled={changeCompanyMutation.isPending}
      >
        {data?.map((company) => {
          return (
            <option key={company.id} value={company.id}>
              {company.name}
            </option>
          );
        })}
      </StyledSelect>
    </SelectorContainer>
  );
}
