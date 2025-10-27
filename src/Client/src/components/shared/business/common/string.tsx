import { memo } from 'react';
import { BaseControl } from '../base-controls/base-control';

const String = memo((props) => <BaseControl {...props} />);
String.displayName = 'String';

export default String;
