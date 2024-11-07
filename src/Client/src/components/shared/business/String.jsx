import React, { memo } from 'react';
import BaseComponent from './baseComponents/BaseComponent'; 

const String = memo((props) => (
    <BaseComponent
        {...props}
    />
));
String.displayName = 'String';

export default String;
