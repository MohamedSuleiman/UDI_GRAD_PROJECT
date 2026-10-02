import "./Header.css";
import { useNavigate } from "react-router-dom";
import { useState } from "react";
import { Link } from "react-router-dom";

export function DropDownHeader() {
  const navigate = useNavigate();
  const [menuOpen, setMenuOpen] = useState(false);

  return (
    <div>
      <div className="dropdown-header">
        <nav>
          {/* Navigating back to the Home Page */}
          <Link to="/">
            {/* <img src="../../src/assets/LMK-Logo.png" alt="Logo" /> */}
            <img src="../../src/assets/LWY1.png" alt="Logo" />
          </Link>{" "}
        </nav>
        <div className="header-actions">
          <nav className="log-in">
            <Link to="/Login" className="login-link">
              →］Log in
            </Link>
          </nav>
          <div className="menu-container">
            <button
              className={`menu-btn${menuOpen ? " menu-btn-open" : ""}`}
              onClick={() => setMenuOpen(!menuOpen)}
              aria-expanded={menuOpen}
            >
              {menuOpen ? (
                <span className="close-icon">✕</span>
              ) : (
                <span className="hamburger">
                  <span></span>
                  <span></span>
                  <span></span>
                </span>
              )}

              <span>Menu</span>
            </button>

            {menuOpen && (
              <div className="dropdown-menu">
                <button onClick={() => navigate("/Chat")}>Chat</button>
                <button onClick={() => navigate("/Account")}>Account</button>
              </div>
            )}
          </div>
        </div>

        {/* <option value="" hidden>
            Menu
          </option>
          <option value="/Chat">Chat</option>
          <option value="/Account">Account</option> */}
      </div>
    </div>
  );
}
