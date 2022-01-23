import React from "react";

const Sidebar = () => {
  return (
    <div className="list-group">
      <a
        href="#"
        className="list-group-item list-group-item-action active"
        aria-current="true"
      >
        Users
      </a>
      <a href="#" className="list-group-item list-group-item-action">
       Projects
      </a>
      <a href="#" className="list-group-item list-group-item-action">
       Tasks
      </a>       
    </div>
  );
};

export default Sidebar;
