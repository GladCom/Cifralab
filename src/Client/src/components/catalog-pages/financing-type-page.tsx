import React from 'react';
import Layout from '../shared/layout/Layout';
import Catalog from '../shared/catalog-provider/catalog';
import config from '../../storage/catalog-configs/financing-type';

const FinancingTypePage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Типы финансирования" />
    </Layout>
  );
};

export default FinancingTypePage;
