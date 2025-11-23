import {
  useGetPFDOReportMutation,
  useGetSummaryReportMutation,
  useGetRosstatReportMutation,
} from '../crud/reports-crud';

// 1. Описываем типы

type MutationHook = (...args: any[]) => any;

interface CreateReportConfigParams<TRecord = any> {
  onEdit?: (record: TRecord) => void;
}

interface IReportConfig<TData = any> {
  detailsLink: string;
  hasDetailsPage: boolean;
  serverPaged: boolean;
  crud: {
    useGetPFDOReportMutation: MutationHook;
    useGetSummaryReportMutation: MutationHook;
    useGetRosstatReportMutation: MutationHook;
  };
  filters: any[];
  dataConverter: (data: TData) => TData;
}

// 2. Применяем типы к функции

const createReportConfig = <TData = any>(): IReportConfig<TData> => {
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
    dataConverter: (data: TData) => data,
  };
};

export default createReportConfig;
