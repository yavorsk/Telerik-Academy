
function personBuilder(firstN, lastN, age) {
    return {
        firstName: firstN,
        lastName: lastN,
        age: age,
        toString: function () {
            return 'Name: ' + this.firstName + ' ' + this.lastName + '; ' + 'Age=' + this.age + '.';
        }
    }
}

function findYoungest(arrPesrsons) {
    var youngestPersonPosition = 0;
    var youngestPersonAge = arrPesrsons[youngestPersonPosition].age;

    for (var personPos in arrPesrsons) {
        if (youngestPersonAge > arrPesrsons[personPos].age) {
            youngestPersonAge = arrPesrsons[personPos].age;
            youngestPersonPosition = personPos;
        }
    }

    return arrPesrsons[youngestPersonPosition];
}