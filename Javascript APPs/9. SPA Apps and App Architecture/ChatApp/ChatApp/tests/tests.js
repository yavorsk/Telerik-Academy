define(['chai', 'ui'], function (chai, ui) {
    var expect = chai.expect;

    describe('uiTests', function () {
        it('should calculate the sum corectly', function () {
            var first = 4;
            var second = 5;
            var expected = first + second;
            var actual = ui.sum(first, second);

            expect(actual).to.equal(expected);
        })
    });
});