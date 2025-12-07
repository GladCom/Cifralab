import dayjs from 'dayjs';
import moment from 'moment';
import { DatePicker, Space } from 'antd';

const dateFormat = 'DD.MM.YYYY';

const customParser = (value) => {
  if (!value) return value;

  if (value.length === 8) {
    const day = value.slice(0, 2);
    const month = value.slice(2, 4);
    const year = value.slice(4, 8);
    return moment(`${day}-${month}-${year}`, 'DD-MM-YYYY');
  }

  return value;
};

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
