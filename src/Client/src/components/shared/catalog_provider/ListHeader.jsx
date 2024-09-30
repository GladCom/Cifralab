import React from 'react';
import _ from 'lodash';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import cn from 'classnames';

const ListHeader = ({ columns }) => {
    return (
        <Row className="border-bottom border-primary">
            {
                columns.map((c) => {
                    const { icon } = c;
                    const Icon = icon.type;
                    const classes = cn('m-2', c.className);
                    
                    return (
                        <Col className={classes} style={c.style} key={_.uniqueId()}>
                            <Icon style={icon.style} />
                            <span>{c.info}</span>
                        </Col>
                    );
                })
            }
        </Row>
    );
};

export default ListHeader;