import { scopeOfActivityConfig } from '../../storage/catalog-config/scope-of-activity';
import { Catalog } from '../../features/shared/catalog-provider/catalog';
import { Layout } from '../../features/shared/layout/layout';

export const ScopeOfActivityPage = () => {
  return (
    <Layout>
      <Catalog config={scopeOfActivityConfig} title="Сферы деятельности" />
    </Layout>
  );
};
