import { Layout } from '../shared/layout';
import config from '../../storage/catalog-config/student-status';
import Catalog from '../shared/catalog-provider/catalog';

const StudentStatusPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Статус студента" />
    </Layout>
  );
};

export default StudentStatusPage;
