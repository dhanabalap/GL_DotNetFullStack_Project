import React from "react";
import { NavLink } from "react-router-dom";

function SideRoutes({ userName, logout }) {
  return ( 
    
    <div className="">
      <div className="col">
        <div className="wrapper">
          <nav id="sidebar">
            <div className="sidebar-header">
              <h4>Hello, {userName}!</h4>
            </div>

            <div
              style={{
                padding: "20px",
                fontSize: "1.1rem",
                fontWeight: "bold",
              }}
            >
              <NavLink exact="true" className="nav-link" to="/">
                 Home
              </NavLink>
              <NavLink className="nav-link" to="/users">
                 Users
              </NavLink>
              <NavLink className="nav-link" to="/projects">
                 Projects
              </NavLink>
              <NavLink className="nav-link" to="/tasks">
                 Tasks
              </NavLink>
            </div>
            <div
              className="d-flex justify-content-center"
              style={{ marginTop: "50%" }}
            >
              <NavLink
                className="btn btn-outline-primary my-2 my-sm-0"
                style={{ marginRight: "20px" }}
                type="button"
                to="/"
                onClick={logout}
              >
                Logout
              </NavLink>
            </div>
          </nav>
        </div>
      </div>
      <div className="col-sm-8">Col.8sm </div>
    </div>
  );
}

export default SideRoutes;
