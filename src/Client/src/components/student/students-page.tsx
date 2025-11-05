import { Layout, EntityTable } from '../shared/layout/index';
import config from '../../storage/catalog-config/student';

const StudentsPage = () => {
  return (
    <Layout>
      <EntityTable config={config} title="Обучающиеся" />
    </Layout>
  );
};

export default StudentsPage;
