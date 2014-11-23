Array.prototype.remove = function (value) {
    for (i = 0; i < this.length; i++) {
        if (this[i] === value) {
            this.splice(i, 1);
            i--;
        }
    }
}
