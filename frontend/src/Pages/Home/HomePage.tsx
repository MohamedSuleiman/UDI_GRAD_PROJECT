export function HomePage() {
  return (
    <div className="home">
      <h2>Welcome to ...</h2>
      <a href="/Chat">
        <button>Chat</button>
      </a>
      <h3>Please Login or Create user to continue</h3>
      <a href="/Login">
        <button>Login</button>
      </a>
      <a href="/CreateUser">
        <button>Create User</button>
      </a>
    </div>
  );
}
