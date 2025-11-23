import React from 'react';
import { Layout } from '../shared/layout/index';
import ReportCard from '@components/report/report-card';
import { Space } from 'antd';
import Accordion from '@components/shared/business/base-controls/Accordion';
import FRDOReportBody from '@components/report/FRDO-report-body';
import createReportConfig from '../../storage/catalog-configs/report';

const ReportsPage = () => {
  const { crud } = createReportConfig();
  const {} = crud;
  return (
    <Layout title="Отчеты">
      <Accordion>
        <FRDOReportBody />
      </Accordion>
      <Accordion>
        <ReportCard
          title={'отчёт ФРДО'}
          description={
            'Выгрузка данных о выданных документах об образовании в формате Excel для последующей загрузки в федеральный реестр.'
          }
        ></ReportCard>
      </Accordion>
      <Accordion>
        <ReportCard
          title={'отчёт ФРДО'}
          description={
            'Выгрузка данных о выданных документах об образовании в формате Excel для последующей загрузки в федеральный реестр.'
          }
        >
          <Space />
        </ReportCard>
      </Accordion>
    </Layout>
  );
};

export default ReportsPage;
