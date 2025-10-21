import React from 'react';
import Layout from '../shared/layout/Layout';
import Catalog from '../shared/catalogProvider/Catalog';
import config from '../../storage/catalog-configs/kindOrder';

const KindOrderPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Вид приказа" />
    </Layout>
  );
};

export default KindOrderPage;
