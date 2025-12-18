import { fetchPfdoReport, fetchRostatReport, ReportRequest, fetchSummaryReport } from '@/api/reports-api';

export interface ReportCrud {
  getReport: (params: ReportRequest) => Promise<void>;
}

export interface ReportConfig {
  title: string;
  description: string;
  detailsLink: string;
  hasDetailsPage: boolean;
  serverPaged: boolean;
  crud: ReportCrud;
  dataConverter?: (data: never) => never;
}

export abstract class BaseReportConfig implements ReportConfig {
  abstract title: string;
  abstract crud: ReportCrud;

  description: string =
    'Выгрузка данных о выданных документах об образовании в формате Excel для последующей загрузки в федеральный реестр.';
  detailsLink: string = 'report';
  hasDetailsPage: boolean = false;
  serverPaged: boolean = false;

  dataConverter(data: never): never {
    return data;
  }
}

export class PfdoReportConfig extends BaseReportConfig {
  title = 'Отчёт ФРДО';
  crud = {
    getReport: fetchPfdoReport,
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
