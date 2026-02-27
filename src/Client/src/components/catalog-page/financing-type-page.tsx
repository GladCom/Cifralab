import { financingTypeConfig } from '../../storage/catalog-config/financing-type';
import { Catalog } from '../shared/catalog-provider/catalog';
import { Layout } from '../shared/layout/layout';

export const FinancingTypePage = () => {
  return (
    <Layout>
      <Catalog config={financingTypeConfig} title="Типы финансирования" />
    </Layout>
  );
};
