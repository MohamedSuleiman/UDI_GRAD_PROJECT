import { useEffect, useState } from "react";
import {
    getChatsForUser,
    type ChatSummary,
} from "../api/ChatApi/GetChats";

interface ViewChatMessagesProps {
    userId: number;
    selectedChatId: number | null;
    refreshKey: number;
    onSelectChat: (chatId: number) => void;
}

export function ViewChatMessages({
    userId,
    selectedChatId,
    refreshKey,
    onSelectChat,
}: ViewChatMessagesProps) {
    const [chats, setChats] = useState<ChatSummary[]>([]);
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState("");

    useEffect(() => {
        let isCurrent = true;

        async function loadChats() {
            setIsLoading(true);
            setError("");

            try {
                const userChats = await getChatsForUser(userId);
                if (isCurrent) setChats(userChats);
            } catch (loadError) {
                if (isCurrent) {
                    setError(loadError instanceof Error ? loadError.message : "Could not load chats.");
                }
            } finally {
                if (isCurrent) setIsLoading(false);
            }
        }

        void loadChats();
        return () => {
            isCurrent = false;
        };
    }, [userId, refreshKey]);

    return (
        <nav className="chat-history" aria-label="Previous chats">
            <h2>Recent chats</h2>
            {isLoading && <p className="chat-history-status">Loading chats...</p>}
            {error && <p className="chat-history-error" role="alert">{error}</p>}
            {!isLoading && !error && chats.length === 0 && (
                <p className="chat-history-status">No previous chats</p>
            )}
            <ul className="chat-history-list">
                {chats.map((chat) => (
                    <li key={chat.id}>
                        <button
                            type="button"
                            className={chat.id === selectedChatId ? "selected" : ""}
                            aria-current={chat.id === selectedChatId ? "page" : undefined}
                            onClick={() => onSelectChat(chat.id)}
                        >
                            <span>{chat.name || "Untitled chat"}</span>
                            <time dateTime={chat.createdAt}>
                                {new Date(chat.createdAt).toLocaleDateString()}
                            </time>
                        </button>
                    </li>
                ))}
            </ul>
        </nav>
    );
}