define(function () {
    'use strict';
    var Course;
    Course = (function () {
        function Course(courseName, totalScoreFunction) {
            this.name = courseName;
            this.students = [];
            this.totalScoreFunc = totalScoreFunction;
            this.rankingByExam = [];
            this.rankingByTotalScore = [];
        };

        Course.prototype = {
            addStudent : function (student) {
                this.students.push(student);
            },
            calculateResults: function () {
                var self = this;

                for (var i = 0; i < this.students.length; i++) {
                    this.rankingByExam[i] = this.students[i];
                    this.rankingByTotalScore[i] = this.students[i];
                }

                this.rankingByExam.sort(function (stud1, stud2) { return stud2.exam - stud1.exam });
                
                this.rankingByTotalScore.sort(function (stud1, stud2) { return self.totalScoreFunc(stud2) - self.totalScoreFunc(stud1) });
            },
            getTopStudentsByExam: function (countOfStudents) {
                var topStudentsByExamScore = [];

                for (var i = 0; i < countOfStudents; i++) {
                    topStudentsByExamScore.push(this.rankingByExam[i]);
                }

                return topStudentsByExamScore;
            },
            getTopStudentsByTotalScore: function (countOfStudents) {
                var topStudentsByTotalScore = [];

                for (var i = 0; i < countOfStudents; i++) {
                    topStudentsByTotalScore.push(this.rankingByTotalScore[i]);
                }

                return topStudentsByTotalScore;
            }
        }

        return Course;
    }())

    return Course;
});