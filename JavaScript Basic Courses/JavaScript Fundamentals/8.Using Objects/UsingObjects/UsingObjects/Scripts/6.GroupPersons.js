/// <reference path="5.FindYoungest.js" />

function group(arrPersons, attr) {
    var groupedArray = {};

    function groupByFName() {
        for (var i in arrPersons) {
            if (groupedArray[arrPersons[i].firstName]) {
                groupedArray[arrPersons[i].firstName].push(arrPersons[i])
            }
            else {
                groupedArray[arrPersons[i].firstName] = [arrPersons[i]];
            }
        }
    }
    
    function groupByLName() {
        for (var i in arrPersons) {
            if (groupedArray[arrPersons[i].lastName]) {
                groupedArray[arrPersons[i].lastName].push(arrPersons[i])
            }
            else {
                groupedArray[arrPersons[i].lastName] = [arrPersons[i]];
            }
        }
    }

    function groupByAge() {
        for (var i in arrPersons) {
            if (groupedArray[arrPersons[i].age]) {
                groupedArray[arrPersons[i].age].push(arrPersons[i])
            }
            else {
                groupedArray[arrPersons[i].age] = [arrPersons[i]];
            }
        }
    }

    switch (attr) {
        case 'firstName': groupByFName(); break;
        case 'lastName': groupByLName(); break;
        case 'age': groupByAge(); break;
    }

    return groupedArray;
}