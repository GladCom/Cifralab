import React, { memo } from 'react';
import BaseComponent from './common/BaseComponent'; 

const String = memo((props) => (
    <BaseComponent
        { ...props }
    />
));
String.displayName = 'String';

export default String;
