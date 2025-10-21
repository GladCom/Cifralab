import React from 'react';
import { Layout } from '../shared/layout/index.js';
import Catalog from '../shared/catalogProvider/Catalog.jsx';
import config from '../../storage/catalog-configs/scopeOfActivity.js';

const ScopeOfActivityPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Сферы деятельности" />
    </Layout>
  );
};

export default ScopeOfActivityPage;
