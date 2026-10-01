type Props = {
    func: (e: any) => Promise<void>
}
export function MyForm({func}: Props) {
    return (
        <form className="messageInput" onSubmit={func}>
        <input name="Content" type="text" placeholder="Skriv en melding..." />
        <input name="ChatID" type="hidden" value={2}></input>
        <button type="submit" className="mainButton"> Send</button>
        </form>
    )
}