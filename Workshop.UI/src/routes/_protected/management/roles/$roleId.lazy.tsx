import { createLazyFileRoute } from "@tanstack/react-router";
import {
  Detail,
  FlexibleContainer,
  RouteContainer,
  Text,
} from "../../../../components/styles.global";
import { useRole } from "../../../../services/queries/roles.queries";
import { permissions } from "../../../../services/translation/permission";
import {
  ModuleContainer,
  PermissionContainer,
  PermissionGroup,
} from "../../../../components/pages/role.style";
import { Switch } from "../../../../components/form/switch";
import PendingComponent from "../../../../components/pendingComponent";
import {
  useCreatePermissionMutation,
  useDeletePermissionMutation,
} from "../../../../services/mutations/role.mutations";
import { Helmet } from "react-helmet";
import { toast } from "react-toastify";

export const Route = createLazyFileRoute(
  "/_protected/management/roles/$roleId"
)({
  component: AddPermissions,
});

export function AddPermissions() {
  const params = Route.useParams();
  const { data, isLoading } = useRole(params.roleId);

  const createMutation = useCreatePermissionMutation({
    onSuccess: () => {
      toast.success("Permissão adicionada!");
    },
  });
  const deleteMutation = useDeletePermissionMutation({
    onSuccess: () => {
      toast.success("Permissão removida!");
    },
  });

  if (!data || isLoading) {
    return <PendingComponent />;
  }

  return (
    <RouteContainer>
      <FlexibleContainer $gap="20px">
        <Helmet>
          <title>Permissões - {data.name}</title>
        </Helmet>
        <Text $size="md" $weight="semibold">
          Permissões do cargo{" "}
          <Detail $weight="bold" $size="md">
            {data.name}
          </Detail>
        </Text>
        {permissions.map((m, moduleIdx) => {
          return (
            <ModuleContainer key={"module_" + moduleIdx}>
              <Text $weight="semibold" $size="md">
                {m.type.label}
              </Text>
              <PermissionContainer>
                {m.values.map((p, permissionIdx) => (
                  <PermissionGroup
                    key={"module_" + moduleIdx + "_permission_" + permissionIdx}
                  >
                    <Switch
                      defaultChecked={
                        !!data.permissions.find(
                          (x) => x.type === m.type.name && x.value === p.name
                        )
                      }
                      onChange={(value) =>
                        value
                          ? createMutation.mutate({
                              roleId: data.id,
                              type: m.type.name,
                              value: p.name,
                            })
                          : deleteMutation.mutate({
                              roleId: data.id,
                              type: m.type.name,
                              value: p.name,
                            })
                      }
                    />
                    <Text>{p.label}</Text>
                  </PermissionGroup>
                ))}
              </PermissionContainer>
            </ModuleContainer>
          );
        })}
      </FlexibleContainer>
    </RouteContainer>
  );
}
