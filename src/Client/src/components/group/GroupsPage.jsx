import React from 'react';
import { Layout, EntityTable } from '../shared/layout/index.js';
import config from '../../storage/catalogConfigs/groups.js'

const GroupsPage = () => {
    return (
        <Layout title="Группы">
            <EntityTable config={config} />
        </Layout>
    );
};

export default GroupsPage;