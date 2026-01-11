import { Layout, EntityTable } from '../shared/layout/index';
import config from '../../storage/catalog-config/group';

const GroupsPage = () => {
  return (
    <Layout>
      <EntityTable config={config} title="Группы" />
    </Layout>
  );
};

export default GroupsPage;
