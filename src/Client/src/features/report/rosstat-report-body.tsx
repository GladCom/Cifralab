import { RosstatReportConfig } from '../../storage/catalog-config/report-config';
import { DefaultReportBody } from './deafault-report-card-body';

export const RosstatReportBody = () => {
  const rosstatConfig = new RosstatReportConfig();

  return <DefaultReportBody config={rosstatConfig} />;
};
