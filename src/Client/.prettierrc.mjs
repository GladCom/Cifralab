export default {
    semi: true,
    singleQuote: true,
    trailingComma: 'all',
    printWidth: 120, // Современные мониторы позволяют увеличить до 100-120
    tabWidth: 2,
    useTabs: false, // Лучше использовать пробелы для кроссплатформенной совместимости
    bracketSpacing: true,
    bracketSameLine: false, // JSX закрывающие скобки на той же линии
    jsxSingleQuote: false,
    arrowParens: 'always',
    endOfLine: 'auto', // Автоматически определять концы строк (LF/CRLF)
    overrides: [
      {
        files: ['*.{ts,tsx}'],
        options: {
          parser: 'typescript',
        },
      },
      {
        files: ['*.json'],
        options: {
          tabWidth: 2,
        },
      },
      {
        files: ['*.css', '*.scss'],
        options: {
          singleQuote: false,
        },
      },
    ],
  };
