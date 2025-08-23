import { type RouteConfig, index, layout, prefix, route } from "@react-router/dev/routes";

// export default [
//   index("routes/home.tsx"),
//   route("upload", "./pages/upload.tsx"),
//   route("login", "./pages/login.tsx"),
//   layout("routes/root.tsx"),
// ] satisfies RouteConfig;

export default [
  layout("./routes/layout.tsx", [
    index("routes/login.tsx")
  ]),
  layout("./pages/layout.tsx", [
      route("home","pages/home.tsx"),
      route("settings", "./pages/settings.tsx"),
      route("profile", "./pages/profile.tsx"),
      route("sign-out", "./pages/sign-out.tsx")
    ])
 ] satisfies RouteConfig;