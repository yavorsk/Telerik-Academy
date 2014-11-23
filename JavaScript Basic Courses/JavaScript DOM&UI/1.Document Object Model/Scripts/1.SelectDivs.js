 // 1. Write a script that selects all the div nodes that are directly inside other div elements
 // Create a function using querySelectorAll()
 // Create a function using getElementsByTagName()

 console.log('Static node list, using querySelector:');
 queryNestedDivs();
 console.log('Live node list, using getElementsByTagName:');
 getNestedDivs();

 function queryNestedDivs() {
     var nestedDivs = document.querySelectorAll('div > div');
     for (var i = 0; i < nestedDivs.length; i++) {
         console.log(nestedDivs[i].id);
     }
 }

 function getNestedDivs() {
     var divs = document.getElementsByTagName('div');

     for (var i = 0; len = divs.length, i < len; i++) {
         var nestedChildren = divs[i].childNodes;

         for (var j = 0; length = nestedChildren.length, j < length; j++) {
             if (nestedChildren[j].tagName == 'DIV') {
                 console.log(nestedChildren[j].id);
             };
         }
     }
 }