import React, { Component } from "react";
import axios from "axios";

class Home extends Component {
  state = {
    posts: [],
    error: null,
    postText: null,
    editBox: "",
    editMode: false
  };

  componentDidMount = () => {
    axios
      .get("/api/posts")
      .then(
        resp => this.setState({ posts: resp.data }),
        err => this.setState({ error: String(err) })
      );
  };

  submitPost = () => {
    let newPost = {
      userId: 1,
      postText: this.state.postText,
      location: "Culver City, CA",
      latitude: 123,
      longitude: 123
    };

    const myPromise = axios.post("/api/posts", newPost);

    myPromise
      .then(resp => {
        const postToAdd = {
          ...newPost,
          id: resp.data
        };
        const posts = [...this.state.posts, postToAdd];
        this.setState({ posts });
        console.log("Post posted!");
        this.setState({ postText: "" });
      })
      .catch(error => {
        console.log(error);
      });
  };

  deletePost = inputs => {
    const myPromise = axios.delete("/api/posts/" + inputs.id);

    myPromise
      .then(resp => {
        const posts = [
          ...this.state.posts.slice(0, inputs.index),
          ...this.state.posts.slice(inputs.index + 1)
        ];
        this.setState({ posts });
        console.log("Post deleted");
      })
      .catch(error => {
        console.log(error);
      });
  };

  savePost = inputs => {
    console.log(inputs.editBox);

    let editedPost = {
      id: inputs.id,
      userId: 1,
      postText: inputs.editBox,
      location: "Culver City, CA",
      latitude: 123,
      longitude: 123
    };

    const myPromise = axios.put("/api/posts/" + inputs.id, editedPost);

    myPromise.then(resp => {
      const index = this.state.posts.findIndex(post => post.id == inputs.id);

      const posts = [
        ...this.state.posts.slice(0, index),
        editedPost,
        ...this.state.posts.slice(index + 1)
      ];
      this.setState({ posts });
    });
  };

  render() {
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
          {this.state.posts.map((post, i) => {
            return (
              <div>
                <div>User Id: {post.userId}</div>
                <br />
                <div>{post.postText}</div>

                <br />

                {this.state.editMode && (
                  <input
                    type="text"
                    value={this.state.editBox}
                    onChange={e => this.setState({ editBox: e.target.value })}
                  />
                )}

                {!this.state.editMode && (
                  <button
                    className="editPost"
                    onClick={() => {
                      this.setState({
                        id: post.id,
                        index: i,
                        editMode: true,
                        editBox: post.postText
                      });
                    }}
                  >
                    EDIT
                  </button>
                )}

                {this.state.editMode && (
                  <button
                    className="cancelEdit"
                    onClick={() => {
                      this.setState({
                        editMode: false,
                        editBox: ""
                      });
                    }}
                  >
                    CANCEL
                  </button>
                )}

                {this.state.editMode && (
                  <button
                    className="savePost"
                    onClick={() => {
                      this.savePost({
                        id: post.id,
                        index: i,
                        editMode: true,
                        editBox: this.state.editBox
                      });
                      this.setState({ editMode: false, editBox: "" });
                    }}
                  >
                    SAVE
                  </button>
                )}

                <button
                  className="deletePost"
                  onClick={() =>
                    this.deletePost({
                      id: post.id,
                      index: i
                    })
                  }
                >
                  DELETE
                </button>
              </div>
            );
          })}
          <br />
        </div>
      </div>
    );
  }
}

export default Home;
