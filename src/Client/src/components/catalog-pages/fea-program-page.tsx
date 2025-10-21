import React from 'react';
import Layout from '../shared/layout/Layout';
import Catalog from '../shared/catalogProvider/Catalog';
import config from '../../storage/catalog-configs/feaProgram';

const FEAProgramPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="ВЭД программы" />
    </Layout>
  );
};

export default FEAProgramPage;
