import React from 'react';
import Layout from '../shared/layout/Layout';
import Catalog from '../shared/catalogProvider/Catalog';
import config from '../../storage/catalog-configs/studentStatus';

const StudentStatusPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Статус студента" />
    </Layout>
  );
};

export default StudentStatusPage;
