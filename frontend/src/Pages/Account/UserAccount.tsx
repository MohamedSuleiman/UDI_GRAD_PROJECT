import "../../index.css";
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { useAuth } from "../../Context/authContext/AuthContext";
import { GetUserById } from "../../api/UserApi/UserApi";
import type { User } from "../../Types/User";

const nationalities = ["Norwegian", "Swedish", "Danish"];
const userUsages = ["Work", "Study", "Hobby"];

export function UserAccount() {
  const { user: loggedInUser } = useAuth();
  const userId = loggedInUser?.id;

  const [user, setUser] = useState<User | null>(null);
  const [error, setError] = useState("");

  useEffect(() => {
    let active = true;

    setUser(null);
    setError("");

    if (userId === undefined) {
      return;
    }

    async function loadUser(id: number): Promise<void> {
      try {
        const result = await GetUserById(id);

        if (active) {
          setUser(result);
        }
      } catch {
        if (active) {
          setError("Could not load account information.");
        }
      }
    }

    void loadUser(userId);

    return () => {
      active = false;
    };
  }, [userId]);

  if (!loggedInUser) {
    return (
      <div className="chat">
        <h2>Account</h2>
        <p>Please log in to view your account.</p>
        <Link to="/Login">Go to login</Link>
      </div>
    );
  }

  if (error) {
    return (
      <div className="chat">
        <h2>Account</h2>
        <p role="alert">{error}</p>
      </div>
    );
  }

  if (!user || user.id !== userId) {
    return (
      <div className="chat">
        <h2>Account</h2>
        <p>Loading account...</p>
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
        <p>
          Nationality: {nationalities[user.nationality] ?? "Unknown"}
        </p>
        <p>Usage: {userUsages[user.userUsage] ?? "Unknown"}</p>
      </div>
    </div>
  );
}