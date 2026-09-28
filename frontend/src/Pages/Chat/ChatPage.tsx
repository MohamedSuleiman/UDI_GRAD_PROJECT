import { Link } from "react-router-dom";
import "./ChatPage.css";
import "../Button/Button.css";

export function ChatPage() {
  return (
    <div className="chat">
      <nav>
        <Link to="/">Home</Link>{" "}
      </nav>
      <h2>Chat</h2>
      <div className="chats">
        <div className="message answer">Hello this is the return chat</div>
        <div className="message me">Hi! this is a chat message from me.</div>
        <div className="message me">
          and my chats is seen on the right side!
        </div>
      </div>
      <div className="messageInput">
        <input type="text" placeholder="Skriv en melding..." />
        <button className="mainButton"> Send</button>
      </div>
    </div>
  );
}
