import { Layout } from '../shared/layout';
import config from '../../storage/catalog-config/type-education';
import Catalog from '../shared/catalog-provider/catalog';

const TypeEducationPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Тип образования" />
    </Layout>
  );
};

export default TypeEducationPage;
