import React from 'react';
import { Provider } from 'react-redux';
import { MemoryRouter } from 'react-router-dom';

import { createTestStore } from './create-test-store';
import { render } from '@testing-library/react';

export const renderWithProviders = (
  ui: React.ReactElement,
  { route = '/' } = {}
) => {
  const store = createTestStore();

  return render(
    <Provider store={store}>
      <MemoryRouter initialEntries={[route]}>{ui}</MemoryRouter>
    </Provider>
  );
};
