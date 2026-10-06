// import { useEffect, useState } from "react";
// import { GetChatPrompt } from "../../api/ChatApi/GetChatPrompt";
import "./HomePage.css";
import logo from "../../assets/random-fact.png";
import logo2 from "../../assets/chat.png";
import logo3 from "../../assets/create-user.png";

export function HomePage() {
  // const [answer, setAnswer] = useState("");

  // useEffect(() => {
  //   async function loadData() {
  //     try {
  //       const data = await GetChatPrompt();
  //       // setAnswer(data);
  //     } catch (error) {
  //       console.error("Could not load chat response:", error);
  //     }
  //   }

  //   loadData();
  // }, []);
  return (
    <div className="home">
      <div className="card-container">
        {/* Navigation to the different pages */}
        <a className="home-card chat-style-card">
          <img src={logo} alt="Logo" />

          <span className="card-title">Did you know?</span>
          <p>LLM services ....</p>
        </a>

        <a href="/Chat" className="home-card chat-style-card">
          <img id="chat-icon" src={logo2} alt="Logo" />
          <nav className="card-title">Want to Chat</nav>
          <p>You want to chat with our chatbot!</p>
        </a>

        <a href="/CreateUser" className="home-card chat-style-card">
          <img
            id="chat-icon"
            src={logo3}
            alt="Logo"
          />
          <nav className="card-title">Create User</nav>
          <p>Click here to create a new user</p>
        </a>
      </div>
    </div>
  );
}
