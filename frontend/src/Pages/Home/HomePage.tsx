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
      <div className="card-container">
        {/* Navigation to the different pages */}
        <a className="home-card chat-style-card">
          <img
            id="chat-icon"
            src="../../src/assets/random-fact.png"
            alt="fact-icon"
          />
          <span className="card-title">Did you know?</span>
          <p>LLM services ....</p>
        </a>

        <a href="/Chat" className="home-card chat-style-card">
          <img id="chat-icon" src="../../src/assets/chat.png" alt="Logo" />
          <nav className="card-title">Want to Chat</nav>
          <p>You want to chat with our chatbot!</p>
        </a>

        <a href="/CreateUser" className="home-card chat-style-card">
          <img
            id="chat-icon"
            src="../../src/assets/create-user.png"
            alt="Logo"
          />
          <nav className="card-title">Create User</nav>
          <p>Click here to create a new user</p>
        </a>
      </div>
    </div>
  );
}
