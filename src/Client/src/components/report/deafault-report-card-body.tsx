import { Button, Card, Divider, message, Space, Typography } from 'antd';
import { DownloadOutlined } from '@ant-design/icons';
import React, { useState } from 'react';
import { RangeValue } from '@/types';
import { useMutation } from '@tanstack/react-query';
import { fetchPFDOReport, IOrderRequest } from '@/api/reposrtApi';
import DateTimePicker from '../shared/control/date-time-picker';

const { Paragraph, Title } = Typography;

export interface IProps {
  title: string;
  description: string;
  fetchfn: (params: IOrderRequest) => Promise<void>;
}
const DefaultReportBody = (props: IProps) => {
  const { fetchfn, title, description } = props;

  const [dateRange, setDataRange] = useState<RangeValue | null>(null);

  // TODO: Сделал так чтобы не хранить обьект запроса в стейт, надо подумать как это переделать
  const [studentId, setStudentId] = useState<string | null>();
  const [groupsIds, setGroupsIds] = useState<string[] | null>([]);

  const reportMutation = useMutation({
    mutationFn: (params: IOrderRequest) => fetchfn(params),
  });

  const reportGeneration = () => {
    if (!dateRange) {
      message.warning('Пожалуйста, выберите период для формирования отчёта.');
      return;
    } else {
      const params: IOrderRequest = {
        endDateMax: null,
        endDateMin: dateRange[0].format('YYYY-MM-DD'),
        startDateMax: null,
        startDateMin: dateRange[1].format('YYYY-MM-DD'),
        studentId: null,
        groupNames: null,
      };
      reportMutation.mutate(params);
    }
  };

  return (
    <Card>
      <Title level={4}>{title}</Title>
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
          <Button
            type="primary"
            onClick={reportGeneration}
            icon={<DownloadOutlined />}
            loading={reportMutation.isPending}
          >
            {reportMutation.isPending ? 'Формирование...' : 'Скачать .xlsx'}
          </Button>
        </Space>
        <Paragraph style={{ marginBottom: 0 }}>
          <strong>2б. Сформируйте и скачайте отчёт на основе данных из системы:</strong>
        </Paragraph>
        <Button type="primary" disabled={true} icon={<DownloadOutlined />} loading={reportMutation.isPending}>
          {reportMutation.isPending ? 'Формирование...' : 'Сформировать и скачать .xlsx'}
        </Button>
      </Space>
    </Card>
  );
};

export default DefaultReportBody;
