import { kindDocumentRiseQualificationConfig } from '../../storage/catalog-config/kind-document-rise-qualification';
import { Catalog } from '../../features/shared/catalog-provider/catalog';
import { Layout } from '../../features/shared/layout/layout';

export const KindDocumentRiseQualificationPage = () => {
  return (
    <Layout>
      <Catalog config={kindDocumentRiseQualificationConfig} title="Вид документа повышения квалификации" />
    </Layout>
  );
};
