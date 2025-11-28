import React from 'react';
import { Layout } from '../shared/layout/index';
import FRDOReportBody from '@components/report/FRDO-report-body';
import Accordion from '../shared/control/base-controls/Accordion';
import DefaultReportBody from '@components/report/deafault-report-card-body';
import { fetchPFDOReport } from '@/api/reportsApi';
import RosstatReportBody from '@components/report/Rosstat-report-body';

const ReportsPage = () => {
  return (
    <Layout title="Отчеты">
      <Accordion>
        <FRDOReportBody />
      </Accordion>
      <Accordion>
        <RosstatReportBody />
      </Accordion>
      <Accordion>
        <FRDOReportBody />
      </Accordion>
    </Layout>
  );
};

export default ReportsPage;
