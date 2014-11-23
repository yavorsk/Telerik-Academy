//Create a TreeView component
//Initially only the top items must be visible
//On item click
//If its children are hidden (collapsed), they must be made visible (expanded)
//If its children are visible (expanded), they must be made hidden (collapsed)
//Research about events

var mainList = document.getElementById('mainUL');
mainList.addEventListener('click', function (evt) {
    var target = evt.target;

    var innerUl = target.getElementsByTagName('ul')[0];

    if (innerUl) {
        if (innerUl.className == 'hidden') {
            innerUl.className = 'visible';
        } else {
            innerUl.className = 'hidden';
        }
    }
})