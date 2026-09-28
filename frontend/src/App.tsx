import { BrowserRouter, Routes, Route } from "react-router-dom";
import { HomePage } from "./Pages/Home/HomePage";
import { ChatPage } from "./Pages/Chat/ChatPage";
import LoginForm from "./Pages/Login/LoginForm";
import CreateUserForm from "./Pages/CreateUser/CreateUser";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/Chat" element={<ChatPage />} />
        <Route
          path="/Login"
          element={
            <LoginForm onLoginSubmit={(values) => console.log(values)} />
          }
        />
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
