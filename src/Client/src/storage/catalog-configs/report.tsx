import {
  useGetPFDOReportMutation,
  useGetSummaryReportMutation,
  useGetRosstatReportMutation,
} from '../crud/reports-crud';

const createReportConfig = ({ onEdit = (record) => console.warn('Обработчик onEdit не предоставлен', record) }) => {
  return {
    detailsLink: 'report',
    hasDetailsPage: true,
    serverPaged: true,
    crud: {
      useGetPFDOReportMutation,
      useGetSummaryReportMutation,
      useGetRosstatReportMutation,
    },

    filters: [],
    dataConverter: (data) => data,
  };
};

export default createReportConfig;
