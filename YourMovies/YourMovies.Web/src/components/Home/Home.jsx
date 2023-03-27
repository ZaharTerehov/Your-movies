import React from 'react'
import Featured from '../Featured/Featured'
import List from '../List/List'
import "./home.scss"


function Home() {
  return (
    <div className="home">
      <Featured/>      
      <List/>
      <List/>
      <List/>
      <List/>
      <List/>
      <List/>
    </div>
  )
}

export default Home
