class Student {
    constructor(firstName, lastName, gpa) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.gpa = gpa;
    }

    printInfo() {
        console.log(`${this.firstName} ${this.lastName} has a ${this.gpa.toFixed(2)} GPA`);
    }
}

let student1 = new Student("Pencho", "Minchov", 6.00);
let student2 = new Student("Ginka", "Ivanova", 4.50);

student1.printInfo();
student2.printInfo();