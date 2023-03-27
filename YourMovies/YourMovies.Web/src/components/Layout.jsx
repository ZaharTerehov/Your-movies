import React from 'react';
import "./layout.scss";
import Navbar from './Navbar/Navbar';
import {Route, Routes} from "react-router-dom";
import Ganre from './Ganre/Ganre';
import Country from './Country/Country';
import TypeCinema from './TypeCinema/TypeCinema';
import Person from './Person/Person';
import ProductionCompany from './ProductionCompany/ProductionCompany';
import Department from './Department/Department';
import AgeRating from './AgeRating/AgeRating';
import CinemaCast from './CinemaCast/CinemaCast';
import CinemaCrew from './CinemaCrew/CinemaCrew';
import Cinema from './Cinema/Cinema';
import Home from './Home/Home';
import Register from './Register/Register';

const Layout = () => {
    return(
        <div className='layout'>
            <Navbar/>
            <Routes>
            <Route path="/homePage" element={<Home/>}/>
            <Route path="/register" element={<Register/>}/>
            </Routes>
            <div className='container'> 
                <Routes>                    
                    <Route path="/ganre" element={<Ganre/>}/>
                    <Route path="/country" element={<Country/>}/>
                    <Route path="/typeCinema" element={<TypeCinema/>}/>
                    <Route path="/person" element={<Person/>}/>
                    <Route path="/productionCompany" element={<ProductionCompany/>}/>
                    <Route path="/department" element={<Department/>}/>
                    <Route path="/ageRating" element={<AgeRating/>}/>
                    <Route path="/cinemaCast" element={<CinemaCast/>}/>
                    <Route path="/cinemaCrew" element={<CinemaCrew/>}/>
                    <Route path="/cinema" element={<Cinema/>}/>
                </Routes>
            </div>
        </div>
    )
}

export default Layout;
