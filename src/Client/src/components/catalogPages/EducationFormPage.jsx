import React from 'react';
import Layout from '../shared/Layout';
import Catalog from '../shared/catalog_provider/Catalog.jsx';
import { config } from '../../catalogs/educationForm.js'

const EducationFormPage = () => {
    return (
        <Layout title="Формы образования">
            <Catalog config={config} />
        </Layout>
    );
};

export default EducationFormPage;