import React from 'react'; 
import Tasks from './Tasks';
import Users from './User';
 

const TaskList = () =>{

    const tasks = [
        { ID :1001 , ProjectID = 1, Status = 2, AssignedToUserID = 102, Detail = "PTest Task 1", CreatedOn = "2022-01-10" },
        { ID = 1002, ProjectID = 2, Status = 4, AssignedToUserID = 101, Detail = "PTest Task 2", CreatedOn = "2022-01-11" } 
    ];

    return (
        <div>
            <button type="button" class="btn btn-secondary">+New User</button>
        
            <table class="table table-hover table-bordered">
            <thead class="thead-dark">
                <tr>
                <th scope="col">Id</th>
                <th scope="col">ProjectID</th>
                <th scope="col">Status</th>
                <th scope="col">AssignedToUserID</th>
                <th scope="col">Detail</th>
                <th scope="col">CreatedOn</th>
                </tr>
            </thead>
            <tbody>
                {
                    tasks.map( tsk => <Tasks data={tsk} />) 
                } 
            </tbody>
            </table>
        </div>
    )
}

export default TaskList