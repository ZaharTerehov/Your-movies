import {React, useState, useRef} from 'react'
import "./login.scss"

function Login() {
  return (
    <div className='login'>
      <div className='top'>
        <div className='wrapper'>
          <img className='logo'
          src='/static/media/Netflix-logo.f1764271fb8dcb0c3186.png'
          alt=''/>
        </div>
      </div>
      <div className='container'>
        <form>
          <h1>Sign In</h1>
          <input type="email" placeholder='Email or phone number'/>
          <input type="password" placeholder='Password'/>
          <button className="loginButton">Sign In</button>
          <span>Are you new?<b>Sign up now</b></span>
          <small>
            asdas das das d asd  dsadasdsa d sad
          </small>
        </form>
      </div>
    </div>
  )
}

export default Login
