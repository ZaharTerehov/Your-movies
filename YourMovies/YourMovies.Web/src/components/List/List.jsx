import {React, useRef, useState} from 'react';
import "./list.scss";
import { ArrowLeft, ArrowRight} from 'react-bootstrap-icons';
import ListItem from '../ListItem/ListItem';
import "./list.scss";

function List() {
  const [isMoved, setIsMoved] = useState(false)
  const [slideNumber, setslideNumber] = useState(0)
  const listRef = useRef()

  const handleClick = (direction) => {
    setIsMoved(true)
    let distance = listRef.current.getBoundingClientRect().x - 50
    if(direction === "left" && slideNumber > 0) {
        setslideNumber(slideNumber - 1)
        listRef.current.style.transform = `translateX(${230 + distance}px)`
    }
    if(direction === "right" && slideNumber < 5) {
        setslideNumber(slideNumber + 1)
        listRef.current.style.transform = `translateX(${-230 + distance}px)`
    }
  }
  return (
    <div className='list'>
        <span className="listTitle">
            Continue to watch
        </span>
        <div className='wrapper'>
            <ArrowLeft 
            className='sliderArrow left' 
            style={{display: !isMoved && "none"}}
            onClick={() => handleClick("left")}/>
            <div className="container" ref={listRef}>
                <ListItem index={0}/>
                <ListItem index={1}/>
                <ListItem index={2}/>
                <ListItem index={3}/>
                <ListItem index={4}/>
                <ListItem index={5}/>
            </div>
            <ArrowRight className='sliderArrow right' onClick={() => handleClick("right")}/>
        </div>
    </div>
  )
}

export default List
