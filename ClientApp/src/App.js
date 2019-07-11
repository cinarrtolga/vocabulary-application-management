import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Login from './components/Login';

export default () => (
  <Layout>
    <Route exact path='/login' component={Login} />
  </Layout>
);
