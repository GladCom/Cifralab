import React from 'react';
import { Layout } from '../shared/layout/index';
import FRDOReportBody from '@components/report/FRDO-report-body';
import Accordion from '../shared/control/base-controls/Accordion';
import DefaultReportBody from '@components/report/deafault-report-card-body';
import { fetchPFDOReport } from '@/api/reposrtApi';

const ReportsPage = () => {
  return (
    <Layout title="Отчеты">
      <Accordion>
        <DefaultReportBody />
      </Accordion>
      <Accordion>
        <FRDOReportBody />
      </Accordion>
      <Accordion>
        <FRDOReportBody />
      </Accordion>
    </Layout>
  );
};

export default ReportsPage;
