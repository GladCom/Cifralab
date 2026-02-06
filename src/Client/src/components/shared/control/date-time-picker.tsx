import { DatePicker } from 'antd';
import type { RangePickerProps } from 'antd/es/date-picker';
import { RangeValue } from '../../report/types';

const { RangePicker } = DatePicker;

interface IProps extends Omit<RangePickerProps, 'onChange'> {
  onDateChange: (dates: RangeValue | null) => void;
}

export const DateTimePicker: React.FC<IProps> = ({ onDateChange, ...restProps }) => {
  return <RangePicker {...restProps} onChange={(dates) => onDateChange(dates as RangeValue)} />;
};
