import { DefaultReportBody } from '@components/report/deafault-report-card-body';
import { PFDOReportConfig } from '@/storage/catalog-config/report-config';

export const FRDOReportBody = () => {
  const pfdoConfig = new PFDOReportConfig();

  return <DefaultReportBody config={pfdoConfig} />;
};
