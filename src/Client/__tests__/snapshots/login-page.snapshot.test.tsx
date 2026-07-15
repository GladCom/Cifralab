import React from 'react';
import { render } from '@testing-library/react';
import { LoginPage } from '../../src/features/auth/login-page';

// Мокаем зависимости компонента
jest.mock('react-redux', () => ({
  useDispatch: () => jest.fn(),
}));

jest.mock('react-router-dom', () => ({
  useNavigate: () => jest.fn(),
}));

describe('LoginPage Snapshot', () => {
  test('renders correctly', () => {
    const { container } = render(<LoginPage />);
    expect(container).toMatchSnapshot();
  });
});
