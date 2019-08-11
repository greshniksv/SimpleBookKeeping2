import React, { Component } from 'react';
import DateTimePicker from 'react-datetime-picker';
import axios from "axios";

export default class DateTime extends Component {
    displayName = DateTime.name

    constructor(props) {
        super(props);
        this.state = { date: new Date(), loading: true, saving: false };
        //this.incrementCounter = this.incrementCounter.bind(this);

        window.fetch('api/SampleData/GetData')
            .then(response => response.json())
            .then(data => {
                console.log(">>> Fetch ", data);
                this.setState({ currentCount: 0, date: new Date(data.value), loading: false });
            });
    }

    onChange(date) {
        console.log(">>>", date);
        this.setState({ date: date });
    }

    onSave(date) {
        console.log(">>> ", "Save -> ", this.state.date);
        this.setState({ saving: true });
        var self = this;
        axios.post('api/SampleData/SetData',
            {
                value: this.state.date
            }).then(function (response) {
                self.setState({ saving: false });
            });
        

        //window.fetch('api/SampleData/SetData',
        //    {
        //        method: 'POST',
        //        headers: {
        //            'Accept': 'application/json',
        //            'Content-Type': 'application/json'
        //        },
        //        body: JSON.stringify({
        //            value: this.state.date
        //        })
        //    });
    }

    render() {

        var content = this.state.loading
            ? <p><em>Loading...</em></p>
            : <DateTimePicker
                onChange={date => this.onChange(date)}
                value={this.state.date}
                disableClock={true}
                format={"dd-MM-yyyy HH:mm"}
            />;

        var button = this.state.saving
            ? <p><em>Saving...</em></p>
            : <button onClick={() => this.onSave(this.state.date)}> Save </button>;

        return (
            <div>
                <h1>DateTimePicker</h1>

                {content}
                {button}

            </div>
        );
    }
}