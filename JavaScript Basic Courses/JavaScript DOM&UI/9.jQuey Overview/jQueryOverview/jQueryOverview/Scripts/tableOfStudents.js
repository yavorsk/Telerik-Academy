//By given an array of students, generate a table that represents these students
//Each student has first name,last name and grade
//Use jQuery

var students = [{ firstname: "Petar", lastname: "Ivanov", grade: "3" },
    { firstname: "Milena", lastname: "Grigorova", grade: "6" },
    { firstname: "Gogic", lastname: "Yordanov", grade: "5"},
    { firstname: "Gergana", lastname: "Borisova", grade: "12" },
    { firstname: "Boyko", lastname: "Petrov", grade: "7" }];

var tableData = '';

for (var i = 0; i < students.length; i++) {
    tableData += '<tr><td>' + students[i].firstname + '</td>' + '<td>' + students[i].lastname + '</td>' +
        '<td>' + students[i].grade +'</td>' + '</tr>';
}

var table = $('<table>' + '<tr>' +
    '<th>First Name</th>' +
    '<th>Last Name</th>' +
    '<th>Grade</th>' +
    '</tr>' + tableData + '</table>')

$('body').append(table);
