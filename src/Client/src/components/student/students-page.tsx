import { studentConfig } from '../../storage/catalog-config/student';
import { EntityTable } from '../shared/layout/entity-table';
import { Layout } from '../shared/layout/layout';

export const StudentsPage = () => {
  return (
    <Layout>
      <EntityTable config={studentConfig} title="Обучающиеся" />
    </Layout>
  );
};
