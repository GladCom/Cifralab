import { Layout } from '../shared/layout/index';
import FRDOReportBody from '@components/report/FRDO-report-body';
import Accordion from '../shared/control/base-controls/Accordion';
import RosstatReportBody from '@components/report/Rosstat-report-body';
import SummaryReportBody from './Summary-report-body';

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
        <SummaryReportBody />
      </Accordion>
    </Layout>
  );
};

export default ReportsPage;
