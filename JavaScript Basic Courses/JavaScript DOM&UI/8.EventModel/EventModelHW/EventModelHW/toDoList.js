//Create a TODO list with the following UI controls
//        - Form input for new Item
//        - Button for adding the new Item
//        - Button for deleting some item
//        - Show and Hide Button

var mainList = document.getElementById('toDoList');
var inputTask = document.getElementById('newTask');

var addBtn = document.getElementById('add-button');
var deleteBtn = document.getElementById('delete-button');
var showHideBtn = document.getElementById('show-hide-button');

addBtn.addEventListener('click', function () {
    var newLiItem = document.createElement('li');
    newLiItem.innerText = inputTask.value;
    mainList.appendChild(newLiItem);
})

deleteBtn.addEventListener('click', function () {
    var selectedTasks = mainList.getElementsByClassName('selected');

    for (var i = 0; i < selectedTasks.length; i++) {
        selectedTasks[i].parentNode.removeChild(selectedTasks[i]);
        i--;
    }
})

showHideBtn.addEventListener('click', function () {
    if (mainList.className == 'hidden') {
        mainList.className = '';
    } else {
        mainList.className = 'hidden';
    }
})

mainList.addEventListener('click', function (evt) {
    var target = evt.target;

    if (target.tagName == 'LI') {
        if (target.className == 'selected') {
            target.className = '';
        } else {
            target.className = 'selected';
        }
    }
})