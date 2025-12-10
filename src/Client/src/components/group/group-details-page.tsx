import { useState, useEffect, useCallback } from 'react';
import { Layout, Loading, RoutingWarningModal, DetailsPageHeader } from '../shared/layout/index';
import { useParams, useBlocker } from 'react-router-dom';
import { Row, Col, Button } from 'antd';
import config from '../../storage/catalog-config/group';
import type { Group } from '../../storage/service/types';
import { DetailsPageData } from '../shared/layout/details-page-data';

const GroupDetailsPage = () => {
  const { id } = useParams();
  const [groupData, setGroupData] = useState<Group>();
  const [initialData, setInitialData] = useState<Group>();
  const [isChanged, setIsChanged] = useState(false);
  const { formModel, crud } = config;
  const { useGetOneByIdAsync, useEditOneAsync } = crud;
  const { data, isLoading, isFetching } = useGetOneByIdAsync(id);

  const [editGroup] = useEditOneAsync();

  useEffect(() => {
    if (!isLoading && !isFetching) {
      const newData = { ...data };
      delete newData.id;
      setGroupData(newData);
      setInitialData(newData);
    }
  }, [isLoading, isFetching, data]);

  let blocker = useBlocker(
    ({ currentLocation, nextLocation }) => isChanged && currentLocation.pathname !== nextLocation.pathname,
  );

  const onSave = useCallback(() => {
    editGroup({ id, item: groupData });
    setIsChanged(false);
  }, [id, groupData, editGroup]);

  const onCancel = useCallback(() => {
    setGroupData(initialData);
    setIsChanged(false);
  }, [initialData]);

  if (!groupData) {
    return <Loading />;
  }

  const title = `Группы - ${groupData?.name}`;

  return isLoading || isFetching ? (
    <Loading />
  ) : (
    <Layout>
      <DetailsPageHeader title={title} />
      <h2 style={{ padding: '3vh' }}>{groupData?.name}</h2>
      <DetailsPageData items={formModel} data={groupData} editData={setGroupData} setIsChanged={setIsChanged} />
      <hr />
      <Row>
        <Col>
          <Button onClick={onSave} style={{ marginRight: '10px' }}>
            Сохранить
          </Button>
        </Col>
        <Col>
          <Button onClick={onCancel}>Отмена</Button>
        </Col>
      </Row>
      <RoutingWarningModal show={blocker.state === 'blocked'} blocker={blocker} />
    </Layout>
  );
};

export default GroupDetailsPage;
