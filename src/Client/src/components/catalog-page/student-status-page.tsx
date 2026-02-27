import { studentStatusConfig } from '../../storage/catalog-config/student-status';
import { Catalog } from '../shared/catalog-provider/catalog';
import { Layout } from '../shared/layout/layout';

export const StudentStatusPage = () => {
  return (
    <Layout>
      <Catalog config={studentStatusConfig} title="Статус студента" />
    </Layout>
  );
};
