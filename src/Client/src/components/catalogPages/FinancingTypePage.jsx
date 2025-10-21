import React from 'react';
import Layout from '../shared/layout/Layout.jsx';
import Catalog from '../shared/catalogProvider/Catalog.jsx';
import config from '../../storage/catalogConfigs/financingType.js';

const FinancingTypePage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Типы финансирования" />
    </Layout>
  );
};

export default FinancingTypePage;
