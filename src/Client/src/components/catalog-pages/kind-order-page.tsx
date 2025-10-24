import React from 'react';
import Layout from '../shared/layout/Layout';
import config from '../../storage/catalog-configs/kind-order';
import Catalog from '../shared/catalog-provider/catalog';

const KindOrderPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Вид приказа" />
    </Layout>
  );
};

export default KindOrderPage;
