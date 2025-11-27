import { Layout } from '../shared/layout';
import Catalog from '../shared/catalog-provider/catalog';
import config from '../../storage/catalog-config/financing-type';

const FinancingTypePage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Типы финансирования" />
    </Layout>
  );
};

export default FinancingTypePage;
