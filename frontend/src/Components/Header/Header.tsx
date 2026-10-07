import "./Header.css";
import { useNavigate, Link } from "react-router-dom";
import { useState } from "react";
import { useAuth } from "../../Context/authContext/AuthContext";
import logo from "../../assets/LWY1.png";

export function DropDownHeader() {
  const navigate = useNavigate();
  const { user, logoutUser } = useAuth();
  const [menuOpen, setMenuOpen] = useState(false);

  function handleLogout() {
    logoutUser();
    setMenuOpen(false);
    navigate("/", { replace: true });
  }

  function handleNavigation(path: string) {
    setMenuOpen(false);
    navigate(path);
  }

  return (
    <div className="dropdown-header">
      <nav>
        <Link to="/" onClick={() => setMenuOpen(false)}>
          <img src={logo} alt="Logo" />
        </Link>
      </nav>

      <div className="header-actions">
        {user ? (
          <Link to="/" className="login-link" onClick={handleLogout}>
            ←］ Log out
          </Link>
        ) : (
          <Link
            to="/Login"
            className="login-link"
            onClick={() => setMenuOpen(false)}
          >
            →］Log in
          </Link>
        )}

        <div className="menu-container">
          <button
            type="button"
            className={`menu-btn${menuOpen ? " menu-btn-open" : ""}`}
            onClick={() => setMenuOpen((previous) => !previous)}
            aria-expanded={menuOpen}
            aria-controls="header-menu"
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
            <div id="header-menu" className="dropdown-menu">
              <button type="button" onClick={() => handleNavigation("/Chat")}>
                Chat
              </button>

              <button
                type="button"
                onClick={() => handleNavigation("/Account")}
              >
                Account
              </button>
            </div>
          )}
        </div>
      </div>
    </div>
  );
}
