import React from 'react'; 
import Users from './User';
 

const UserList = () =>{

    const users = [
        { ID : 101, FirstName : "Sathis", LastName : "T", Email : "sathis@gmail.com", Password : "T123" },
        { ID : 102, FirstName : "Sangee", LastName : "KV", Email : "sangee@gmail.com", Password : "T123" },
        { ID : 103, FirstName : "Ravi", LastName : "V", Email : "Ravi@gmail.com", Password : "T123" }        
    ];

    return (
        <div>
            <button type="button" class="btn btn-secondary">+New User</button>
        
            <table class="table table-hover table-bordered">
            <thead class="thead-dark">
                <tr>
                <th scope="col">Id</th>
                <th scope="col">FirstName</th>
                <th scope="col">LastName</th>
                <th scope="col">Email</th>
                </tr>
            </thead>
            <tbody>
                {
                    users.map( usr => <Users data={usr} />) 
                } 
            </tbody>
            </table>
        </div>
    )
}

export default UserList