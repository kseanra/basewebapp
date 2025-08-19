import { type RouteConfig, index, route } from "@react-router/dev/routes";
import Upload from "./pages/upload";

export default [
  index("routes/home.tsx"),
  route("upload", "./pages/upload.tsx")
] satisfies RouteConfig;
