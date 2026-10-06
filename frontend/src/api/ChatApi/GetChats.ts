import axios from "axios";
const apiUrl = (
    import.meta.env.VITE_API_URL || "http://localhost:5065"
).replace(/\/$/, "");

interface Props {
    chatId: number
}

export type chatMessages = {
    id: number,
    content: string,
    response: string
}

export async function getChatMessagesForUser({chatId }: Props): Promise<chatMessages[]> {
    try {
        const listOfMessages = await axios.get(`${apiUrl}/Chat/${chatId}/messages`)
        //if (listOfMessages.status)
        console.log(listOfMessages.data)
        console.log(listOfMessages.status)

        return listOfMessages.data
    } catch(error: unknown) {
        throw error
    }
}