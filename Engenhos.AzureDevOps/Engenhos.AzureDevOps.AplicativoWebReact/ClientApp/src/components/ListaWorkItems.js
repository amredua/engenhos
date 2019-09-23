import React, { Component } from 'react';

export class ListaWorkItems extends Component {
    displayName = ListaWorkItems.name


    constructor(props) {
        super(props);
        this.state = { listaWorkItems: [], loading: true, isOldestFirst: true};

        fetch('api/WorkItem/Index')
            .then(response => response.json())
            .then(data => {
                this.setState({ listaWorkItems: data, loading: false, isOldestFirst: true});
            });

        this.toggleListReverse = this.toggleListReverse.bind(this);
        this.toggleSortDate = this.toggleSortDate.bind(this);
    }

    sortByDate() {

        const { listaWorkItems } = this.state;
        let newListaWorkItems = listaWorkItems;

        if (this.state.isOldestFirst) {
            newListaWorkItems = listaWorkItems.sort((a, b) => a.dataCriacaoWorkItem > b.dataCriacaoWorkItem);
        } else {
            newListaWorkItems = listaWorkItems.sort((a, b) => a.dataCriacaoWorkItem < b.dataCriacaoWorkItem);
        }

        this.setState({
            isOldestFirst: !this.state.isOldestFirst,
            listaWorkItems: newListaWorkItems
        });
    }

    toggleSortDate() {
        this.sortByDate();
            }

    toggleListReverse() {
        const { listaWorkItems } = this.state;
        let newListaWorkItems = listaWorkItems;
        this.setState({
            listaWorkItems: newListaWorkItems
        });
            }

    static renderListaWorkItemsTable(listaWorkItems) {
        return (
            <table className = 'table' >
                        <thead>
                            <tr>
                                <th>Titulo</th>
                                <th>Tipo</th>
                                <th>Data Criação
                            <button onClick={this.toggleSortDate}>Order by date</button>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            {listaWorkItems.map((work, index) =>
                                <tr key={work.idWorkItem}>
                                    <td>{work.titulo}</td>
                                    <td>{work.tipo}</td>
                                    <td>{work.dataCriacaoWorkItem}</td>
                                </tr>
                            )}
                        </tbody>
            </table>
           
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : ListaWorkItems.renderListaWorkItemsTable(this.state.listaWorkItems);

        return (
            <div>
                <h1>AZURE DEVOPS</h1>
                <p>Lista de todos os WorkItems</p>
                {contents}
            </div>
        );
    }
}
