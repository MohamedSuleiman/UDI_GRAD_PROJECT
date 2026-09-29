type Props = {
    func: (e: any) => Promise<void>
}
export function MyForm({func}: Props) {
    return (
        <form className="messageInput" onSubmit={func}>
        <input name="content" type="text" placeholder="Skriv en melding..." />
        <input name="chatId" type="hidden" value={1}></input>
        <button type="submit" className="mainButton"> Send</button>
        </form>
    )
}