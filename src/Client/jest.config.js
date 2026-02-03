export default {
  preset: 'ts-jest',
  testEnvironment: 'jsdom',

  // Где искать тесты
  roots: ['<rootDir>/__tests__'],

  // Какие файлы считать тестами
  testMatch: [
    '<rootDir>/__tests__/**/*.test.ts',
    '<rootDir>/__tests__/**/*.test.tsx'
  ],

  // Трансформация TypeScript файлов
  transform: {
    '^.+\\.tsx?$': 'ts-jest'
  },

  // Игнорировать node_modules
  testPathIgnorePatterns: ['/node_modules/']
};