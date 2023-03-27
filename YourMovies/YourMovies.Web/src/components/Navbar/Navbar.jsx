import React, { useState } from 'react';
import { Search, Bell, PersonCircle, CaretDownFill} from 'react-bootstrap-icons';
import "./navbar.scss";
import { Link, Route, useMatch, useResolvedPath } from 'react-router-dom';
import logo from '../../img/Netflix-logo.png';
import Register from '../Register/Register';

const Navbar = () => {
  return (
    <div className="navbar">
        <div className='container'>
            <div className='left'>
                <img src={logo} alt='' />
                <CustomLink to="/homePage"><span>Homepage</span></CustomLink>
                <span>Series</span>
                <span>Movies</span>
                <span>New and Popular</span>
                <span>My List</span>
                <span className='adminPanel'>Admin
                    <div className='options'>
                        <span><CustomLink to="/ganre">Ganre</CustomLink></span>
                        <span><CustomLink to="/typeCinema">TypeCinema</CustomLink></span>
                        <span><CustomLink to="/country">Country</CustomLink></span>
                        <span><CustomLink to="/person">Person</CustomLink></span>
                        <span><CustomLink to="/productionCompany">ProductionCompany</CustomLink></span>
                        <span><CustomLink to="/department">Department</CustomLink></span>
                        <span><CustomLink to="/ageRating">AgeRating</CustomLink></span>
                        <span><CustomLink to="/cinemaCast">CinemaCast</CustomLink></span>
                        <span><CustomLink to="/cinemaCrew">CinemaCrew</CustomLink></span>
                        <span><CustomLink to="/cinema">Cinema</CustomLink></span>
                    </div>
                </span>
            </div>
            <div className='right'>
                <Search className='icon'/>
                <span>KID</span>
                <CustomLink to="/register"><span>Register</span></CustomLink>
                <Bell className='icon'/>
                <img 
                    src='https://lh3.googleusercontent.com/ogw/AAEL6sgHN7K3RnP_cr0hGD2YDrrK72PyCGNKhSmSo8i8QQ=s32-c-mo'
                    alt=''/>
                <div className='profile'>
                    <CaretDownFill className="icon" />
                    <div className='options'>
                        <span>Logout</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
  )
}

function CustomLink({to, children, ...props}) {
    return (
        <Link to={to} {...props}>{children}</Link>
    )
}

export default Navbar
