import { Outlet, Navigate } from "react-router-dom";
import { useAuth } from "../context/AuthContext";

type ProtectedProps = {
    redirectPath: string
}

const Protected: React.FC<ProtectedProps> = ({ redirectPath = '/' }) => {
  const { authenticated } = useAuth();
  if(authenticated === undefined) {
    return null;
  }
  if (!authenticated) {
    return <Navigate to={redirectPath} />;
  }
  return <Outlet/>;
};
export default Protected;