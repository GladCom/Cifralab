import React from 'react';
import Layout from '../shared/layout/Layout.jsx';
import Catalog from '../shared/catalogProvider/Catalog.jsx';
import config from '../../storage/catalogConfigs/studentStatus.js'

const StudentStatusPage = () => {
    return (
        <Layout title="Статус студента">
            <Catalog config={config} />
        </Layout>
    );
};

export default StudentStatusPage;