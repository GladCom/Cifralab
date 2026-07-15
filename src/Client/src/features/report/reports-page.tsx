import { Accordion } from '../shared/control/accordion/accordion';
import { Layout } from '../shared/layout/layout';
import { PfdoReportBody } from './pfdo-report-body';
import { RosstatReportBody } from './rosstat-report-body';
import { SummaryReportBody } from './summary-report-body';

export const ReportsPage = () => {
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
