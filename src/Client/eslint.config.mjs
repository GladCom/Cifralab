import js from '@eslint/js';
import globals from 'globals';
import reactRecommended from 'eslint-plugin-react/configs/recommended.js';
import typescriptParser from '@typescript-eslint/parser';
import typescriptPlugin from '@typescript-eslint/eslint-plugin';
import reactHooks from 'eslint-plugin-react-hooks';
import jsxRuntime from 'eslint-plugin-react/configs/jsx-runtime.js';
import unicorn from 'eslint-plugin-unicorn';
import prettierPlugin from 'eslint-plugin-prettier';

export default [
  js.configs.recommended,

  // Конфигурация для TypeScript файлов
  {
    ...reactRecommended,
    ...jsxRuntime,
    files: ['**/*.{ts,tsx}'],
    languageOptions: {
      globals: {
        ...globals.browser,
        ...globals.es2021,
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
    },
    rules: {
      'react-hooks/rules-of-hooks': 'error',
      'react-hooks/exhaustive-deps': 'warn',
      '@typescript-eslint/no-unused-vars': 'warn',
      '@typescript-eslint/no-explicit-any': 'warn',
      'unicorn/filename-case': [
        'error',
        {
          case: 'kebabCase',
          ignore: ['\\.(test|spec)\\.(js|jsx|ts|tsx)$', '^[A-Z]+\\.(js|jsx|ts|tsx)$'],
        },
      ],
      'prettier/prettier': 'error',
      'react/react-in-jsx-scope': 'off',
      'react/jsx-uses-react': 'off',
      'no-unused-vars': 'warn',
      'no-console': 'warn',
      'no-debugger': 'error',
      quotes: ['error', 'single'],
      semi: ['error', 'always'],
      indent: ['error', 2],
      'arrow-body-style': 'off',
      'prefer-arrow-callback': 'off',
    },
  },

  // Игнорирование конфигурационных файлов
  {
    ignores: ['**/*.config.js', '**/*.rc.js', '.prettierrc.js', '.eslintrc.js'],
  },
];
