import {React, useState, useRef} from 'react'
import { createApiEndpoint, EndPointsUser } from "../../api";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import "./register.scss"

function Register() {
  const [email, setEmail] = useState('')
  const [emailValue, setEmailValue] = useState('')
  const [password, setPassword] = useState('')
  const emailRef = useRef('')

  const successfulRegistration = () => toast.success("You have successfully registered. Now verify your email", {className: "toast-message"});

  const handleStart = () => {
    setEmail(emailRef.current.value)
  }

  const handleRegisterUser = () => {
    const data = {
      "email": email,
      "password": password
    }
    
    createApiEndpoint(EndPointsUser.create).create(data)
    .then((result) => {
      successfulRegistration()
      console.log(result)
    }).catch((error) => {
      toast.error(error.response.data, {className: "toast-message"});
      console.log(error)
    })

    setEmailValue("")
    setEmail("")
    setPassword("")  
  };

  return (
    <div className='register'>
      <ToastContainer position="top-center"/>
      <div className='top'>
        <div className='wrapper'>
          <img className='logo'
          src='/static/media/Netflix-logo.f1764271fb8dcb0c3186.png'
          alt=''/>
          <button className="loginButton">Sign In</button>
        </div>
      </div>
      <div className='container'>
        <h1 h1>Unlimited movies, TV shows, and more.</h1>
        <h2>Watch anywhere. Cancel anytime.</h2>
        <p>
          Ready to watch? Enter your email to create or restart your membership.
        </p>
        {!email ?(
          <div className="input">
            <input type="email" placeholder='email address' value={emailValue} 
            onChange={(emailValue) => setEmailValue(emailValue.target.value)} ref={emailRef}/>
            <button className='registerButton' onClick={handleStart}>Register</button>
          </div>
        ) : (
          <div className="input">
            <input type="password" placeholder='password' value={password} 
            onChange={(password) => setPassword(password.target.value)}/>
            <button className='registerButton' onClick={() => handleRegisterUser()}>Start</button>
          </div>
        )}

      </div>
    </div>
  )
}

export default Register
