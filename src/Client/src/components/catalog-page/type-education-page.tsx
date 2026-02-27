import { typeEducationConfig } from '../../storage/catalog-config/type-education';
import { Catalog } from '../shared/catalog-provider/catalog';
import { Layout } from '../shared/layout/layout';

export const TypeEducationPage = () => {
  return (
    <Layout>
      <Catalog config={typeEducationConfig} title="Тип образования" />
    </Layout>
  );
};
