import { fetchPFDOReport, fetchRosstatReport } from '@/api/reposrtApi';
import { boolean, string } from 'yup';

export interface IReportCrud {
  getReport: (params: string) => Promise<void>;
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

fd;
export abstract class BaseReportConfig implements IReportConfig {
  abstract title: string;
  abstract crud: IReportCrud;

  description: string =
    'Выгрузка данных о выданных документах об образовании в формате Excel для последующей загрузки в федеральный реестр.';
  detailsLink: string = 'report';
  hasDetailsPage: boolean = false;
  serverPaged: boolean = false;

  dataConverter(data: any): any {
    return data;
  }
}

export class PFDOReportConfig extends BaseReportConfig {
  title = 'Отчёт ФРДО';
  crud = {
    getReport: fetchPFDOReport,
  };
}

export class RosstatReportConfig extends BaseReportConfig {
  title = 'отчёт Росстат';
  crud = {
    getReport: fetchRosstatReport,
  };
}
