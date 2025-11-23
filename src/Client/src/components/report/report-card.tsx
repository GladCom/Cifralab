import React, { useState } from 'react';
import { Card, Divider, Space, Typography, message } from 'antd';
import { RangeValue } from '@/types';
import DateTimePicker from '@components/shared/business/date-time-picker';
const { Title, Paragraph } = Typography;

interface Props {
  title: string;
  description: string;
  children: React.ReactNode;
}

const ReportsCard: React.FC<Props> = ({ title, description, children }) => {
  const [dateRange, setDataRange] = useState<RangeValue | null>(null);

  const handlePreview = () => {
    if (!dateRange || !dateRange[0] || !dateRange[1]) {
      message.warning('Пожалуйста, выберите период для предпросмотра.');
      return;
    }
    const startDate = dateRange[0].format('YYYY-MM-DD');
    const endDate = dateRange[1].format('YYYY-MM-DD');
  };

  return (
    <Card>
      <Title level={4}>{title}</Title>
      <Paragraph type="secondary">{description}</Paragraph>
      <Divider />
      <DateTimePicker onDateChange={setDataRange} />
      <Space direction="vertical" size="middle">
        {children}
      </Space>
    </Card>
  );
};

export default ReportsCard;
