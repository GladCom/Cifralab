import React from 'react';
import _ from 'lodash';

const ListHeader = ({ columns }) => {
    return (
        <div className="row">
            {columns.map((c) => {
                const { icon } = c;
                const Icon = icon.type;
                return (
                    <div className={c.className} style={c.style} key={_.uniqueId()}>
                        <Icon style={icon.style} />
                        <span>{c.info}</span>
                    </div>
                );
            })}
        </div>
    );
};

export default ListHeader;