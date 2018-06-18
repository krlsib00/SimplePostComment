import React, { Component } from "react";
import { BrowserRouter } from "react-router-dom";
import { Route } from "react-router";
import "./App.css";
import './MyStyleSheet.css';
import Home from "./Home";


class App extends Component {
  render() {
    return (
      <BrowserRouter>
        <Route exact path="/home" component={Home} />
      </BrowserRouter>
    );
  }
}

export default App;
