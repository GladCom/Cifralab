import { DefaultReportBody } from '@components/report/deafault-report-card-body';
import { PFDOReportConfig } from '@/storage/catalog-config/report-config';

export const PFDOReportBody = () => {
  const PFDOConfig = new PFDOReportConfig();

  return <DefaultReportBody config={PFDOConfig} />;
};
