import React from 'react';
import Layout from '../shared/layout/Layout';
import Catalog from '../shared/catalogProvider/Catalog';
import config from '../../storage/catalog-configs/educationForm';

const EducationFormPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Формы образования" />
    </Layout>
  );
};

export default EducationFormPage;
