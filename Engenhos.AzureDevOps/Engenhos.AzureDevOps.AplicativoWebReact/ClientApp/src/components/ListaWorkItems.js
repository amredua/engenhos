import React, { Component } from 'react';
import ReactDOM from 'react-dom';

export class ListaWorkItems extends Component {
    displayName = ListaWorkItems.name


    constructor(props) {
        super(props);
        this.state = { listaWorkItems: [], loading: true };

        fetch('api/WorkItem/Index')
            .then(response => response.json())
            .then(data => {
                this.setState({ listaWorkItems: data, loading: false });
            });

        this.componentDidMount = this.componentDidMount.bind(this);
    }

    componentDidMount() {
        fetch('api/WorkItem/ObterWorkItemsPorOrdenacao?nomeOrdenacao=' + "DataDESC")
            .then(response => response.json())
            .then(data => {
                this.setState({ listaWorkItems: data, loading: false });
            });
        
    }


    static renderListaWorkItemsTable(listaWorkItems) {
        return (
            <table className='table' >
                <thead>
                    <tr>
                        <th>Titulo</th>
                        <th>Tipo</th>
                        <th>Data Criação
                            <button onClick={() => this.componentDidMount}>Ordenar</button>
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
