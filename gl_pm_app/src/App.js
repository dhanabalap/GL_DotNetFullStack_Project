import React, { useState, useEffect } from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import "font-awesome/css/font-awesome.min.css";
import Home from "./components/Layout/Home";
import Users from "./components/Users/Users";
import AddUser from "./components/Users/AddUser";
import UpdateUser from "./components/Users/UpdateUser";
import Projects from "./components/Projects/Projects";
import AddProject from "./components/Projects/AddProject";
import UpdateProject from "./components/Projects/UpdateProject";
import Tasks from "./components/Tasks/Tasks";
import AddTask from "./components/Tasks/AddTask";
import UpdateTask from "./components/Tasks/UpdateTask";
import FetchComponent from "./components/elements/FetchComponent"; 
import SideRoutes from "./components/Layout/SideRoutes";

function App() {
  
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [isLoading, setIsLoading] = useState(false);
  const [errorMsg, setErrorMsg] = useState("");  
  const [userDetails, setUserDetails] = useState({});
  const [allProjects, setAllProjects] = useState([]);
  const [allUsers, setAllUsers] = useState([]);
  const [fName ,setFName] =useState("");

  const Logout = () => {
    setIsLoggedIn(false);
    setUserDetails({});
  };

  useEffect(() => {
    setIsLoggedIn(JSON.parse(localStorage.getItem("isLoggedIn")));
    setUserDetails({ firstName: localStorage.getItem("userFirstName") });
  }, []);

  useEffect(() => {
    localStorage.setItem("isLoggedIn", isLoggedIn);
  }, [isLoggedIn]);

  useEffect(() => {
    if (userDetails) {
      localStorage.setItem("userFirstName", userDetails.firstName);
    }
  }, [userDetails]);

  const loginSubmitHandler = async (e) => {
    e.preventDefault();
    setIsLoading(true);
    setErrorMsg("");
    const apiUrl = `${process.env.REACT_APP_API_URL}User/userLogin?email=${e.target.email.value}&password=${e.target.password.value}`;
    const res = await FetchComponent(apiUrl).catch(() => {
      setErrorMsg("Unable to reach authentication server. Please try again!");
      setIsLoggedIn(false);
      setIsLoading(false);
    });
    if (res !== undefined) {
      console.log(res);
      if (res.ok) {
        setIsLoggedIn(true);
        res.json().then((data) => {
          console.log(data);
          setUserDetails(data);
        });
        setIsLoading(false);
        console.log('UserDetailset');
        console.log({userDetails});        
        //console.log(userDetails.map((post) =>{post.title}));

        res.json().then((data) => {
          if (data.status === 401) {
            setErrorMsg("Invalid Credentials.");
          } else {
            setErrorMsg(data);
          }
          setIsLoggedIn(false);
          setIsLoading(false);
        });
      }
    }
  };

 

  return (
    <div>
    {isLoggedIn ? (
      <div className="d-flex">
        <Router>
      <div className="col-2" style={{ height: "100vh" }}>
        <SideRoutes
        userName={
          userDetails.firstName != null ? userDetails.firstName : ""
        }
        logout={Logout}
        />
      </div>
          <div className="col mt-4">
            <Routes>
              <Route exact="true" path="/" element={<Home />} />
              <Route path="/users" element={<Users />} />
              <Route path="/users/add" element={<AddUser />} />
              <Route path="/users/update" element={<UpdateUser />} />
              <Route path="/projects" element={<Projects />} />
              <Route path="/projects/add" element={<AddProject />} />
              <Route path="/projects/update" element={<UpdateProject />} />
              <Route
                path="/tasks"
                element={
                  <Tasks
                    setAllProjects={setAllProjects}
                    setAllUsers={setAllUsers}
                  />
                }
              />
              <Route
                path="/tasks/add"
                element={
                  <AddTask
                    allUsers={allUsers}
                    allProjects={allProjects}
                  />
                }
              />
              <Route
                path="/tasks/update"
                element={
                  <UpdateTask
                    allUsers={allUsers}
                    allProjects={allProjects}
                  />
                }
              />
            </Routes>
          </div>
        </Router>
      </div>
    ) : (
     
      <div> 
        <div className="container">
          <div className="row">
            <div className="col"></div>
            <div className="col-6">
             
               
                <div className="header-form">
                <h4 className="text-primary text-center">
                  <i className="fa fa-user-circle" style={{fontSize:"110px"}}>            </i></h4>
                </div>

              <div className="mt-4 d-flex justify-content-center">
                <h1 className="text-primary">Project Management</h1> 
              </div>
            </div>
            <div className="col"></div>
          </div>
          <div className="login-form">

            <form onSubmit={loginSubmitHandler}>
              <div className="form-group">
              <input
                  type="email"
                  name="email"
                  className="form-control"
                  placeholder="Email"
                  required
                />
              </div> 
 
              <div className="form-group mt-2">
                <input
                  type="password"
                  name="password"
                  className="form-control"
                  placeholder="Password"
                  required
                />
              </div> 
              <div className="form-group mt-3">
                <div className="row">
                  <div className="col-10">
                    <button
                      type="submit"
                      className="btn btn-primary p-2"
                      disabled={isLoading}
                    >
                      <i className="fa fa-sign-in"></i> Login
                    </button>
                  </div>
                  <div className="col">
                    {isLoading ? (
                      <div
                        className="spinner-border text-primary"
                        role="status"
                      ></div>
                    ) : (
                      ""
                    )}
                  </div>
                </div>
              </div>
              <div className="mt-3" style={{ height: "30px", color: "red" }}>
                {errorMsg === "" ? <div></div> : <div>{errorMsg}</div>}
              </div>
            </form> 
          </div>
        </div> 
      </div>  
       
      
    )}
  </div>
   
);
}

export default App;
