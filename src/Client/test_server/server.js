import { students } from './students.js';
import express from 'express';
import cors from 'cors';


const app = express();
const PORT = 5000; // Выбираем порт для сервера

app.use(express.json());
app.use(cors());

app.get('/student', (req, res) => {
  setTimeout(() => {
    res.json({ data: students });
  }, 1000);
  //res.json({ data: students });
});

app.get('/student/:id', (req, res) => {
  const studentId = req.params.id;
  setTimeout(() => {
    res.json({ data: students.filter((s) => s.id === studentId) });
  }, 1000);
  //res.json({ data: students.filter((s) => s.id === studentId) });
});

// Запуск сервера
app.listen(PORT, () => {
  console.log(`Server is running on http://localhost:${PORT}`);
});
