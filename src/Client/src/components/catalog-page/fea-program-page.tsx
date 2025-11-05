import Catalog from '../shared/catalog-provider/catalog';
import config from '../../storage/catalog-config/fea-program';
import { Layout } from '../shared/layout';

const FEAProgramPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="ВЭД программы" />
    </Layout>
  );
};

export default FEAProgramPage;
