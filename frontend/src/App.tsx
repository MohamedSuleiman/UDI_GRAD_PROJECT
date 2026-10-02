import { BrowserRouter, Routes, Route } from "react-router-dom";
import { HomePage } from "./Pages/Home/HomePage";
import { ChatPage } from "./Pages/Chat/ChatPage";
import LoginForm from "./Pages/Login/LoginForm";
import CreateUserForm from "./Pages/CreateUser/CreateUser";
import { DropDownHeader } from "./Components/Header/Header";
import { LoginUser } from "./Api/UserApi/UserApi";

// defines the route for all the pages in the application
function App() {
  return (
    <BrowserRouter>
      {/* Dropdown Header - Visible on all pages!*/}
      <DropDownHeader />

      <Routes>
        {/* Home Page*/}
        <Route path="/" element={<HomePage />} />

        {/* Chat Page*/}
        <Route path="/Chat" element={<ChatPage />} />

        {/* Login Page - logs all the submitted data for now*/}
        <Route
          path="/Login"
          element={
            <LoginForm
              onLoginSubmit={async (values) => {
                try {
                  await LoginUser(values.email, values.password);
                  alert("Login successful!");
                } catch (error) {
                  alert("Login failed! Please check your credentials.");
                }
              }}
            />
          }
        />
        {/* Create User Page - logs all the submitted data for now*/}
        <Route
          path="/CreateUser"
          element={
            <CreateUserForm onCreated={(values) => console.log(values)} />
          }
        />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
