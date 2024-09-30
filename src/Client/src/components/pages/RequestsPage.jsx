import Layout from '../shared/Layout';
import Catalog from '../catalog_provider/Catalog.jsx';
import { config } from '../../catalogs/requests.js'


const RequestsPage = () => {

    return (
        <Layout title="Заявки">
            <Catalog config={config} />
        </Layout>
    );
};

export default RequestsPage;