import React from 'react';
import Layout from '../shared/Layout.jsx';
import Catalog from '../shared/catalogProvider/Catalog.jsx';
import config from '../../storage/catalogConfigs/educationPrograms.js'

const ProgramsPage = () => {
    return (
        <Layout title="Программы">
            <Catalog config={config} />
        </Layout>
    );
};

export default ProgramsPage;