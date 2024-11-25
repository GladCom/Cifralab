import React from 'react';
import Layout from '../shared/layout/Layout.jsx';
import Catalog from '../shared/catalogProvider/Catalog.jsx';
import config from '../../storage/catalogConfigs/kindEducationProgram.js'

const KindEducationProgramPage = () => {
    return (
        <Layout title="Вид программы">
            <Catalog config={config} />
        </Layout>
    );
};

export default KindEducationProgramPage;