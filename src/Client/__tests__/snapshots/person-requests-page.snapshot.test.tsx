import React from 'react';
import { renderWithProviders } from '../../src/test-utils/render-with-providers';
import { PersonRequestsPage } from '../../src/features/request/person-requests-page';

describe('PersonRequestsPage Snapshot', () => {
  test('renders correctly', () => {
    const { container } = renderWithProviders(<PersonRequestsPage />);
    expect(container).toMatchSnapshot();
  });
});
