var Color;
(function (Color) {
    Color[Color["RED"] = 0] = "RED";
    Color[Color["BLUE"] = 1] = "BLUE";
    Color[Color["WHITE"] = 2] = "WHITE";
})(Color || (Color = {}));
;
var Gender;
(function (Gender) {
    Gender[Gender["MALE"] = 0] = "MALE";
    Gender[Gender["FEMALE"] = 1] = "FEMALE";
})(Gender || (Gender = {}));
;
var Month;
(function (Month) {
    Month[Month["JAN"] = 0] = "JAN";
    Month[Month["FEB"] = 4] = "FEB";
    Month[Month["MAR"] = 5] = "MAR";
})(Month || (Month = {}));
;
var Skill;
(function (Skill) {
    Skill[Skill["C"] = 3] = "C";
    Skill[Skill["CPP"] = 5] = "CPP";
    Skill[Skill["JAVA"] = 2] = "JAVA";
})(Skill || (Skill = {}));
;
console.log(Color.BLUE);
console.log(Gender.MALE);
console.log(Month.JAN);
console.log(Month.FEB);
console.log(Month.MAR);
console.log(Skill.C);
console.log(Skill.CPP);
console.log(Skill.JAVA);
