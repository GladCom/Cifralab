/**
 * Полифилы (заплатки) для Node.js, чтобы он "понимал" API браузера.
 *
 * Jest запускается в Node.js, но наши компоненты рассчитаны на браузер.
 * Поэтому мы "подделываем" недостающие глобальные объекты.
 *
 * ВАЖНО: используем CommonJS (require), потому что Jest пока лучше работает с ним в setupFiles.
 */

/* eslint-disable no-undef */
const util = require('util');

// 1. TextEncoder/TextDecoder — нужны для некоторых библиотек (например, Ant Design).
if (typeof globalThis.TextEncoder === 'undefined') {
  globalThis.TextEncoder = util.TextEncoder;
  globalThis.TextDecoder = util.TextDecoder;
}

// 2. matchMedia — используется Ant Design для адаптивности.
//    Без этого мока компоненты могут крашиться в тестах.
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

// 3. AbortController — нужен для fetch-запросов с отменой.
if (typeof global.AbortController === 'undefined') {
  global.AbortController = AbortController;
}

// 4. fetch API — заменяем нативный fetch (которого нет в старых Node) на whatwg-fetch.
global.fetch = require('whatwg-fetch').fetch;
global.Request = require('whatwg-fetch').Request;
global.Response = require('whatwg-fetch').Response;
