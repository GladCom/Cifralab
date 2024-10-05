import React, { useState, useCallback, useMemo, useEffect } from 'react';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';
import cn from 'classnames';

const Item = ({ config, data, setItem, showDialog, onClick }) => {
    const { id } = data;
    const { fields, crud } = config;
    const containerClss = cn('mb-2', 'border-bottom');

    return (
        <Container 
            className={containerClss}
            key={id}
        >
            <Row>
                {
                    fields.map((c) => {
                        const classes = cn('m-2', c.className);
                        const Component = c.component;
                        return (
                            <Col className={classes}>
                                <Component id={id} value={data[c.property]} mode={c.mode} crud={crud} />
                            </Col>
                        );
                    })
                }
                <Col className="auto d-flex justify-content-end">
                    <Button
                        size="sm"
                        className="m-3"
                        type="button"
                        variant="outline-secondary"
                        onClick={() => {
                            onClick(id);
                            setItem(id);
                        }}
                    >
                        Править
                    </Button>
                    <Button
                        size="sm"
                        className="m-3"
                        type="button"
                        variant="outline-danger"
                        onClick={() => {
                            setItem(id);
                            showDialog(true);
                        }}
                    >
                        Удалить
                    </Button>
                </Col>
            </Row>
        </Container>
    );
};

export default Item;