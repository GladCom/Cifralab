import { Layout } from '../shared/layout';
import config from '../../storage/catalog-config/scope-of-activity';
import Catalog from '../shared/catalog-provider/catalog';

const ScopeOfActivityPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Сферы деятельности" />
    </Layout>
  );
};

export default ScopeOfActivityPage;
