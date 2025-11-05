import { Layout } from '../shared/layout';
import config from '../../storage/catalog-config/kind-document-rise-qualification';
import Catalog from '../shared/catalog-provider/catalog';

const KindEducationProgramPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Вид программы" />
    </Layout>
  );
};

export default KindEducationProgramPage;
