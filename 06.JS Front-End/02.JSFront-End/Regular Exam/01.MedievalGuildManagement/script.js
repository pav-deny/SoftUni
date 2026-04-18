function solve(inputArr = []) {
    class Member {
        constructor(name, role, skills = []) {
            this.name = name;
            this.role = role;
            this.skills = skills;
        }
    }

    let n = Number(inputArr[0]);
    let members = {};

    for (let i = 1; i <= n; i++) {
        let [name, role, skillsStr] = inputArr[i].split(" ");
        let skillsArr = skillsStr.split(",");

        let member = new Member(name, role, skillsArr);
        members[member.name] = member;
    }

    for (let i = n; i < inputArr.length; i++) {
        let commandArgs = inputArr[i].split(" / ");
        
        let name = commandArgs[1];
        let member = members[name];
        
        let command = commandArgs[0];
        switch (command) {
            case "Perform":
                let role = commandArgs[2];
                let skill = commandArgs[3];

                performSkill(member, role, skill);
                break;

            case "Reassign":
                let newRole = commandArgs[2];
                reassignRole(member, newRole);
                break;

            case "Learn Skill":
                let newSkill = commandArgs[2];
                learnSkill(member, newSkill);
                break;
        }
    }
    let membersEntries = Object.entries(members);

    for (let [name, member] of membersEntries) {
        printMember(member);
    }

    function performSkill(member, role, skill) {
        if (member.role == role && member.skills.includes(skill)) {
            console.log(`${member.name} has successfully performed the skill: ${skill}!`)
        } else {
            console.log(`${member.name} cannot perform the skill: ${skill}.`)
        }
    }

    function reassignRole(member, newRole) {
        member.role = newRole;
        console.log(`${member.name} has been reassigned to: ${newRole}`);
    }

    function learnSkill(member, newSkill) {
        if (member.skills.includes(newSkill)) {
            console.log(`${member.name} already knows the skill: ${newSkill}.`);
        }  else {
            member.skills.push(newSkill);
            console.log(`${member.name} has learned a new skill: ${newSkill}.`);
        }
    }

    function printMember(member) {
        member.skills.sort();
        console.log(`Guild Member: ${member.name}, Role: ${member.role}, Skills: ${member.skills.join(", ")}`);
    }
}

solve([
    "3",
    "Arthur warrior swordsmanship,shield",
    "Merlin mage fireball,teleport",
    "Gwen healer healing,alchemy",
    "Perform / Arthur / warrior / swordsmanship",
    "Perform / Merlin / warrior / fireball",
    "Learn Skill / Gwen / purification",
    "Perform / Gwen / healer / purification",
    "Reassign / Merlin / healer",
    "Perform / Merlin / healer / teleport",
    "End"
]);