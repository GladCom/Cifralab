/**
 * Конфигурация Jest для React + TypeScript проекта.
 *
 * Цель: настроить запуск unit- и компонентных тестов с поддержкой JSX, CSS, изображений и современного JS.
 *
 * Используется:
 * - ts-jest — для трансформации TypeScript в JavaScript перед запуском тестов.
 * - jsdom — эмуляция браузерного окружения (window, document и т.д.).
 */

export default {
  // Используем preset 'ts-jest' — он автоматически настраивает трансформацию TS.
  preset: 'ts-jest',

  // Окружение тестов: jsdom имитирует браузер (в отличие от 'node').
  testEnvironment: 'jsdom',

  // Файлы, которые запускаются ДО всех тестов (глобальные полифилы).
  // Нужны для поддержки API, которых нет в Node.js (например, fetch, matchMedia).
  setupFiles: ['<rootDir>/jest.polyfills.js'],

  // Файлы, которые запускаются ПОСЛЕ инициализации окружения, но ДО каждого теста.
  // Здесь подключаем расширения для expect (например, toBeInTheDocument).
  setupFilesAfterEnv: ['<rootDir>/jest.setup.ts'],

  // Где искать тесты. <rootDir> = корень проекта.
  // У нас тесты лежат в папке __tests__ (по соглашению Jest).
  roots: ['<rootDir>/__tests__'],

  // Шаблоны имён файлов, которые считаются тестами.
  // Ищем все .test.ts и .test.tsx внутри __tests__.
  testMatch: [
    '<rootDir>/__tests__/**/*.test.ts',
    '<rootDir>/__tests__/**/*.test.tsx'
  ],

  // Как трансформировать исходники: все .ts/.tsx → через ts-jest.
  transform: {
    '^.+\\.tsx?$': 'ts-jest'
  },

  // Игнорировать node_modules — ускоряет запуск.
  testPathIgnorePatterns: ['/node_modules/'],

  // Мокаем импорты ассетов, чтобы они не ломали сборку.
  moduleNameMapper: {
    // CSS/Sass/Less → возвращаем пустой объект (identity-obj-proxy)
    '\\.(css|less|scss|sass)$': 'identity-obj-proxy',

    // Изображения и SVG → возвращаем строку (путь), как делает Webpack
    '\\.(jpg|jpeg|png|gif|webp|svg)$': '<rootDir>/__mocks__/file-mock.js',
  }
};