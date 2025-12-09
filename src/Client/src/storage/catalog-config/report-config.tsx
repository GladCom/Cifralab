import { fetchPFDOReport, fetchRostatReport, IReportRequest, fetchSummaryReport } from '@/api/reports-api';

export interface IReportCrud {
  getReport: (params: IReportRequest) => Promise<void>;
}

export interface IReportConfig {
  title: string;
  description: string;
  detailsLink: string;
  hasDetailsPage: boolean;
  serverPaged: boolean;
  crud: IReportCrud;
  dataConverter?: (data: never) => never;
}

export abstract class BaseReportConfig implements IReportConfig {
  abstract title: string;
  abstract crud: IReportCrud;

  description: string =
    'Выгрузка данных о выданных документах об образовании в формате Excel для последующей загрузки в федеральный реестр.';
  detailsLink: string = 'report';
  hasDetailsPage: boolean = false;
  serverPaged: boolean = false;

  dataConverter(data: never): never {
    return data;
  }
}

export class PFDOReportConfig extends BaseReportConfig {
  title = 'Отчёт ФРДО';
  crud = {
    getReport: fetchPFDOReport,
  };
}

export class SummaryReportConfig extends BaseReportConfig {
  title = 'отчёт по обучающимся';
  crud = {
    getReport: fetchSummaryReport,
  };
}

export class RosstatReportConfig extends BaseReportConfig {
  title = 'отчёт Росстат';
  crud = {
    getReport: fetchRostatReport,
  };
}
