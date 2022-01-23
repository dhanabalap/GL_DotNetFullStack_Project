import React from 'react';


const Login=(props) => {
    console.log(props); 
    return  (
    <div>
       <div class="input-group flex-nowrap">
        <span class="input-group-text" id="addon-wrapping">User Name</span>
        <input type="text" class="form-control" placeholder="Username" aria-label="Username" aria-describedby="addon-wrapping" />
        <span class="input-group-text" id="addon-wrapping">Password</span>
        <input type="password" name="password" />
        </div>
    </div>
    )
}

export default Login