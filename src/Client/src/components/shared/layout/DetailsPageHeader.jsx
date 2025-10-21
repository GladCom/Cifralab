import React from 'react';
import { Flex } from 'antd';

const style = {
  height: '7vh',
  minHeight: '50px',
  padding: '1vh',
};

const DetailsPageHeader = ({ title }) => {
  return (
    <Flex justify="left" align="center" style={style} className="border-bottom border-primary">
      <h3 style={{ margin: '2vh', fontSize: '1.5rem' }}>{title}</h3>
    </Flex>
  );
};

export default DetailsPageHeader;
