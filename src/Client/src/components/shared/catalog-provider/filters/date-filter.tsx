import dayjs from 'dayjs';
import { DatePicker, Space } from 'antd';

const dateFormat = 'DD.MM.YYYY';
/*
const customParser = (value) => {
  if (!value) return value;

  // Если введено ровно 8 символов
  if (value.length === 8) {
    // Преобразуем строку в формат "DD-MM-YYYY"
    const day = value.slice(0, 2);
    const month = value.slice(2, 4);
    const year = value.slice(4, 8);
    return moment(`${day}-${month}-${year}`, 'DD-MM-YYYY');
  }

  return value; // Возвращаем оригинальное значение, если формат не соответствует
};
*/
const DateFilter = ({ placeholder, onChange }) => {
  return (
    <div className="col-2">
      <Space>
        <DatePicker
          placeholder={placeholder}
          format={dateFormat}
          //parser={customParser}
          defaultPickerValue={dayjs('05.03.1990', dateFormat)}
          onChange={(date, dateString) => onChange(date, dateString)}
        />
      </Space>
    </div>
  );
};

export default DateFilter;
