(function () {
    var Animal = (function () {
        function Animal(name, species, numberOfLegs) {
            this.name = name;
            this.species = species;
            this.numberOfLegs = numberOfLegs;
        }

        return Animal;
    }())

    var animals = [
        new Animal('Donald', 'duck', 2),
        new Animal('Pesho', 'centipede', 100),
        new Animal('Scrudge', 'duck', 2),
        new Animal('Tarantosho', 'spider', 8),
        new Animal('Vihar', 'dog', 4),
        new Animal('Pepi', 'crab', 6),
        new Animal('Evstati', 'dog', 4),
        new Animal('Pennywise', 'spider', 8),
        new Animal('Krezo', 'dog', 4),
        new Animal('Jojo', 'dog', 4)
    ];

    // 4. Write a function that by a given array of animals, 
    // groups them by species and sorts them by number of legs

    console.log('------- Task 4 ---------');

    function groupAnimalsBySpecies(animalsCollection) {
        var groupedAnimals = _.chain(animalsCollection)
                            .groupBy('species')
                            .sortBy(function (arr) {
                                return arr[0].numberOfLegs;
                            })
                            .value();

        return groupedAnimals;
    }

    function printGroupedAnimals(groupedAnimals) {
        _.each(groupedAnimals, function (group) {
            var species = group[0].species;
            var numOfLegs = group[0].numberOfLegs;

            var membersNames = _.pluck(group, 'name');

            console.log(species + ', ' + numOfLegs + ', members: ' + membersNames.join(', '));
        })
    }

    printGroupedAnimals(groupAnimalsBySpecies(animals));

    // 5. By a given array of animals, find the total number of legs
    // Each animal can have 2, 4, 6, 8 or 100 legs

    console.log('------- Task 5 ---------');

    function findTotalNumberOfLegs(animalsCollection) {
        var totalNumberOfLegs = 0;

        _.chain(animalsCollection)
            .groupBy('numberOfLegs')
            .each(function (value, key) {
                totalNumberOfLegs += key * value.length;
            });

        return totalNumberOfLegs;
    }

    console.log(findTotalNumberOfLegs(animals));
}())