import { BrowserRouter, Routes, Route, Link } from "react-router-dom";
import { HomePage } from "../Home/HomePage";
export function ChatPage() {

  return (
    <div className="chat">
      <nav>
        <Link to="/">Home</Link>{" "}
      </nav>
      <h2>Welcome to chatpage</h2>
      <h3>....</h3>
    </div>
  );
}
