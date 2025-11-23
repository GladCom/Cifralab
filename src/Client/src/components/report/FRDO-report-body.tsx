import { Button, Card, Divider, message, Space, Typography } from 'antd';
import { DownloadOutlined } from '@ant-design/icons';
import React, { useState } from 'react';
import DateTimePicker from '@components/shared/business/date-time-picker';
import { RangeValue } from '@/types';

const { Paragraph, Title } = Typography;

const FRDOReportBody = () => {
  const [isDownloading, setIsDownloading] = useState(false);
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
      <Title level={4}>отчёт ФРДО</Title>
      <Paragraph type="secondary">
        Выгрузка данных о выданных документах об образовании в формате Excel для последующей загрузки в федеральный
        реестр.
      </Paragraph>
      <Divider />
      <Space direction="vertical" size="middle">
        <Paragraph>
          <strong>1. Выберите период формирования отчётов:</strong>
        </Paragraph>
        <DateTimePicker onDateChange={setDataRange} />
        <Paragraph>
          <strong>2а. Добавьте необходимы поля и скачайте отчёт:</strong>
        </Paragraph>
        <Space>
          <Button type="primary" icon={<DownloadOutlined />} loading={isDownloading}>
            {isDownloading ? 'Формирование...' : 'Скачать .xlsx'}
          </Button>
        </Space>
        <Paragraph style={{ marginBottom: 0 }}>
          <strong>2б. Сформируйте и скачайте отчёт на основе данных из системы:</strong>
        </Paragraph>
        <Button type="primary" icon={<DownloadOutlined />} loading={isDownloading}>
          {isDownloading ? 'Формирование...' : 'Сформировать и скачать .xlsx'}
        </Button>
      </Space>
    </Card>
  );
};

export default FRDOReportBody;
