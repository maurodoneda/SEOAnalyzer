import React from 'react';  

function SearchForm() {
  return (
     <form>        
         <label>
             Search Term:
             <input type="text"/>        
          </label>
          <label>
             URl to analyze:
             <input type="text"/>        
          </label>
          <input type="submit" value="Submit" />
     </form>
  );
}
    
export default SearchForm