import DefaultReportBody from '@components/report/deafault-report-card-body';
import { PFDOReportConfig } from '@/storage/catalog-config/report-config';

const FRDOReportBody = () => {
  const pfdoConfig = new PFDOReportConfig();

  return <DefaultReportBody config={pfdoConfig} />;
};

export default FRDOReportBody;
