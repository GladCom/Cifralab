import React from 'react';
import Layout from '../shared/Layout';
import Catalog from '../shared/catalogProvider/Catalog.jsx';
import config from '../../storage/catalogConfigs/groups.js'

const GroupsPage = () => {
    return (
        <Layout title="Группы">
            <Catalog config={config} />
        </Layout>
    );
};

export default GroupsPage;