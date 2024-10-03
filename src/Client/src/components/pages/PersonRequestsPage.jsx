import Layout from '../shared/Layout.jsx';
import Catalog from '../catalog_provider/Catalog.jsx';
import { config } from '../../catalogs/personrequests.js'


const PersonRequestsPage = () => {

    return (
        <Layout title="Заявки">
            <Catalog config={config} />
        </Layout>
    );
};

export default PersonRequestsPage;