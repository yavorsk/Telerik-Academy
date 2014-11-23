(function () {
    var Person = (function () {
        function Person(fName, lName) {
            this.fName = fName;
            this.lName = lName;
            this.fullName = fName + ' ' + lName;
        }

        return Person;
    }())

    var people = [
        new Person('Gandalf', 'Grey'),
        new Person('Harry', 'Potter'),
        new Person('Pesho', 'Goshev'),
        new Person('Gosho', 'Potter'),
        new Person('Pesho', 'Greyjoy'),
        new Person('Daenerys', 'Targarien'),
        new Person('Gandalf', 'Potter'),
        new Person('Gandalf', 'Baggins'),
        new Person('Torrin', 'Oakenshield'),
        new Person('Roul', 'Baggins')
    ];

    // 7. By an array of people find the most common first and last name. Use underscore.

    console.log('------- Task 7 ---------');

    function getMostCommonNames(peopleCollection) {
        var mostCommonFirst = _.chain(peopleCollection)
                                .groupBy('fName')
                                .max(function (pers) {
                                    return pers.length;
                                })
                                .value()[0].fName;

        var mostCommonLast = _.chain(peopleCollection)
                                .groupBy('lName')
                                .max(function (pers) {
                                    return pers.length;
                                })
                                .value()[0].lName;

        return {
            mostCommonFirstName: mostCommonFirst,
            mostCommonLastName: mostCommonLast
        }
    }

    console.log(getMostCommonNames(people));
}())