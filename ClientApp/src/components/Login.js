import React, { Component } from 'react';
import { Button, Container, Col, Form, FormGroup, Input, Alert } from 'reactstrap';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { loginActions } from '../store/LoginReducers';
import '../Style/LoginStyle.css';

class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            username: '',
            password: '',
            loginControl: false
        }
    }

    checkLogin = () => {
        if (this.state.username.length > 0 && this.state.password.length > 0) {
            this.setState({ loginControl: false });
            this.props.getUserDetail(this.state.username, this.state.password);
        } else {
            this.setState({ loginControl: true });
        }
    }

    render() {
        return (
            <Container>
                <div className='sidenav'>
                    <div className='login-main-text'>
                        <h2>English Vocabulary<br />Cards Games</h2>
                        <p>Word management panel</p>
                    </div>
                </div>
                <div className='main'>
                    <Col md='6' sm='12'>
                        <div className='login-form'>
                            <Alert color="danger" isOpen={this.state.loginControl}>
                                Username and password requirement for login.
                            </Alert>
                            <Form>
                                <FormGroup>
                                    <Input
                                        type='text'
                                        className='form-control'
                                        placeholder='Username'
                                        value={this.state.username}
                                        onChange={e => this.setState({ username: e.target.value })}
                                    />
                                </FormGroup>
                                <FormGroup>
                                    <Input
                                        type='password'
                                        className='form-control'
                                        placeholder='Password'
                                        value={this.state.password}
                                        onChange={e => this.setState({ password: e.target.value })}
                                    />
                                </FormGroup>
                                <Button
                                    type='button'
                                    className='btn btn-black'
                                    onClick={this.checkLogin.bind(this)}
                                >
                                    Login
                                </Button>
                            </Form>
                        </div>
                    </Col>
                </div>
            </Container>
        );
    }
};

export default connect(
    state => state.returnState,
    dispatch => bindActionCreators(loginActions, dispatch)
)(Login);
