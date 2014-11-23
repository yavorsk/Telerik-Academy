(function () {
    var Book = (function () {
        function Book(name, author) {
            this.name = name;
            this.author = author;
        }

        return Book;
    }())

    var books = [
        new Book('The long walk', 'Stephen King'),
        new Book('Hyperion', 'Dan Simmons'),
        new Book('The dark half', 'Stephen King'),
        new Book('The enemy', 'Lee Child'),
        new Book('It', 'Stephen King'),
        new Book('Song of Kali', 'Dan Simmons'),
        new Book('Ilion', 'Dan Simmons'),
        new Book('Terror', 'Dan Simmons')

    ];

    // 6. By a given collection of books, find the most popular author 
    // (the author with the highest number of books)

    console.log('------- Task 6 ---------');

    function getMostPopularAuthor(booksCollection) {
        var mostPopularAuthor;

        var booksByAuthor = _.chain(booksCollection).countBy('author').invert().value();

        var maxBooks = 0;
        for (var prop in booksByAuthor) {
            if (prop > maxBooks) {
                maxBooks = prop;
            }
        }

        mostPopularAuthor = booksByAuthor[maxBooks];

        return mostPopularAuthor;
    }

    console.log(getMostPopularAuthor(books));
}())