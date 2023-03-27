import {React, useState} from 'react'
import "./listItem.scss";
import { Star, StarFill, PlusLg } from 'react-bootstrap-icons';

function ListItem({index}) {
  const [isHovered, setIsHovered] = useState(false);

  return (
    <div 
      className='listItem' 
      style={{left: isHovered && index * 225}}
      onMouseEnter={() => setIsHovered(true)}
      onMouseLeave={() => setIsHovered(false)}>
        <img src='https://occ-0-1723-92.1.nflxso.net/dnm/api/v6/X194eJsgWBDE2aQbaNdmCXGUP-Y/AAAABU7D36jL6KiLG1xI8Xg_cZK-hYQj1L8yRxbQuB0rcLCnAk8AhEK5EM83QI71bRHUm0qOYxonD88gaThgDaPu7NuUfRg.jpg?r=4ee' alt='' />
        <div className='itemInfo'>
            <div className='icons'>
                <Star/>
                <StarFill/>
                <PlusLg/>
            </div>
            <div className='itemInfoTop'>
              <span>1 hours 14 mins</span>
              <span className='limit'>16+</span>
              <span>2003</span>
            </div>
            <div className="desc">
              Lorem ipsum dolor sit amet, consectetur adipisicing elit. Nostrum qui natus sapiente iusto.
            </div>
            <div className="ganre">
              Action
            </div>
        </div>
    </div>
  )
}

export default ListItem
