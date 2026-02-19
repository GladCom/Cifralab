// test-utils/render-with-providers.tsx
import { render } from '@testing-library/react';
import { Provider } from 'react-redux';
import { createTestStore } from './create-test-store';
import { createMemoryRouter, RouterProvider } from 'react-router-dom';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import React from 'react';

const queryClient = new QueryClient({
  defaultOptions: {
    queries: {
      retry: false, // отключаем повторы в тестах
    },
  },
});

export const renderWithProviders = (ui: React.ReactElement, { route = '/', initialEntries = [route] } = {}) => {
  const store = createTestStore();

  const router = createMemoryRouter([{ path: '*', element: ui }], { initialEntries });

  return render(
    <Provider store={store}>
      <QueryClientProvider client={queryClient}>
        <RouterProvider router={router} />
      </QueryClientProvider>
    </Provider>,
  );
};
