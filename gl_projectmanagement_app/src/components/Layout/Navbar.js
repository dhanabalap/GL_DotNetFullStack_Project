import React from "react";

const Navbar = () => {
  return (
    <nav class="navbar navbar-light bg-light">
  <div class="container-fluid">
    <a class="navbar-brand">Hello, User</a>
    <form class="d-flex">      
      <button class="btn btn-outline-success" type="submit">Logout</button>
    </form>
  </div>
</nav>
  );
};

export default Navbar;
