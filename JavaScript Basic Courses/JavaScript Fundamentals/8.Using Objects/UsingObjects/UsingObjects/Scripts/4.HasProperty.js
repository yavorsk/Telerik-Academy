
function hasProperty(obj, nameOfProperty) {
    var result = false;

    for (var prop in obj) {
        if (prop === nameOfProperty) {
            result = true;
            break;
        }
    }

    return result;
}
