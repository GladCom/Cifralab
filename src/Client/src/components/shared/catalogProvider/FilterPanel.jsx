import React, { useState, useCallback, useMemo, useEffect } from 'react';
import _ from 'lodash';
import { Flex, Button, Space } from 'antd';

const style = {
  height: '10vh',
  minHeight: '50px',
};

const FilterPanel = ({ config }) => {
  return (
    <>
      <Flex style={style} className="border-bottom border-primary">
        <Flex justify="center" align="center" style={{ width: '90%' }}>
          <span> </span>
        </Flex>
      </Flex>
    </>
  );
};

export default FilterPanel;
