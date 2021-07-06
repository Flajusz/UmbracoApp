import'../Styles/ModalWindow.scss'

function GetMedia(name) 
{
  var modal = document.getElementById(name);
  modal.style.display = "block";
  window.onclick = function(event) {
    if (event.target == modal) {
      modal.style.display = "none";
    }
  }
}

function Movie(props)
{

  if(props.media===0 || props.media===1)
  {
    return(
      <div className="Movie">
        <div className="left">                              
        {props.method(props.data)}              
        </div>      
        <div className="right">
          <div className="cat">
            <div className="catFill">{props.data.Category}</div>
            </div>
          <b>{props.data.Title}</b><br/>
          <div className="greyText">
          <p>Published:{" "+props.data.PublishDate.substring(0, 10)}</p> 
          {props.data.MovieTags.map(x=><>{"|#"+x+"|"}</>)}
          </div>
          <p><small>{props.data.Description}</small></p>              
        </div>
      </div>
    )
  }
  else
  {
    return(      
        <div className="Movie">
        <div className="left">
          <button className="modalButton" onClick={() => GetMedia(props.data.Title)} ></button> 
          <div id="myModal" class="modal" id={props.data.Title}>             
              {props.method(props.data)}
          </div> 
        </div>      
        <div className="right">
          <div className="cat">
            <div className="catFill">{props.data.Category}</div>
            </div>
          <b>{props.data.Title}</b><br/>
          <div className="greyText">
          <p>Published:{" "+props.data.PublishDate.substring(0, 10)}</p> 
          {props.data.MovieTags.map(x=><>{"|#"+x+"|"}</>)}
          </div>
          <p><small>{props.data.Description}</small></p>              
        </div>
      </div>      
    )
  }

}
export default Movie