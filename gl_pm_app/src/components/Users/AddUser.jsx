import React from "react";
import { NavLink } from "react-router-dom";
import { useState } from "react";

function AddUser() {

  const [Id, setId] = useState("1");
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [message, setMessage] = useState("");

  const apiUrl = `${process.env.REACT_APP_API_URL}User`;

  let handleSubmit = async (e) => {
    e.preventDefault();
    try {

      let postBody=JSON.stringify({ 
        Id  : Id,  
        firstName: firstName,
        lastName: lastName,
        email: email,
        password: password,
    });
      console.log(postBody);
      let res = await fetch(apiUrl, {
        method: 'POST',
        cache: "no-cache",
        headers:{
                    "accept":"*/*",
                    "Content-Type": "application/json"
                },
           body: postBody, 
      });
      
      console.log(res);
      let resJson = await res.json();
      console.log(resJson);

      if (res.status === 201) {
        setFirstName("");
        setLastName("");
        setEmail("");
        setPassword("");
        setMessage("User created successfully");
      } else {
        setMessage("Some error occured");
      }
    } catch (err) {
      console.log(err);
    }
  };
 
  return (
    <div className="mt-4" style={{ marginRight: "40px" }}>
      <h3 className="text-primary">
        <i className="fa fa-user"></i> New User
      </h3>
      <hr className="mb-4" />
      <form onSubmit={handleSubmit}>
        <div className="form-group mb-4 row">
          <label htmlFor="firstName" className="col-sm-1 col-form-label">
            First Name
          </label>
          <div className="col-sm-3"> 
          <input
            type="text"
            name="firstName"
            value={firstName}
            className="form-control"
            placeholder="firstName"
            required
            onChange={(e) => setFirstName(e.target.value)}
          />

          </div>
        </div>
        <div className="form-group mb-4 row">
          <label htmlFor="lastName" className="col-sm-1 col-form-label">
            Last Name
          </label>
          <div className="col-sm-3">
            <input
              type="text"
              name="lastName"
              value={lastName}
              className="form-control"
              placeholder="Last Name"
              required
              onChange={(e) => setLastName(e.target.value)}
            />
          </div>
        </div>
        <div className="form-group mb-4 row">
          <label htmlFor="email" className="col-sm-1 col-form-label">
            Email
          </label>
          <div className="col-sm-3">
            <input
              type="email"
              name="email"
              value={email}
              className="form-control"
              placeholder="Email"
              required
              onChange={(e) => setEmail(e.target.value)}
            />
          </div>
        </div>
        <div className="form-group mb-4 row">
          <label htmlFor="password" className="col-sm-1 col-form-label">
            Password
          </label>
          <div className="col-sm-3">
            <input
              type="password"
              name="password"
              value={password}
              className="form-control"
              placeholder="Password"
              required
              onChange={(e) => setPassword(e.target.value)}
            />
          </div>
        </div>
        <div className="form-group row">
          <div className="col-sm-2 mt-4">
            <button
              type="submit"
              className="btn btn-primary"
              style={{ marginRight: "25px" }}
            >
               Save
            </button>
            <div className="message">{message ? <p>{message}</p> : null}</div>
            <span>{""}</span>
            <NavLink to="/users" className="btn btn-primary">
                Cancel
            </NavLink>
          </div>
        </div>
      </form>
    </div>
  );
}

export default AddUser;
