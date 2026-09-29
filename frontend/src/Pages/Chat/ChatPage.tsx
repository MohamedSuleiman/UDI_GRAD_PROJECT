import { Link } from "react-router-dom";
import "./ChatPage.css";
import "../../index.css";

/* Displays the chat page with messages and a message input */
export function ChatPage() {
  return (
    <div className="chat">
      <nav>
        {/* Navigating back to the Home Page */}
        <Link to="/">Home</Link>{" "}
      </nav>
      <h2>Chat</h2>

      {/* Displays the chat messages */}
      <div className="chats">
        <div className="message me">Hi! this is a chat message from me.</div>
        <div className="message answer">Hello this is the return chat</div>
        <div className="message me">
          and my chats is seen on the right side!
        </div>
      </div>

      {/* Input field for writing and sending a new message */}
      <div className="messageInput">
        <input type="text" placeholder="Skriv en melding..." />
        <button className="mainButton"> Send</button>
      </div>
    </div>
  );
}
