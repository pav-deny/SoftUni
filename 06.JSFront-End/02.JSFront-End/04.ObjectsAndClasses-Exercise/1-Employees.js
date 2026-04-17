function solve(input = []) {
    let employees = input.map(createEmployees);

    employees.forEach(printEmployee);
    
    function createEmployees(name = "") {
        let employee = {
            name: name,
            personalNumber: name.length
        }

        return employee;
    }

    function printEmployee(employee) {
        console.log(`Name: ${employee.name} -- Personal Number: ${employee.personalNumber}`);
    }
}

solve([
'Silas Butler',
'Adnaan Buckley',
'Juan Peterson',
'Brendan Villarreal'
]);

solve([
'Samuel Jackson',
'Will Smith',
'Bruce Willis',
'Tom Holland'
]);