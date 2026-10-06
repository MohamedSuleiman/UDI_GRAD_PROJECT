import axios from "axios";
const apiUrl = (
    import.meta.env.VITE_API_URL || "http://localhost:5065"
).replace(/\/$/, "");

interface Props {
    chatId: number
}

export type ChatSummary = {
    id: number;
    name: string;
    createdAt: string;
};

export type chatMessages = {
    id: number,
    chatId: number,
    content: string,
    response: string,
    role: string,
    createdAt: string
}

export async function getChatsForUser(userId: number): Promise<ChatSummary[]> {
    const response = await axios.get<ChatSummary[]>(`${apiUrl}/Chat/user/${userId}`);
    return response.data;
}

export async function getChatMessagesForUser({chatId }: Props): Promise<chatMessages[]> {
    try {
        const response = await axios.get<chatMessages[]>(`${apiUrl}/Chat/${chatId}/messages`)
        return response.data ?? []
    } catch(error: unknown) {
        throw error
    }
}