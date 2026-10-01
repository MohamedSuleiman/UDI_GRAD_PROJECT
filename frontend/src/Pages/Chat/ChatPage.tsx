
import "./ChatPage.css";
import "../../index.css";
import { MyForm } from "../Form/MyForm";
import { useState } from "react";
import { type Props, PostPromt } from "../../api/ChatApi/GetChatPrompt";


/* Displays the chat page with messages and a message input */
const apiUrl = import.meta.env.VITE_API_URL;
export function ChatPage() {
  const [response, setResponse] = useState("");
  async function handleSend(e: React.SubmitEvent<HTMLFormElement>) {
    e.preventDefault();
    const form = e.target;
    const formData = new FormData(form);
    const localUrl = "http://localhost:5065";
    const sendR: Props = {
      url: `${apiUrl}/chat`,
      dataValues: {
        ChatID: Number(formData.get("ChatID")),
        Content: [String(formData.get("Content"))],
      },
    };
    const data = await PostPromt(sendR);
    setResponse(data);
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
