import { z } from 'zod';

export const BASE_API_URL = process.env.REACT_APP_API_URL ?? 'http://localhost:5137';

export async function apiJsonRequest<T>(url: string, schema: z.ZodType<T>, options?: RequestInit): Promise<T> {
  const baseURL = `${BASE_API_URL}${url}`;
  const response = await fetch(baseURL, {
    ...options,
    headers: {
      'Content-Type': 'application/json',
    },
    ...options?.headers,
  });
  if (!response.ok) {
    throw new Error(response.statusText);
  }
  const jsonData = await response.json();

  return schema.parse(jsonData);
}

export const apiFileRequest = async <T>(url: string, params?: T, options?: RequestInit): Promise<Blob> => {
  const baseURL = `${BASE_API_URL}/${url}`;
  const response = await fetch(`${baseURL}`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      ...options?.headers,
    },
    body: JSON.stringify(params),
    ...options,
  });

  if (!response.ok) {
    const errorText = await response.text();
    throw new Error(`Ошибка сервера: ${response.status} ${errorText}`);
  }

  return response.blob();
};
