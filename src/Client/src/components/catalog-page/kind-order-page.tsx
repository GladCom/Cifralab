import { Layout } from '../shared/layout';
import config from '../../storage/catalog-config/kind-order';
import Catalog from '../shared/catalog-provider/catalog';

const KindOrderPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Вид приказа" />
    </Layout>
  );
};

export default KindOrderPage;
