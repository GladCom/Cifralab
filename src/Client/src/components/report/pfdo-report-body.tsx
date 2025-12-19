import { DefaultReportBody } from '@components/report/deafault-report-card-body';
import { PfdoReportConfig } from '@/storage/catalog-config/report-config';

export const PfdoReportBody = () => {
  const PfdoConfig = new PfdoReportConfig();

  return <DefaultReportBody config={PfdoConfig} />;
};
