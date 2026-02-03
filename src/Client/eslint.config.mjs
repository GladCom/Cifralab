import js from '@eslint/js';
import globals from 'globals';
import reactRecommended from 'eslint-plugin-react/configs/recommended.js';
import typescriptParser from '@typescript-eslint/parser';
import typescriptPlugin from '@typescript-eslint/eslint-plugin';
import reactHooks from 'eslint-plugin-react-hooks';
import jsxRuntime from 'eslint-plugin-react/configs/jsx-runtime.js';
import unicorn from 'eslint-plugin-unicorn';
import prettierPlugin from 'eslint-plugin-prettier';

// Импортируем плагин для неиспользуемых импортов
import unusedImports from 'eslint-plugin-unused-imports';

export default [
  js.configs.recommended,

  // Конфигурация для TypeScript файлов
  {
    ...reactRecommended,
    ...jsxRuntime,
    files: ['src/**/*.{ts,tsx}'],
    languageOptions: {
      globals: {
        ...globals.browser,
        ...globals.es2021,
        ...globals.node,
        React: 'readonly',
        process: 'readonly',
      },
      parser: typescriptParser,
      parserOptions: {
        project: './tsconfig.json',
      },
    },
    settings: {
      react: {
        version: 'detect',
      },
    },
  },

  // Конфигурация для JavaScript файлов
  {
    files: ['**/*.{js,jsx}'],
    languageOptions: {
      globals: {
        ...globals.browser,
        ...globals.es2021,
        process: 'readonly',
      },
      parserOptions: {
        ecmaVersion: 'latest',
        sourceType: 'module',
        ecmaFeatures: {
          jsx: true,
        },
      },
    },
  },

  // Общие правила для всех файлов
  {
    plugins: {
      'react-hooks': reactHooks,
      '@typescript-eslint': typescriptPlugin,
      unicorn,
      prettier: prettierPlugin,
      'unused-imports': unusedImports, // Добавляем плагин
    },
    rules: {
      // Основные правила React
      'react-hooks/rules-of-hooks': 'error',
      'react-hooks/exhaustive-deps': 'warn',
      'react/react-in-jsx-scope': 'off',
      'react/jsx-uses-react': 'off',

      // TypeScript правила
      '@typescript-eslint/no-unused-vars': 'off', // Отключаем стандартное правило
      '@typescript-eslint/no-explicit-any': 'warn',

      // Unicorn правила
      'unicorn/filename-case': [
        'error',
        {
          case: 'kebabCase',
          ignore: ['\\.(test|spec)\\.(js|jsx|ts|tsx)$', '^[A-Z]+\\.(js|jsx|ts|tsx)$'],
        },
      ],

      // Prettier интеграция
      'prettier/prettier': 'error',

      // Правила для неиспользуемых импортов и переменных
      'unused-imports/no-unused-imports': 'error',
      'unused-imports/no-unused-vars': [
        'warn',
        {
          vars: 'all',
          varsIgnorePattern: '^_',
          args: 'after-used',
          argsIgnorePattern: '^_',
        },
      ],

      // Стандартные ESLint правила
      'no-unused-vars': 'off', // Отключаем в пользу unused-imports
      'no-console': 'warn',
      'no-debugger': 'error',
      quotes: ['error', 'single'],
      semi: ['error', 'always'],
      indent: ['error', 2],
      'arrow-body-style': 'off',
      'prefer-arrow-callback': 'off',
    },
  },

  // КОНФИГУРАЦИЯ ДЛЯ ТЕСТОВ
  {
    files: ['__tests__/**/*', '**/*.test.ts', '**/*.test.tsx'],
    languageOptions: {
      globals: {
        ...globals.browser,
        ...globals.node,
        ...globals.jest, // Глобальные переменные Jest
        jest: 'readonly',
        describe: 'readonly',
        test: 'readonly',
        it: 'readonly',
        expect: 'readonly',
        beforeAll: 'readonly',
        afterAll: 'readonly',
        beforeEach: 'readonly',
        afterEach: 'readonly',
        React: 'readonly',
      },
      parser: typescriptParser,
      parserOptions: {
        project: './tsconfig.test.json', // Тестовый tsconfig
      },
    },
    plugins: {
      'react-hooks': reactHooks,
      '@typescript-eslint': typescriptPlugin,
    },
    rules: {
      'react-hooks/rules-of-hooks': 'error',
      'react-hooks/exhaustive-deps': 'warn',
      'react/react-in-jsx-scope': 'off',
      'react/jsx-uses-react': 'off',
      '@typescript-eslint/no-explicit-any': 'off',
      '@typescript-eslint/no-unused-vars': 'off',
      'no-console': 'off',
    },
  },

  // Дополнительные правила для продакшена
  {
    files: ['src/**/*.{ts,tsx,js,jsx}'],
    languageOptions: {
      globals: {
        process: 'readonly', // ← добавляем process здесь тоже
      },
    },
    rules: {
      'no-console': process.env.NODE_ENV === 'production' ? 'error' : 'warn',
    },
  },

  // Игнорирование конфигурационных файлов
  {
    ignores: [
      '**/*.config.js',
      '**/*.rc.js',
      '.prettierrc.js',
      '.eslintrc.js',
      'dist/**',
      'build/**',
      'node_modules/**',
    ],
  },
];
