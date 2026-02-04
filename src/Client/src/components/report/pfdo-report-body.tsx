import { PfdoReportConfig } from '../../storage/catalog-config/report-config';
import { DefaultReportBody } from './deafault-report-card-body';

export const PfdoReportBody = () => {
  const PfdoConfig = new PfdoReportConfig();

  return <DefaultReportBody config={PfdoConfig} />;
};
