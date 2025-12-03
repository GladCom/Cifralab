import React from 'react';
import DefaultReportBody from '@components/report/deafault-report-card-body';
import {SummaryReportConfig} from '@/storage/catalog-config/report-config';

const SummaryReportBody = () => {
  const summaryReportConfig = new SummaryReportConfig();

  return (
    <>
      <DefaultReportBody config={summaryReportConfig} />
    </>
  );
};

export default SummaryReportBody;
