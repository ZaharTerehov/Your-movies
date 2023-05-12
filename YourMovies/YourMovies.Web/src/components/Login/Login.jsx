import {React, useState, useRef} from 'react'
import { createApiEndpoint, EndPointsUser } from "../../api"
import { ToastContainer, toast } from 'react-toastify'

import "./login.scss"

function Login() {

  const [password, setPassword] = useState('')
  const [email, setEmail] = useState('')

  const handleLoginUser = () => {
    const data = {
      "email": email,
      "password": password
    }
    
    createApiEndpoint(EndPointsUser.update).create(data)
    .then((result) => {
      toast.success("You have successfully logged in", {className: "toast-message"});
      console.log(result)
    }).catch((error) => {
      toast.error(error.response.data, {className: "toast-message"});
      console.log(error)
    })

    setEmail("")
    setPassword("")  
  };

  return (
    <div className='login'>
        <ToastContainer position="top-center"/>
      <div className='top'>
        <div className='wrapper'>
          <img className='logo'
          src='/static/media/Netflix-logo.f1764271fb8dcb0c3186.png'
          alt=''/>
        </div>
      </div>
      <div className='container'>
        <div className='form'>
          <h1>Sign In</h1>
          <input type="email" placeholder='Email' value={email}
            onChange={(email) => setEmail(email.target.value)} />
          <input type="password" placeholder='Password' value={password}
            onChange={(password) => setPassword(password.target.value)}/>
          <button className="loginButton" onClick={() => handleLoginUser()}>Sign In</button>
          <span>Are you new?<b>Sign up now</b></span>
          <small>
            asdas das das d asd  dsadasdsa d sad
          </small>
        </div>
      </div>
    </div>
  )
}

export default Login
