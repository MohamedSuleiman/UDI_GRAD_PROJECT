import "../../index.css";
import { useLocation } from "react-router-dom";
import type { User } from "../../Types/User";

type AccountLocationState = {
  user?: User;
};

const nationalities = ["Norwegian", "Swedish", "Danish"];

const userUsages = ["Work", "Study", "Hobby"];

export function UserAccount() {
  const location = useLocation();
  const user = (location.state as AccountLocationState | null)?.user;

  if (!user) {
    return (
      <div className="chat">
        <h2>Account</h2>
        <p>User information is not available. Please log in again.</p>
      </div>
    );
  }

  return (
    <div className="chat">
      <h2>Account</h2>
      <div>
        <h3>User Information:</h3>
        <p>
          Name: {user.firstName} {user.lastName}
        </p>
        <p>Email: {user.email}</p>
        <p>Nationality: {nationalities[user.nationality] ?? "Unknown"}</p>
        <p>Usage: {userUsages[user.userUsage] ?? "Unknown"}</p>
      </div>
    </div>
  );
}
