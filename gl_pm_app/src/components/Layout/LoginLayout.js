import React from 'react';
import { useNavigate } from "react-router-dom";
function LoginLayout(props) {
  
  let navigate = useNavigate(); 
  const routeChange = () =>{ 
    let path = `newPath`; 
    navigate(path);
  }
  
  return (
    /*
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
   */
  <div>Login</div>
  );
}

export default LoginLayout;