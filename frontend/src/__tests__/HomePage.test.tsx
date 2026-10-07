import { render, screen } from '@testing-library/react';
import { HomePage } from '../Pages/Home/HomePage';
import { describe, it, expect } from 'vitest';

describe('HomePage', () => {
  it('renders the main feature cards', () => {
    render(<HomePage />);

    expect(screen.getByText('Did you know?')).toBeInTheDocument();
    expect(screen.getByText('Want to Chat')).toBeInTheDocument();
    expect(screen.getByText('Create User')).toBeInTheDocument();
  });
});
