import { SummaryReportConfig } from '../../storage/catalog-config/report-config';
import { DefaultReportBody } from './deafault-report-card-body';

export const SummaryReportBody = () => {
  const summaryReportConfig = new SummaryReportConfig();

  return <DefaultReportBody config={summaryReportConfig} />;
};
