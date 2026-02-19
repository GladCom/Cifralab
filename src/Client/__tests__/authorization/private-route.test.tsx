import { render, screen } from '@testing-library/react';
import { createMemoryRouter, RouterProvider } from 'react-router-dom';
import { Provider } from 'react-redux';
import PrivateRoute from '../../src/components/authorization/private-route';
import { createTestStore } from '../../src/test-utils/create-test-store';
import React from 'react';

const SecretPage = () => <div data-testid="secret-content">Секретные данные</div>;
const LoginPage = () => <div data-testid="login-page">Форма входа</div>;

const renderWithAuth = (isAuthenticated: boolean, initialEntries = ['/secret']) => {
  const store = createTestStore({
    user: { loggedIn: isAuthenticated, userName: isAuthenticated ? 'User' : null },
  });

  const router = createMemoryRouter(
    [
      {
        path: '/secret',
        element: (
          <PrivateRoute>
            <SecretPage />
          </PrivateRoute>
        ),
      },
      {
        path: '/login',
        element: <LoginPage />,
      },
    ],
    { initialEntries },
  );

  return render(
    <Provider store={store}>
      <RouterProvider router={router} />
    </Provider>,
  );
};

describe('PrivateRoute', () => {
  test('перенаправляет неавторизованного пользователя на /login', () => {
    renderWithAuth(false);
    expect(screen.queryByTestId('secret-content')).not.toBeInTheDocument();
    expect(screen.getByTestId('login-page')).toBeInTheDocument();
  });

  test('показывает приватный контент авторизованному пользователю', () => {
    renderWithAuth(true);
    expect(screen.getByTestId('secret-content')).toBeInTheDocument();
    expect(screen.queryByTestId('login-page')).not.toBeInTheDocument();
  });
});
