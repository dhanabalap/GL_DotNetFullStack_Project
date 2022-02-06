import React from "react";
import { NavLink } from "react-router-dom";
import { useState } from "react"; 

function AddProject() {
 
  const [id, setId] = useState(6);
  const [prjName, setPrjName] = useState("");
  const [prjDetail, setPrjDetail] = useState("");
  const [createdOn, setCreatedOn] = useState("2022-02-05T17:45:32.846Z"); 
  const [message, setMessage] = useState("");
 
  const apiUrl = `${process.env.REACT_APP_API_URL}Project`;
     
  
  let handleProjectSubmit = async (e) => {
    e.preventDefault();
    try {

      let postBody= JSON.stringify({ 
        id  : id,  
        name: prjName,
        detail: prjDetail,
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
        setPrjName("");
        setPrjDetail("");
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
        <i className="fa fa-briefcase"></i> New Project
      </h3>
      <hr className="mb-4" />
      <form onSubmit={handleProjectSubmit}>
        <div className="form-group mb-4 row">
          <label htmlFor="projectName" className="col-sm-1 col-form-label">
            Name
          </label>
          <div className="col-sm-3">
            <input
              type="text"
              name="projectName"
              className="form-control"
              placeholder="Project Name"
              required
              value={prjName}
              onChange={(e) => setPrjName(e.target.value)}
            />
          </div>
        </div>
        <div className="form-group mb-4 row">
          <label htmlFor="projectDetails" className="col-sm-1 col-form-label">
            Details
          </label>
          <div className="col-sm-3">
            <textarea
              type="text"
              name="projectDetails"
              className="form-control"
              placeholder="Project Details"
              required
              value={prjDetail}
              onChange={(e) => setPrjDetail(e.target.value)}
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
                Add Project
            </button>
            
            <span>{""}</span>
            <NavLink to="/projects" className="btn btn-primary">
               Cancel
            </NavLink>
          </div>
          <div className="message">{message ? <p>{message}</p> : null}</div>
        </div>
      </form>
    </div>
  );
}

export default AddProject;
