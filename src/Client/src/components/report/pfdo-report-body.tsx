import { DefaultReportBody } from '@components/report/deafault-report-card-body';
import { PFDOReportConfig } from '@/storage/catalog-config/report-config';

export const PfdoReportBody = () => {
  const PFDOConfig = new PFDOReportConfig();

  return <DefaultReportBody config={PFDOConfig} />;
};
