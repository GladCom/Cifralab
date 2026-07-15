import { educationFormConfig } from '../../storage/catalog-config/education-form';
import { Catalog } from '../../features/shared/catalog-provider/catalog';
import { Layout } from '../../features/shared/layout/layout';

export const EducationFormPage = () => {
  return (
    <Layout>
      <Catalog config={educationFormConfig} title="Формы образования" />
    </Layout>
  );
};
