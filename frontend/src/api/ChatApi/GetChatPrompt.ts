import axios from "axios"

export type Props = {
    url: string,
    dataValues: {
        ChatID: number,
        Content: string []
    }
}

type responseToPostPromt = {
    Response: string;
}
export async function GetChatPrompt(): Promise<string> {
    const response = await axios.get<string>("http://localhost:5065/chat");
    console.log(response.data)
    return response.data;
}

export async function PostPromt({url, dataValues}:Props) {
    const response = await axios({
        method: 'post',
        url: `${url}`,
        data: dataValues
    });
    return response.data.Response;
}
