import { RosstatReportConfig } from '@/storage/catalog-config/report-config';
import DefaultReportBody from '@components/report/deafault-report-card-body';

const RosstatReportBody = () => {
  const rosstatConfig = new RosstatReportConfig();

  return (
    <>
      <DefaultReportBody config={rosstatConfig} />
    </>
  );
};

export default RosstatReportBody;
