import React, { Children, useState, useCallback } from 'react';
import Stack from 'react-bootstrap/Stack';

const BusinessComponent = ({ children }) => {
    const [editingMode, setEditingMode] = useState(false);
    const [value, setValue] = useState(initValue);
    const [valueChanged, setValueChanged] = useState(false);

    const changeValue = useCallback((componentValue, editingMode, changed) => {
        setValue(value);
        setComponentValue(componentValue);
        setEditingMode(editingMode);
        setValueChanged(changed);
    });

    console.log(children[0])
    const Info = () => React.cloneElement(children[0], null);
    console.log(Info)

    return (
        <Stack>
            {Info}
            {children[1]}
        </Stack>
    );
};

export default BusinessComponent;