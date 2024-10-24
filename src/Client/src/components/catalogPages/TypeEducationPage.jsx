import React from 'react';
import Layout from '../shared/layout/Layout.jsx';
import Catalog from '../shared/catalogProvider/Catalog.jsx';
import config from '../../storage/catalogConfigs/typeEducation.js'

const TypeEducationPage = () => {
    return (
        <Layout title="Тип образования">
            <Catalog config={config} />
        </Layout>
    );
};

export default TypeEducationPage;