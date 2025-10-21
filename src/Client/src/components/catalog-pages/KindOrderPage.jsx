import React from 'react';
import Layout from '../shared/layout/Layout.jsx';
import Catalog from '../shared/catalogProvider/Catalog.jsx';
import config from '../../storage/catalog-configs/kindOrder.js';

const KindOrderPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Вид приказа" />
    </Layout>
  );
};

export default KindOrderPage;
