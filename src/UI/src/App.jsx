import "./App.css";
import React from "react";
import {
  createRoutesFromElements,
  Route,
  RouterProvider,
  Navigate,
} from "react-router-dom";
import { createBrowserRouter } from "react-router-dom";
import Home from "./pages/Player/Home";
import Login from "./pages/Player/Login";
import Register from "./pages/Player/Register";
import Profile from "./pages/Player/Profile";
import { AppContextProvider } from "./AppContext";
import PrivateRoute from "./components/PrivateRoute";
import GoogleRedirected from "./components/GoogleRedirected";
import PlayerLayout from "./layouts/Player";

const routes = createRoutesFromElements(
  <>
    <Route path="/" element={<Navigate to="/player" />} />
    <Route path="/player" element={<PlayerLayout />}>
      <Route path="" element={<Home />} />,
      <Route path="login" element={<Login />} />,
      <Route path="register" element={<Register />} />
      <Route element={<PrivateRoute requiredRole="player"/>}>
        <Route path="profile" element={<Profile />} />
      </Route>
    </Route>
    
    <Route path="/brand" element={<PlayerLayout />}>
      <Route path="" element={<Home />} />,
      <Route element={<PrivateRoute requiredRole="brand"/>}>
        <Route path="profile" element={<Profile />} />
      </Route>
    </Route>

    <Route path="/oauth2">
      <Route path="google/redirected" element={<GoogleRedirected />} />
    </Route>

  
  </>
);

const router = createBrowserRouter(routes);

function App() {
  return (
    <AppContextProvider>
      <RouterProvider router={router} />
    </AppContextProvider>
  );
}

export default App;
