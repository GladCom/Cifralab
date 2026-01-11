import { personRequestConfig } from '../../storage/catalog-config/person-request';
import { Layout, EntityTable } from '../shared/layout/index';

const PersonRequestsPage = () => {
  return (
    <Layout>
      <EntityTable config={personRequestConfig} title="Заявки" />
    </Layout>
  );
};

export default PersonRequestsPage;
