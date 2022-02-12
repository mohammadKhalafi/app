using library;

var studentsFileReader = new FileReader() {path = @"../files/students.txt"};
var scoresFileReader = new FileReader() {path = @"../files/scores.txt"};

string students = studentsFileReader.ReadFile();
string scores = scoresFileReader.ReadFile();

var studentsArr = Deserializer<Student>.DeserializeArrayOfJsonObjects(students);
var scoresArr = Deserializer<Score>.DeserializeArrayOfJsonObjects(scores);

var dataOfFirstThreeStudents = new Data[3];

for (int i = 0; i < 3; i++){
    var data = new Data(){
    firstName = studentsArr[i].firstName,
    lastName = studentsArr[i].lastName,
    studentNumber = studentsArr[i].studentNumber
    };
    dataOfFirstThreeStudents[i] = data;
}

foreach (var score in scoresArr){
    foreach(var data in dataOfFirstThreeStudents){
        if (score.studentNumber == data.studentNumber){
            data.AddScore(score.score);
        }
    }
}

foreach (var data in dataOfFirstThreeStudents){
    Console.WriteLine(data.average);
}

Console.WriteLine("hoho");
