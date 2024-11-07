import React from 'react';
import Layout from '../shared/layout/Layout.jsx';
import Catalog from '../shared/catalogProvider/Catalog.jsx';
import config from '../../storage/catalogConfigs/educationForm.js'

const EducationFormPage = () => {
    return (
        <Layout title="Формы образования">
            <Catalog config={config} />
        </Layout>
    );
};

export default EducationFormPage;