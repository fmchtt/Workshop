import { useNavigate } from "@tanstack/react-router";
import { useCallback } from "react";
import { useAuth } from "../contexts/authContext";

type Permission = {
  type: string;
  value: string;
};
type UsePermissionProps = Permission[];
export default function usePermissions() {
  const navigate = useNavigate();
  const { user } = useAuth();

  return useCallback(
    (props: UsePermissionProps) => {
      if (!user?.working) return true;

      if (user.working.company.ownerId === user.id) {
        return false;
      }

      for (const permission of props) {
        if (
          !user.working.role.permissions.find(
            (p) => p.type === permission.type && p.value === permission.value
          )
        ) {
          navigate({
            to: "/",
          });
          return true;
        }
      }

      return false;
    },
    [user, navigate]
  );
}
