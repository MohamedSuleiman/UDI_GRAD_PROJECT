import { fireEvent, render, screen } from '@testing-library/react';
import { AuthProvider, useAuth } from '../Context/authContext/AuthContext';
import { describe, it, expect } from 'vitest';

function AuthStatus() {
  const { user, loginUser, logoutUser } = useAuth();

  return (
    <div>
      <span>{user ? `User ${user.id}` : 'No user'}</span>
      <button type="button" onClick={() => loginUser({ id: 7 })}>
        Login
      </button>
      <button type="button" onClick={logoutUser}>
        Logout
      </button>
    </div>
  );
}

describe('AuthProvider', () => {
  it('starts logged out and can log in and out', () => {
    render(
      <AuthProvider>
        <AuthStatus />
      </AuthProvider>
    );

    expect(screen.getByText('No user')).toBeInTheDocument();

    fireEvent.click(screen.getByRole('button', { name: 'Login' }));
    expect(screen.getByText('User 7')).toBeInTheDocument();

    fireEvent.click(screen.getByRole('button', { name: 'Logout' }));
    expect(screen.getByText('No user')).toBeInTheDocument();
  });
});
