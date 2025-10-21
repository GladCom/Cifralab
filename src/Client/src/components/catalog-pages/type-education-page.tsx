import React from 'react';
import Layout from '../shared/layout/Layout';
import Catalog from '../shared/catalogProvider/Catalog';
import config from '../../storage/catalog-configs/typeEducation';

const TypeEducationPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Тип образования" />
    </Layout>
  );
};

export default TypeEducationPage;
