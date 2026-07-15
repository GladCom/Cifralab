import { studentStatusConfig } from '../../storage/catalog-config/student-status';
import { Catalog } from '../../features/shared/catalog-provider/catalog';
import { Layout } from '../../features/shared/layout/layout';

export const StudentStatusPage = () => {
  return (
    <Layout>
      <Catalog config={studentStatusConfig} title="Статус студента" />
    </Layout>
  );
};
