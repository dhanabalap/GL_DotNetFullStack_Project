import React from "react";
import { NavLink } from "react-router-dom";
import Select from "../elements/Select";
import { useState } from "react"; 

function AddTask({ glboalAllUsers, globalAllProjects }) {
  
  const [id, setId] = useState(6);
  const [projectID, setprojectID] = useState("");
  const [status, setStatus] = useState("Success");
  const [assignedToUserID, setAssignedToUserID] = useState("3"); 
  const [detail, setDetail] = useState(""); 
  const [createdOn, setCreatedOn] = useState("2022-02-05T17:45:32.846Z"); 
  const [message, setMessage] = useState("");
 
  const apiUrl = `${process.env.REACT_APP_API_URL}Task`;

  console.log(glboalAllUsers);
  console.log(globalAllProjects);
  
  let handleTaskSubmit = async (e) => {
    e.preventDefault();
    try {

      let postBody= JSON.stringify({ 
        id  : id,  
        projectID: projectID,
        status:status,
        assignedToUserID: assignedToUserID,
        detail: detail,
        createdOn: createdOn, 
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
        setprojectID("");
        setStatus("");
        setAssignedToUserID("");
        setDetail("");
        setCreatedOn(""); 
        setMessage("Project created successfully");
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
        <i className="fa fa-tasks"></i> New Task
      </h3>
      <hr className="mb-4" />
      <form onSubmit={handleTaskSubmit}>
        <div className="form-group mb-4 row">
          <label htmlFor="projectName" className="col-sm-2 col-form-label">
            Project
          </label>
          <div className="col-sm-4">
            <Select
              name="projectName"
              optionList={globalAllProjects}
              colKeys={["name"]}
              required
             // value={selectedOption}
              onChange={(e) => setDetail(e.target.value)}
            />
          </div>
        </div>
        <div className="form-group mb-4 row">
          <label htmlFor="projectName" className="col-sm-2 col-form-label">
            Assigned to User
          </label>
          <div className="col-sm-4">
            <Select
              name="userName"
              optionList={glboalAllUsers}
              colKeys={["firstName", "lastName"]}
              required
              value={["selectedOption"]}
              
              onChange={(e) => setDetail(e.target.value)}
            />
          </div>
        </div>
        <div className="form-group mb-4 row">
          <label htmlFor="taskDetails" className="col-sm-2 col-form-label">
            Details
          </label>
          <div className="col-sm-4">
            <textarea
              type="text"
              name="taskDetails"
              className="form-control"
              placeholder="Task Details"
              required
              value={detail}
              onChange={(e) => setDetail(e.target.value)}
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
            <span>{""}</span>
            <NavLink to="/tasks" className="btn btn-primary">
                Cancel
            </NavLink>
          </div>
        </div>
      </form>
    </div>
  );
}

export default AddTask;
