import React from 'react';


const Tasks=(props) => {
    //EC6
    const { ID, ProjectID, Status, AssignedToUserID,Detail,CreatedOn} = props.data;

    return(
    <tr>
        <td>{ID}</td>
        <td>{ProjectID}</td>
        <td>{Status}</td>
        <td>{AssignedToUserID}</td>
        <td>{Detail}</td>
        <td>{CreatedOn}</td> 
    </tr>
    );
}

export default Tasks