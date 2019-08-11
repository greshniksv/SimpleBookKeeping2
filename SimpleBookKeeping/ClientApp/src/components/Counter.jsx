import React, { Component } from 'react';
import Datetime from "./DateTime"

export class Counter extends Component {
    displayName = Counter.name

    constructor(props) {
        super(props);
        this.state = { currentCount: 0 };
        this.incrementCounter = this.incrementCounter.bind(this);

        //window.fetch('api/SampleData/GetData')
        //    .then(response => response.text())
        //    .then(data => {
        //        console.log(">>> Fetch ", data);
        //        this.setState({ currentCount: 0, date: data, loading: false });
        //    });
    }

    incrementCounter() {
        this.setState({
            currentCount: this.state.currentCount + 1
        });
    }

    render() {
        return (
            <div>
                <Datetime />

                <h1>Counter</h1>

                <p>This is a simple example of a React component.</p>

                <p>Current count: <strong>{this.state.currentCount}</strong></p>

                <button onClick={this.incrementCounter}>Increment</button>

            </div>
        );
    }
}
