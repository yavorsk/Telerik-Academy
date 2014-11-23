(function () {
    var Student = (function () {
        function Student(fName, lName, age, mark) {
            this.fName = fName;
            this.lName = lName;
            this.age = age;
            this.mark = mark;
            this.fullName = fName + ' ' + lName;
        }

        return Student;
    }())

    var students = [
        new Student('Gandalf', 'Grey', 84, 99),
        new Student('Harry', 'Potter', 16, 80),
        new Student('Pesho', 'Goshev', 20, 66),
        new Student('Gosho', 'Peshev', 13, 25),
        new Student('Teon', 'Greyjoy', 19, 10),
        new Student('Daenerys', 'Targarien', 15, 88),
        new Student('John', 'Snow', 17, 84),
        new Student('Bilbo', 'Baggins', 122, 55),
        new Student('Torrin', 'Oakenshield', 105, 72),
        new Student('Roul', 'Endymion', 23, 76)
    ];

    // 1. Write a method that from a given array of students finds all students 
    // whose first name is before its last name alphabetically. 
    // Print the students in descending order by full name. 

    console.log('------- Task 1 ---------');

    function getStudentsWithFirstBeforeLast(studentsCollection) {
        var resultCollection = _.chain(studentsCollection)
                                .filter(function (student) {
                                    return student.lName > student.fName;
                                })
                                .sortBy('fullName')
                                .value();
        
        _.each(resultCollection, function (stud) {
            console.log(stud.fullName);
        });
    }

    getStudentsWithFirstBeforeLast(students);

    // 2. Write function that finds the first name and last name of all students 
    // with age between 18 and 24. Use Underscore.js

    console.log('------- Task 2 ---------');

    function getStudentsBetweenCertainAges(studentsCollection, minAge, maxAge) {
        var resultCollection = _.filter(studentsCollection, function(student){
            return (minAge <= student.age && student.age <= maxAge);
        })

        _.each(resultCollection, function (stud) {
            console.log(stud.fullName + ', age: ' + stud.age);
        });
    }

    getStudentsBetweenCertainAges(students, 18, 24);

    //3. Write a function that by a given array of students finds the student with highest marks

    console.log('------- Task 3 ---------');

    function getStudentWithHighestMark(studentsCollection) {
        var bestStudent = _.chain(studentsCollection)
                            .sortBy('mark')
                            .last()
                            .value();

        console.log(bestStudent.fullName + ' mark: ' + bestStudent.mark);
    }

    getStudentWithHighestMark(students);
}())