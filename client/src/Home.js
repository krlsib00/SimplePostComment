import React, { Component } from "react";
import axios from "axios";

class Home extends Component {
  state = {
    users: [],
    error: null,
    postText: null
  };

  componentDidMount = () => {
    axios
      .get("/api/users")
      .then(
        resp => this.setState({ users: resp.data }),
        err => this.setState({ error: String(err) })
      );
  };

  submitPost = () => {
    let newPost = {
      userId: 1,
      postText: this.state.postText,
      location: "Culver City, CA",
      latitude: 123.456789,
      longitude: 123.456789
    };

    const myPromise = 

  };

  render() {
    const { users, error } = this.state;

    return (
      <div className="body">
        <div className="my-grid">
          <div className="inputDiv">
            <textarea
              className="inputBox"
              onChange={e => this.setState({ postText: e.target.value })}
              rows="2"
              placeholder="What's up?"
              value={this.state.postText}
            />

            <button className="postButton" onClick={() => this.submitPost()}>
              POST
            </button>
          </div>
          {users.map(user => <div>{user.firstName}</div>)}
          <br />
        </div>
      </div>
    );
  }
}

export default Home;
