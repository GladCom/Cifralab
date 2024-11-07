import React from 'react';
import Layout from '../shared/layout/Layout.jsx';
import Catalog from '../shared/catalogProvider/Catalog.jsx';
import config from '../../storage/catalogConfigs/requestStatus.js'

const RequestStatusPage = () => {
    return (
        <Layout title="Статусы заявки">
            <Catalog config={config} />
        </Layout>
    );
};

export default RequestStatusPage;