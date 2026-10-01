
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
        ChatID: Number(formData.get("ChatID")),
        Content: [String(formData.get("Content"))],
      },
    };
    const data = await PostPromt(sendR);
    setResponse(data);
    console.log(response);
  }
  return (
    <div className="chat">
      <h2>Chat</h2>
      <div>
        <h3>Svaret på promt</h3>
        <p>{response}</p>
      </div>

      {/* Input field for writing and sending a new message */}
      <MyForm func={handleSend} />
    </div>
  );
}
