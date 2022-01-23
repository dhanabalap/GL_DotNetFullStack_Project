import React from 'react'; 
import Project from './Project';

const ProjectList = () =>{

    const projects = [
        { ID: 1, Name : "C# Project", Detail : "Detail for project 1", CreatedOn : "2022-01-10" },
        { ID: 2,  Name : "ASP Core Project", Detail : "Detail for project 2", CreatedOn : "2022-01-11" },
        { ID: 3,  Name : "Java Core Project", Detail : "Detail for project 3", CreatedOn : "2022-01-05" },
    ];

    return (
        <div>
            <h1>Project Lists</h1>
        
            <table class="table table-hover table-bordered">
            <thead class="thead-dark">
                <tr>
                <th scope="col">Id</th>
                <th scope="col">ProjectName</th>
                <th scope="col">Details</th>
                <th scope="col">CreatedOn</th>
                </tr>
            </thead>
            <tbody>
                {
                    projects.map( prj => <Project data={prj} />)
                } 
            </tbody>
            </table>
        </div>
    )
}

export default ProjectList