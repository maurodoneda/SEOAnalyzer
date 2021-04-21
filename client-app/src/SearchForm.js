import React, { Component } from "react";
import axios from "axios";

class SearchForm extends Component {
  constructor(props) {
    super(props);
    this.state = {
      searchTerm: "",
      urlToAnalyze: "",
      response: "",
    };
  }

  handleChangeSearch(e) {
    this.setState({
      searchTerm: e.target.value,
    });
  }

  handleChangeUrl(e) {
    this.setState({
      urlToAnalyze: e.target.value,
    });
  }

  handleSubmit = (event) => {
    event.preventDefault();

    let search = this.state.searchTerm;
    let url = this.state.urlToAnalyze;

    let uri = `https://localhost:5001/Search/GetSearchResults/?searchTerm=${search}&url=${url}`;
    axios.get(uri).then((res) => {
      console.log(res);
      console.log(res.data);
      this.setState({
        response: res.data,
      });
    });
  };

  render() {
    return (
      <div className="d-flex flex-collumn">
        <form onSubmit={this.handleSubmit}>
          <label>Search Term</label>
          <input
            className="form-control m-3"
            type="input"
            value={this.state.searchTerm}
            onChange={this.handleChangeSearch.bind(this)}
          />

          <label>Url to Analyze</label>
          <input
            className="form-control m-3"
            type="input"
            value={this.state.urlToAnalyze}
            onChange={this.handleChangeUrl.bind(this)}
          />
          <button className="btn btn-primary mt-2 px-5" type="submit">
            Search
          </button>
          <div>
            <br/>
            Google rank position of your search:
            <h2>{this.state.response}</h2>
          </div>
        </form>
      </div>
    );
  }
}

export default SearchForm;
