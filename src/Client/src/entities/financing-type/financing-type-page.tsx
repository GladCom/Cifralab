import { financingTypeConfig } from '../../storage/catalog-config/financing-type';
import { Catalog } from '../../features/shared/catalog-provider/catalog';
import { Layout } from '../../features/shared/layout/layout';

export const FinancingTypePage = () => {
  return (
    <Layout>
      <Catalog config={financingTypeConfig} title="Типы финансирования" />
    </Layout>
  );
};
