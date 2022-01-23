import React from 'react';
import Footer from './Footer';
import Header from './Header';
import MainContent from './MainContent';
import Navbar from './Navbar';
import Sidebar from './Sidebar';


function Layout() {
  return ( 
   <div className='container'> 
     
        <div>
        <Navbar /> 
        <div className="row">
            
            <div classname="col-lg-3">
                <Sidebar />
            </div>
            <div className="col-lg-9">
                <MainContent />
            </div>
        </div>     
        </div> 
    </div>
        );
}

export default Layout;
