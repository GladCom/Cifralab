// Перевод на ESM сломает тесты, по этому гасим.
/* eslint-disable no-undef */
const util = require('util');

// 1. TextEncoder/TextDecoder из Node.js
if (typeof globalThis.TextEncoder === 'undefined') {
  globalThis.TextEncoder = util.TextEncoder;
  globalThis.TextDecoder = util.TextDecoder;
}

// 2. Мок matchMedia для Ant Design
if (typeof window !== 'undefined' && typeof window.matchMedia === 'undefined') {
  Object.defineProperty(window, 'matchMedia', {
    writable: true,
    value: (query) => ({
      matches: false,
      media: query,
      onchange: null,
      addListener: () => {}, // устаревший, но иногда используется
      removeListener: () => {},
      addEventListener: () => {},
      removeEventListener: () => {},
      dispatchEvent: () => false,
    }),
  });
}

global.AbortController = AbortController;
global.fetch = require('whatwg-fetch').fetch;
global.Request = require('whatwg-fetch').Request;
global.Response = require('whatwg-fetch').Response;
