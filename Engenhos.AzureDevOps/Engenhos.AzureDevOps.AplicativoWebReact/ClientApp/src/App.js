import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { ListaWorkItems } from './components/ListaWorkItems';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
            <Route exact  path='/' component={ListaWorkItems} />
      </Layout>
    );
  }
}
