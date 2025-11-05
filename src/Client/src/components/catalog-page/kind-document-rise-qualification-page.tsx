import { Layout } from '../shared/layout';
import config from '../../storage/catalog-config/kind-document-rise-qualification';
import Catalog from '../shared/catalog-provider/catalog';

const KindDocumentRiseQualificationPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Вид документа повышения квалификации" />
    </Layout>
  );
};

export default KindDocumentRiseQualificationPage;
