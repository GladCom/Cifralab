import React from 'react';
import renderer from 'react-test-renderer';
import LoginPage from '../src/components/authorization/login-page';

// Мокаем зависимости компонента
jest.mock('react-redux', () => ({
  useDispatch: () => jest.fn(),
}));

jest.mock('react-router-dom', () => ({
  useNavigate: () => jest.fn(),
}));

describe('LoginPage Snapshot', () => {
  test('renders correctly', () => {
    const tree = renderer.create(<LoginPage />).toJSON();
    expect(tree).toMatchSnapshot();
  });
});
