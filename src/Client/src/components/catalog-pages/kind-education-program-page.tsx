import React from 'react';
import Layout from '../shared/layout/Layout';
import Catalog from '../shared/catalogProvider/Catalog';
import config from '../../storage/catalog-configs/kindEducationProgram';

const KindEducationProgramPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Вид программы" />
    </Layout>
  );
};

export default KindEducationProgramPage;
