import { useEffect, useState } from "react";
import { GetChatPrompt } from "../../api/ChatApi/GetChatPrompt";
import "./HomePage.css";

export function HomePage() {
  const [answer, setAnswer] = useState("");

  useEffect(() => {
    async function loadData() {
      try {
        const data = await GetChatPrompt();
        setAnswer(data);
      } catch (error) {
        console.error("Could not load chat response:", error);
      }
    }

    loadData();
  }, []);
  return (
    <div className="home">
      <h2>Welcome to ...</h2>

      <h3> This is the chat: </h3>
      <p> {answer}</p>

      {/* Navigation to the different pages */}
      <a href="/Chat" id="chat">
        <img id="chat-icon" src="../../src/assets/chat.png" alt="Logo" />
        <nav id="chattext">Want to Chat</nav>
        <p>You want to chat with our chatbot!</p>
      </a>
      <h3>Please Login or Create user to continue</h3>
      <a href="/Login">
        <button className="mainButton">Login</button>
      </a>
      <a href="/CreateUser">
        <button className="mainButton">Create User</button>
      </a>
    </div>
  );
}
