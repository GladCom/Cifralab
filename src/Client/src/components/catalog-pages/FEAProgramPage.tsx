import React from 'react';
import Layout from '../shared/layout/Layout.jsx';
import Catalog from '../shared/catalogProvider/Catalog.jsx';
import config from '../../storage/catalog-configs/feaProgram.js';

const FEAProgramPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="ВЭД программы" />
    </Layout>
  );
};

export default FEAProgramPage;
