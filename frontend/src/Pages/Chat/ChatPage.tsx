import "./ChatPage.css";
import "../../index.css";
import axios from "axios";
import { useRef, useState } from "react";
import type { FormEvent } from "react";
import { Link, useLocation } from "react-router-dom";
import {
  CreateChat,
  PostPromt,
} from "../../api/ChatApi/GetChatPrompt";

const apiUrl = (
  import.meta.env.VITE_API_URL || "http://localhost:5065"
).replace(/\/$/, "");

interface ChatPageState {
  user?: {
    id: number;
  };
}

interface DisplayMessage {
  key: number;
  content: string;
  response: string | null;
  error?: string;
}

function getErrorMessage(error: unknown): string {
  if (axios.isAxiosError(error)) {
    const data = error.response?.data;

    if (typeof data === "string") {
      return data;
    }

    return (
      data?.detail ||
      data?.message ||
      data?.title ||
      error.message
    );
  }

  return error instanceof Error
    ? error.message
    : "Failed to send message";
}

export function ChatPage() {
  const location = useLocation();
  const state = location.state as ChatPageState | null;
  const userId = state?.user?.id;

  const [chatId, setChatId] = useState<number | null>(null);
  const [prompt, setPrompt] = useState("");
  const [messages, setMessages] = useState<DisplayMessage[]>([]);
  const [isSending, setIsSending] = useState(false);

  const sendingRef = useRef(false);
  const nextMessageKey = useRef(0);

  async function handleSend(
    event: FormEvent<HTMLFormElement>
  ): Promise<void> {
    event.preventDefault();

    const content = prompt.trim();

    if (
      !content ||
      !Number.isInteger(userId) ||
      !userId ||
      userId <= 0 ||
      sendingRef.current
    ) {
      return;
    }

    sendingRef.current = true;
    setIsSending(true);

    const messageKey = nextMessageKey.current++;

    // Display the question before waiting for Ollama.
    setMessages((previous) => [
      ...previous,
      {
        key: messageKey,
        content,
        response: null,
      },
    ]);

    setPrompt("");

    try {
      let currentChatId = chatId;

      // First Send creates the chat for the logged-in user.
      if (currentChatId === null) {
        const chat = await CreateChat(
          userId,
          content.slice(0, 50)
        );

        if (!Number.isInteger(chat.id) || chat.id <= 0) {
          throw new Error("The backend returned an invalid chat ID.");
        }

        currentChatId = chat.id;
        setChatId(chat.id);
      }

      // Later Sends use the same chat ID.
      const result = await PostPromt({
        url: `${apiUrl}/Chat`,
        dataValues: {
          ChatID: currentChatId,
          Content: [content],
        },
      });

      setMessages((previous) =>
        previous.map((message) =>
          message.key === messageKey
            ? {
              ...message,
              response: result.response,
            }
            : message
        )
      );
    } catch (error) {
      setMessages((previous) =>
        previous.map((message) =>
          message.key === messageKey
            ? {
              ...message,
              error: getErrorMessage(error),
            }
            : message
        )
      );
    } finally {
      sendingRef.current = false;
      setIsSending(false);
    }
  }

  function handleNewChat() {
    setChatId(null);
    setMessages([]);
    setPrompt("");
  }

  if (
    !Number.isInteger(userId) ||
    !userId ||
    userId <= 0
  ) {
    return (
      <div className="chat">
        <p>Please log in before starting a chat.</p>
        <Link to="/Login">Go to login</Link>
      </div>
    );
  }

  return (
    <div className="chat">
      <h2>Chat</h2>

      <button
        type="button"
        onClick={handleNewChat}
        disabled={isSending}
      >
        New chat
      </button>

      <div aria-live="polite">
        {messages.map((message) => (
          <div key={message.key}>
            <p>
              <strong>You:</strong> {message.content}
            </p>

            {message.error ? (
              <p role="alert">{message.error}</p>
            ) : message.response !== null ? (
              <p style={{ whiteSpace: "pre-wrap" }}>
                <strong>AI:</strong> {message.response}
              </p>
            ) : (
              <p>Waiting for response...</p>
            )}
          </div>
        ))}
      </div>

      <form onSubmit={handleSend}>
        <label htmlFor="Content">Your message</label>

        <textarea
          id="Content"
          name="Content"
          value={prompt}
          onChange={(event) => setPrompt(event.target.value)}
          placeholder="Write your question..."
          disabled={isSending}
          required
        />

        <button
          className="mainButton"
          type="submit"
          disabled={isSending || !prompt.trim()}
        >
          {isSending ? "Sending..." : "Send"}
        </button>
      </form>
    </div>
  );
}