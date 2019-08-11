﻿import React, { Component } from 'react';
import { Formik, Field, Form, ErrorMessage } from 'formik';
import * as Yup from 'yup';
import loading  from '../../images/loading.gif';

export class Login extends Component {
    displayName = Login.name

    constructor(props) {
        super(props);
        //this.state = { isSubmitting: false, status: "", login: "", password: "" };
    }

    render() {
        return (
            <div>
                <h1>Overview</h1>

                <Formik
                    initialValues={{
                        username: '',
                        password: ''
                    }}
                    validationSchema={Yup.object().shape({
                        username: Yup.string().required('Username is required'),
                        password: Yup.string().required('Password is required')
                    })}
                    onSubmit={({ username, password }, { setStatus, setSubmitting }) => {
                        setStatus();
                        console.log(username, password);
                        //setSubmitting(false);
                        //setStatus("error");

                        //authenticationService.login(username, password)
                        //    .then(
                        //        user => {
                        //            const { from } = this.props.location.state || { from: { pathname: "/" } };
                        //            this.props.history.push(from);
                        //        },
                        //        error => {
                        //            setSubmitting(false);
                        //            setStatus(error);
                        //        }
                        //    );
                    }}
                    render={({ errors, status, touched, isSubmitting }) => (
                        <Form>
                            <div className="form-group">
                                <label htmlFor="username">Username</label>
                                <Field name="username" type="text" className={'form-control' + (errors.username && touched.username ? ' is-invalid' : '')} />
                                <ErrorMessage name="username" component="div" className="invalid-feedback" />
                            </div>
                            <div className="form-group">
                                <label htmlFor="password">Password</label>
                                <Field name="password" type="password" className={'form-control' + (errors.password && touched.password ? ' is-invalid' : '')} />
                                <ErrorMessage name="password" component="div" className="invalid-feedback" />
                            </div>
                            <div className="form-group">
                                <button type="submit" className="btn btn-primary" disabled={isSubmitting}>Login</button>
                                {isSubmitting &&
                                    <img src={loading} alt="loading"/>
                                }
                            </div>
                            {status &&
                                <div className={'alert alert-danger'}>{status}</div>
                            }
                        </Form>
                    )}
                />

            </div>
        );
    }
}