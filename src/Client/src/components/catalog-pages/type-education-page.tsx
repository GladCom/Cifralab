import React from 'react';
import Layout from '../shared/layout/Layout.jsx';
import Catalog from '../shared/catalogProvider/Catalog.jsx';
import config from '../../storage/catalog-configs/typeEducation.js';

const TypeEducationPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Тип образования" />
    </Layout>
  );
};

export default TypeEducationPage;
