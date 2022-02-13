using library;

List<Student> GetStudents(){
    var studentsFileReader = new FileReader() {path = @"../files/students.txt"};
    var students = studentsFileReader.ReadFile();
    return Deserializer<Student>.DeserializeArrayOfJsonObjects(students);
}

List<Score> GetScores(){
    var scoresFileReader = new FileReader() {path = @"../files/scores.txt"};
    var scores = scoresFileReader.ReadFile();
    return Deserializer<Score>.DeserializeArrayOfJsonObjects(scores);
}

Data[] GetInitializedData(List<Student> students){
    var data = new Data[3];
    for (int i = 0; i < 3; i++){
        var eachData = new Data(){
            firstName = students[i].firstName,
            lastName = students[i].lastName,
            studentNumber = students[i].studentNumber
        };
        data[i] = eachData;
    }
    return data;
}

void CalcuolateAverage(Data[]data, List<Score>scores){
    foreach (var score in scores){
        foreach(var eachData in data){
            if (score.studentNumber == eachData.studentNumber){
                eachData.AddScore(score.score);
                break;
            }
        }
    }
}

void PrintAnswer(Data[] data){
    foreach (var eachData in data){
        Console.WriteLine(eachData.firstName + " " +
            eachData.lastName + " : " + eachData.average);
    }
}

var students = GetStudents(); 
var scores = GetScores(); 
var dataOfFirstThreeStudents = GetInitializedData(students : students);
CalcuolateAverage(data : dataOfFirstThreeStudents, scores : scores);
PrintAnswer(data : dataOfFirstThreeStudents);




