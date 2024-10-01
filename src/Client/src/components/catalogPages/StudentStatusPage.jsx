import React from 'react';
import Layout from '../shared/Layout.jsx';
import Catalog from '../shared/catalog_provider/Catalog.jsx';
import { config } from '../../catalogs/studentStatus.js'

const StudentStatusPage = () => {
    return (
        <Layout title="Статус студента">
            <Catalog config={config} />
        </Layout>
    );
};

export default StudentStatusPage;