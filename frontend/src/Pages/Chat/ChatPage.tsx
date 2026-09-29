import { Link } from "react-router-dom";
import "./ChatPage.css";
import "../../index.css";
import { MyForm } from "../Form/MyForm";
import { useState } from "react";
import { type Props, PostPromt } from "../../api/ChatApi/GetChatPrompt";

/* Displays the chat page with messages and a message input */
export function ChatPage() {
  const [response, setResponse] = useState("");
    async function handleSend(e: React.SubmitEvent<HTMLFormElement>) {
        e.preventDefault();
        const form = e.target;
        const formData = new FormData(form);
        const sendR: Props = {
            url: "http://localhost:5065/chat",
            dataValues: {
            UserID: Number(formData.get("UserID")),
            Content: [String(formData.get("Content"))],
}
        };
        const data = await PostPromt(sendR);
        setResponse(data);
        console.log(response)
    }
  return (
    <div className="chat">
      <nav>
        {/* Navigating back to the Home Page */}
        <Link to="/">Home</Link>{" "}
      </nav>
      <h2>Chat</h2>
      {"Her er svare" + response}
      {/* Displays the chat messages */}
      <div className="chats">
        <div className="message me">Hi! this is a chat message from me.</div>
        <div className="message answer">Hello this is the return chat</div>
        <div className="message me">
          and my chats is seen on the right side!
        </div>
      </div>

      {/* Input field for writing and sending a new message */}
      <MyForm func={handleSend}/>

    </div>
  );
}
