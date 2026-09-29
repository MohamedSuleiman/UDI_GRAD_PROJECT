import axios from "axios"

export async function GetChatPrompt(): Promise<string> {
    const response = await axios.get<string>("http://localhost:5065/chat");
    console.log(response.data)
    return response.data;


}