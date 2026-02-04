import React from 'react';
import PersonRequestsPage from '../../src/components/request/person-requests-page';
import { renderWithProviders } from '../utils/render-with-providers';

describe('PersonRequestsPage Snapshot', () => {
  test('renders correctly', () => {
    const { container } = renderWithProviders(<PersonRequestsPage />);
    expect(container).toMatchSnapshot();
  });
});
