import { Button, Card, Divider, Flex, message, Space, Typography } from 'antd';
import { DownloadOutlined } from '@ant-design/icons';
import React, { useEffect, useState } from 'react';
import { RangeValue } from '@/types';
import { useMutation } from '@tanstack/react-query';
import { IReportRequest } from '@/api/reportsApi';
import DateTimePicker from '../shared/control/date-time-picker';
import { IReportConfig } from '@/storage/catalog-config/report-config';
import { GroupSelect } from '@components/shared/control/selects/group-select';
import { DisplayMode } from '@components/shared/control/multi-mode-control/types';

const { Paragraph, Title } = Typography;

export interface IProps {
  config: IReportConfig;
}

const DefaultReportBody = ({ config }: IProps) => {
  const { title, description } = config;

  const [dateRange, setDataRange] = useState<RangeValue | null>(null);

  // TODO: Сделал так чтобы не хранить обьект запроса в стейт, надо подумать как это переделать
  const [studentId, setStudentId] = useState<string | null>();
  const [groupsId, setGroupsId] = useState<string[] | null>(null);

  const reportMutation = useMutation({
    mutationFn: (params: IReportRequest) => config.crud.getReport(params),
  });

  useEffect(() => {
    console.log(groupsId);
  }, [groupsId]);

  const reportGeneration = () => {
    if (!groupsId) {
      message.warning('Пожалуйста, выберите группы, для формирования отчёта.');
      return;
    }
  console.log(groupsId);
    if (!dateRange) {
      message.warning('Пожалуйста, выберите период для формирования отчёта.');
      return;
    } else {
      const params: IReportRequest = {
        endDateMax: null,
        endDateMin: dateRange[0].format('YYYY-MM-DD'),
        startDateMax: null,
        startDateMin: dateRange[1].format('YYYY-MM-DD'),
        studentId: null,
        groupNames: groupsId,
      };
      reportMutation.mutate(params);
    }
  };

  return (
    <Card>
      <Title level={4}>{title}</Title>
      <Paragraph type="secondary">{description}</Paragraph>
      <Divider />
      <Space direction="vertical" size="middle">
        <Paragraph>
          <strong>1. Выберите период формирования отчётов и группы, по которым это нужно сделать:</strong>
        </Paragraph>

        <Flex style={{ gap: '10px' }}>
          <DateTimePicker onDateChange={setDataRange} />
          <GroupSelect displayMode={DisplayMode.MULTI_SELECT} value={groupsId} setValue={(val: string[] | null) => setGroupsId(val)} />
        </Flex>

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
