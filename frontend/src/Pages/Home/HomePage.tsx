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
      <a href="/Chat">
        <button className="mainButton" id="chat">
          Chat
        </button>
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
