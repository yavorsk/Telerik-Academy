// source: http://stackoverflow.com/questions/122102/what-is-the-most-efficient-way-to-clone-an-object
function deepCopy(obj) {
    if ((obj == null) || (typeof (obj) != 'object')) {
        return obj;
    }

    var copiedObj = {};

    for (var attr in obj) {
        copiedObj[attr] = deepCopy(obj[attr]);
    }

    return copiedObj;
}

