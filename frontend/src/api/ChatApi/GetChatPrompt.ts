import axios from "axios";

const apiUrl = (
    import.meta.env.VITE_API_URL || "http://localhost:5065"
).replace(/\/$/, "");

export interface Chat {
    id: number;
    name: string;
    userId: number;
}

export interface ChatMessage {
    id: number;
    chatId: number;
    content: string;
    response: string | null;
}

export interface Props {
    url: string;
    dataValues: {
        ChatID: number;
        Content: string[];
    };
};

export async function CreateChat( userId: number, name: string): Promise<Chat> {
    const response = await axios.post<Chat>(
        `${apiUrl}/Chat/create`,
        {
            name,
            userId,
        }
    );

    return response.data;
}

export async function PostPromt({url, dataValues}: Props): Promise<ChatMessage> {
    const response = await axios.post<ChatMessage>(
        url,
        dataValues
    );

    return response.data;
}

export async function GetChatMessages(
    chatId: number
): Promise<ChatMessage[]> {
    const response = await axios.get<ChatMessage[]>(
        `${apiUrl}/Chat/${chatId}/messages`
    );

    return response.data;
}

// Kept for existing imports.
// Your shown controller needs a GET /Chat action for this to work.
export async function GetChatPrompt(): Promise<string> {
    const response = await axios.get<string>(`${apiUrl}/Chat`);

    return response.data;
}