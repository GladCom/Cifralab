import React from 'react';
import { Layout } from '../shared/layout/index';
import Catalog from '../shared/catalogProvider/Catalog';
import config from '../../storage/catalog-configs/scopeOfActivity';

const ScopeOfActivityPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Сферы деятельности" />
    </Layout>
  );
};

export default ScopeOfActivityPage;
