import "../../index.css";
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { useAuth } from "../../Context/authContext/AuthContext";
import { GetUserById } from "../../api/UserApi/UserApi";
import type { User } from "../../Types/User";
import { ChangeUserInformation } from "../../api/UserApi/UserApi";
import "./UserAccount.css";

export function UserAccount() {
  const { user: loggedInUser } = useAuth();
  const userId = loggedInUser?.id;

  const [user, setUser] = useState<User | null>(null);
  const [error, setError] = useState("");

  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");

  async function handleSave() {
    if (!user) return;

    try {
      await ChangeUserInformation(user.id, {
        firstName,
        lastName,
      });

      setUser({ ...user, firstName, lastName });
      alert("Information saved!");
    } catch (error) {
      console.error(error);
      alert("Could not save information.");
    }
  }

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
          setFirstName(result.firstName);
          setLastName(result.lastName);
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
        <p>Not available when logged out.</p>
        <Link to="/Login">Go to login</Link>
      </div>
    );
  }

  if (error) {
    return (
      <div className="chat">
        <p>{error}</p>
        <p>Please try again later.</p>
      </div>
    );
  }

  if (!user || user.id !== userId) {
    return <div>
      <p>Loading account...</p>
    </div>;
  }

  return (
    <div className="chat-user">
      <h1>Account</h1>
      <div>
        <div className="userInfo">
          <p>
            <strong>Name:</strong> {user.firstName} {user.lastName}
          </p>
          <p>
            <strong>Email:</strong> {user.email}
          </p>
          <p>
            <strong>Nationality:</strong> {user.nationality ?? "Unknown"}
          </p>
          <p>
            <strong>Usage:</strong> {user.userUsage ?? "Unknown"}
          </p>
        </div>
      </div>
      -----------------------------------------------------------------
      <div className="formFill" id="userInfoForm">
        <label>
          <strong>First name:</strong>
          <input
            value={firstName}
            onChange={(e) => setFirstName(e.target.value)}
          />
        </label>

        <label>
          <strong>Last name:</strong>
          <input
            value={lastName}
            onChange={(e) => setLastName(e.target.value)}
          />
        </label>
        <button
          className="mainButton"
          id="saveChangesButton"
          type="button"
          onClick={handleSave}
        >
          Save changes
        </button>
      </div>
      -----------------------------------------------------------------
    </div>
  );
}
