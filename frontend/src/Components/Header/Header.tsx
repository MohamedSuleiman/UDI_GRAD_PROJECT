import "./Header.css";
import { useNavigate } from "react-router-dom";
import { useState } from "react";
import { Link } from "react-router-dom";

export function DropDownHeader() {
  const navigate = useNavigate();
  const [selectedPage, setSelectedPage] = useState("");

  return (
    <div>
      <div className="dropdown-header">
        <nav>
          {/* Navigating back to the Home Page */}
          <Link to="/">
            {/* <img src="../../src/assets/LMK-Logo.png" alt="Logo" /> */}
            <img src="../../src/assets/LMK-logo1.png" alt="Logo" />
          </Link>{" "}
        </nav>
        <select
          id="pages"
          name="pages"
          value={selectedPage}
          onChange={(e) => {
            navigate(e.target.value);
            setSelectedPage("");
          }}
        >
          <option value="" hidden>
            Menu
          </option>
          <option value="/Chat">Chat</option>
          <option value="/Account">Account</option>
        </select>
      </div>
    </div>
  );
}
