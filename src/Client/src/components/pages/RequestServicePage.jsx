import React from 'react';
import Layout from '../shared/Layout';
import FilterPanel from '../shared/filters/FilterPanel.jsx';
import RequestPanel from '../requests/RequestPanel.jsx';
import RequestStatus from '../requests/filters/RequestStatus.jsx';
import EntranceTestStatus from '../requests/filters/EntranceTestStatus.jsx';
import EducationProgram from '../requests/filters/EducationProgram.jsx';

const RequestServicePage = () => {
    return (
        <Layout title="Сервис обработки заявок">
            <FilterPanel />
            <RequestPanel />
        </Layout>
    );
};

export default RequestServicePage;