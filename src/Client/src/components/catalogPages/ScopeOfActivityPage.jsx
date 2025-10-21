import React from 'react';
import { Layout } from '../shared/layout/index.js';
import Catalog from '../shared/catalogProvider/Catalog.jsx';
import config from '../../storage/catalogConfigs/scopeOfActivity.js';

const ScopeOfActivityPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Сферы деятельности" />
    </Layout>
  );
};

export default ScopeOfActivityPage;
