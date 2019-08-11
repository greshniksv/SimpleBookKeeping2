import React, { Component } from 'react';

export class Overview extends Component {
    displayName = Overview.name

    constructor(props) {
        super(props);
        this.state = { currentCount: 0 };

    }

    render() {
        return (
            <div>
                <h1>Overview</h1>
            </div>
        );
    }
}