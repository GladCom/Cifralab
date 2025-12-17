import { Layout } from '../shared/layout/index';
import { PFDOReportBody } from '@components/report/PFDO-report-body';
import { Accordion } from '../shared/control/accordion/accordion';
import { RosstatReportBody } from '@components/report/rosstat-report-body';
import { SummaryReportBody } from '@components/report/summary-report-body';

const ReportsPage = () => {
  return (
    <Layout title="Отчеты">
      <Accordion>
        <PFDOReportBody />
      </Accordion>
      <Accordion>
        <RosstatReportBody />
      </Accordion>
      <Accordion>
        <SummaryReportBody />
      </Accordion>
    </Layout>
  );
};

export default ReportsPage;
