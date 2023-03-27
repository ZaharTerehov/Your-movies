import "./featured.scss"

function Featured({type}) {
  return (
    <div className="featured">
        {type && (
          <div className="category">
            <span>{type === "movie" ? "Moviews" : "Series"}</span>
            <select name="ganre" id="ganre">
              <option>Ganre</option>
            </select>
          </div>
        )}
        <img 
        src="https://assets.nflxext.com/ffe/siteui/vlv3/d049a3bd-40ee-411b-9f16-d1def798d43b/8eb12c59-f444-4eab-8cc0-621c5161bf2f/BY-en-20230313-popsignuptwoweeks-perspective_alpha_website_small.jpg"
        alt=""
        />
        <div className="info">
          <span className="text">
            This site was created so that you can view various new items<br/>
            from the world of movies and TV shows.
          </span>
        </div>
    </div>
  )
}

export default Featured
