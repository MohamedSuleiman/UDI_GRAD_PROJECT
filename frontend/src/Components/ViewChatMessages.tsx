import { getChatMessagesForUser } from "../api/ChatApi/GetChats";
import { useEffect, useState } from "react";
import {type chatMessages} from "../api/ChatApi/GetChats"


export  function ViewChatMessages() {
    const [result, setResult] = useState<chatMessages[]>([])
     useEffect(() => {
            async function getChatMessages() {
                const messages = await getChatMessagesForUser({chatId: 2})
                setResult(messages)
            }
            getChatMessages();
    },[])

    return (
        <ul>
            {result.map(res => <li key={`${res.id}`}>{}{res.content}</li>)}
        </ul>
    )
}