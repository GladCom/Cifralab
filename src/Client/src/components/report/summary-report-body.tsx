import { DefaultReportBody } from '@components/report/deafault-report-card-body';
import { SummaryReportConfig } from '@/storage/catalog-config/report-config';

export const SummaryReportBody = () => {
  const summaryReportConfig = new SummaryReportConfig();

  return <DefaultReportBody config={summaryReportConfig} />;
};
