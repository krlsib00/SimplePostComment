import React, { Component } from "react";
import logo from "./logo.svg";
import "./App.css";
import axios from "axios";

class App extends Component {
  state = {
    users: [],
    error: null
  };

  componentDidMount() {
    axios
      .get("/api/users")
      .then(
        resp => this.setState({ users: resp.data }),
        err => this.setState({ error: String(err) })
      );
  }

  render() {
    const { users, error } = this.state;

    return (
      <div className="App">
        {error && <span style={{ color: "red" }}>{error}</span>}
        {users.map(user => <div>{user.name}</div>)}
      </div>
    );
  }
}

export default App;
