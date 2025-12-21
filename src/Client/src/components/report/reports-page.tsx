import { Layout } from '../shared/layout/index';
import { PfdoReportBody } from '@components/report/pfdo-report-body';
import { Accordion } from '../shared/control/accordion/accordion';
import { RosstatReportBody } from '@components/report/rosstat-report-body';
import { SummaryReportBody } from '@components/report/summary-report-body';

const ReportsPage = () => {
  return (
    <Layout title="Отчеты">
      <Accordion>
        <PfdoReportBody />
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
