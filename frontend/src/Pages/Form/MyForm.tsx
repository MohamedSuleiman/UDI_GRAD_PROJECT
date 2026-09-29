import { data } from "react-router";
import {PostPromt} from "../../api/ChatApi/GetChatPrompt"

export function MyForm() {
    function handleSend(e) {
        e.preventDefault();
        const form = e.target;
        const formData = new FormData(form);
        const values = Object.fromEntries(formData.entries());
        const json = JSON.stringify(values);
        PostPromt(json)

    }
    return (
        <form className="messageInput" action={handleSend}>
        <input name="content" type="text" placeholder="Skriv en melding..." />
        <input name="chatId" type="hidden" value={1}></input>
        <button type="submit" className="mainButton"> Send</button>
        </form>
    )
}