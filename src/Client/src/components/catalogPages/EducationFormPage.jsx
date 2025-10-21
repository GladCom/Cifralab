import React from 'react';
import Layout from '../shared/layout/Layout.jsx';
import Catalog from '../shared/catalogProvider/Catalog.jsx';
import config from '../../storage/catalogConfigs/educationForm.js';

const EducationFormPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Формы образования" />
    </Layout>
  );
};

export default EducationFormPage;
