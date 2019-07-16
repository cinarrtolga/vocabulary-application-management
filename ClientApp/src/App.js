import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import LoginPage from './components/LoginPage';
import WordsPage from './components/WordsPage';

export default () => (
  <Layout>
    <Route exact path='/login' component={LoginPage} />
    <Route exact path='/words' component={WordsPage} />
  </Layout>
);
