import React from 'react';


const Users=(props) => {
    //EC6
    const { ID, FirstName, LastName, Email} = props.data;

    return(
    <tr>
        <td>{ID}</td>
        <td>{FirstName}</td>
        <td>{LastName}</td>
        <td>{Email}</td>
    </tr>
    );
}

export default Users