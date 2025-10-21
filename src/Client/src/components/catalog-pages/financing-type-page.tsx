import React from 'react';
import Layout from '../shared/layout/Layout';
import Catalog from '../shared/catalogProvider/Catalog';
import config from '../../storage/catalog-configs/financingType';

const FinancingTypePage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Типы финансирования" />
    </Layout>
  );
};

export default FinancingTypePage;
