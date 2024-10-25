import React from 'react';
import Layout from '../shared/layout/Layout.jsx';
import FilterPanel from '../shared/filters/FilterPanel.jsx';
import RequestPanel from './RequestPanel.jsx';

const RequestServicePage = () => {
    return (
        <Layout title="Сервис обработки заявок">
            <FilterPanel />
            <RequestPanel />
        </Layout>
    );
};

export default RequestServicePage;