import { scopeOfActivityConfig } from '../../storage/catalog-config/scope-of-activity';
import { Catalog } from '../shared/catalog-provider/catalog';
import { Layout } from '../shared/layout/layout';

export const ScopeOfActivityPage = () => {
  return (
    <Layout>
      <Catalog config={scopeOfActivityConfig} title="Сферы деятельности" />
    </Layout>
  );
};
