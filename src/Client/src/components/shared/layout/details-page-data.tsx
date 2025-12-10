import { ComponentType } from 'react';
import { Row, Col, Space } from 'antd';
import { DisplayMode } from '../control/multi-mode-control/types';
import { MultimodeControlProps } from '../control/multi-mode-control/multi-mode-control';
import { FormModel } from '../../../storage/form-model/types';

const rowStyle = {
  alignItems: 'center',
};

type DetailsPageDataProps = {
  items: FormModel;
  data: Array<any>;
  editData: (data: unknown) => void;
  setIsChanged: (value: boolean) => void;
};

export const DetailsPageData: React.FC<DetailsPageDataProps> = ({ items, data, editData, setIsChanged }) => {
  return (
    <Space direction="vertical" size={0} style={{ display: 'flex', paddingLeft: '3vh' }}>
      {Object.entries(items).map(([key, { name, type, formParams, controlParams }]) => {
        const Item: ComponentType<MultimodeControlProps> = type;

        return (
          <Row style={rowStyle} key={key}>
            <Col span={3}>{name}</Col>
            <Col span={8}>
              <Item
                key={key}
                value={data[key]}
                displayMode={DisplayMode.EDITABLE_VIEW}
                controlParams={controlParams}
                formParams={{ key, name, ...formParams }}
                setValue={(value) => {
                  editData({
                    ...data,
                    [key]: value,
                  });
                  setIsChanged(true);
                }}
              />
            </Col>
          </Row>
        );
      })}
    </Space>
  );
};
