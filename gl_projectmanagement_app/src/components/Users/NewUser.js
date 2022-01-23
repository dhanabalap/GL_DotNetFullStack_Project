import React from 'react';


const NewUser=(props) => {
     
    return(

        <div className="container">
            <div className="row">
                <div className="col-sm-8">NewUser</div>
                <div className="col-sm-4">
                    <button type="button" className="btn btn-secondary">Save</button>
                    <button type="button" className="btn btn-secondary">Cancel</button>
                </div>
            </div>
            <div className="row">
                <div classNameName="col-lg-4"> 
                    <label>First Name</label>
                    <input type="text" placeholder="First Name" aria-label="First Name" aria-describedby="basic-addon1" />
                    <label>Last Name</label>
                    <input type="text" placeholder="Last Name" aria-label="Last Name" aria-describedby="basic-addon1" />
                    <label>Email</label>
                    <input type="text" placeholder="Email" aria-label="Email" aria-describedby="basic-addon1" />
                </div>
            </div> 
        </div>
         
    );
}

export default NewUser