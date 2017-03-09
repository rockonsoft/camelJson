
function testJson(fileName){
    var fs = require('fs');
    var obj;
    fs.readFile(fileName, 'utf8', function (err, data) {
        if (err) throw err;
        list = JSON.parse(data);
        list.forEach(function(person) {
            console.log('Title: ' + person.title);
            console.log('FirstName: ' + person.firstName);
            console.log('Last Name: ' + person.lastName);
        }, this);
    });
};

if (require.main === module) {
    console.log(process.argv[2]);
    testJson(process.argv[2]);
}