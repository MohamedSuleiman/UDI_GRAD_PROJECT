import "./HomePage.css";

export function HomePage() {
  return (
    <div className="home">
      <h2>Welcome to ...</h2>

      {/* Navigation to the different pages */}
      <a href="/Chat">
        <button className="mainButton" id="chat">
          Chat
        </button>
      </a>
      <h3>Please Login or Create user to continue</h3>
      <a href="/Login">
        <button className="mainButton">Login</button>
      </a>
      <a href="/CreateUser">
        <button className="mainButton">Create User</button>
      </a>
    </div>
  );
}
