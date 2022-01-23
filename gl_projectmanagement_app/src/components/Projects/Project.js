import React from 'react';

const Project=(props)=>{
    //EC6
    const { ID, Name, Detail, CreatedOn} = props.data;

    return(
    <tr>
        <td>{ID}</td>
        <td>{Name}</td>
        <td>{Detail}</td>
        <td>{CreatedOn}</td>
    </tr>
    );
}

export default Project;