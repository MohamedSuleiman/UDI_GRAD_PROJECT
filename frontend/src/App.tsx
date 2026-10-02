import { BrowserRouter, Routes, Route } from "react-router-dom";
import { HomePage } from "./Pages/Home/HomePage";
import { ChatPage } from "./Pages/Chat/ChatPage";
import LoginPage from "./Pages/Login/LoginPage";
import { DropDownHeader } from "./Components/Header/Header";
import CreateUserPage from "./Pages/createUserPage/CreateUserPage";

function App() {
  return (
    <BrowserRouter>
      <DropDownHeader />

      <Routes>
        <Route path="/" element={<HomePage />} />

        <Route path="/Chat" element={<ChatPage />} />

        <Route path="/Login" element={<LoginPage />} />

        <Route
          path="/CreateUser"
          element={<CreateUserPage />}
        />
      </Routes>
    </BrowserRouter>
  );
}

export default App;