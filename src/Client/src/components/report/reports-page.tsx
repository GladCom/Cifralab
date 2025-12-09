import { Layout } from '../shared/layout/index';
import { FrdoReportBody } from '@components/report/frdo-report-body';
import { Accordion } from '../shared/control/accordion';
import { RosstatReportBody } from '@components/report/rosstat-report-body';
import { SummaryReportBody } from '@components/report/summary-report-body';

const ReportsPage = () => {
  return (
    <Layout title="Отчеты">
      <Accordion>
        <FrdoReportBody />
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
