namespace library;
using Newtonsoft.Json;
public class FileReader
{
    public string path {set; get;}
    public string ReadFile() => System.IO.File.ReadAllText(path);
}

public class Student
{
    public string firstName{set; get;}
    public string lastName{set; get;}
    public int studentNumber{set; get;}
}

public class Score
{
    public float score {set; get;}
    public int studentNumber {set; get;}
    public string lesson{set; get;}
}

public static class Deserializer<T>
{
    public static List<T> DeserializeArrayOfJsonObjects(string jsonString) => 
        JsonConvert.DeserializeObject<List<T>>(jsonString);
}

public class Data{
    public int studentNumber{set; get;}
    public int count{set; get;} = 0;
    public string firstName{set; get;}
    public string lastName{set; get;}
    public float average{set; get;}
    public void AddScore(float newScore){
        average = ((average * count) + newScore) / ++count;
    }
}

public class controller{

    private List<Student> students;
    private List<Score> scores;
    private Data[] dataOfFirstThreeStudents;

    public void Run(){
        InitializeScores();
        InitializeStudendts();
        InitializeData();
        CalcuolateAverage();
        PrintAnswer();
    }
    private void InitializeStudendts(){
        var studentsFileReader = new FileReader() {path = @"../files/students.txt"};
        var studentsJsonData = studentsFileReader.ReadFile();
        students = Deserializer<Student>.DeserializeArrayOfJsonObjects
            (studentsJsonData);
    }

    private void InitializeScores(){
        var scoresFileReader = new FileReader() {path = @"../files/scores.txt"};
        var scoresJsonData = scoresFileReader.ReadFile();
        scores = Deserializer<Score>.DeserializeArrayOfJsonObjects(scoresJsonData);
    }

    private void InitializeData(){
        var data = new Data[3];
        for (int i = 0; i < 3; i++){
            var eachData = new Data(){
                firstName = students[i].firstName,
                lastName = students[i].lastName,
                studentNumber = students[i].studentNumber
            };
            data[i] = eachData;
        }
        dataOfFirstThreeStudents = data;
    }

    private void CalcuolateAverage(){
        foreach (var score in scores){
            foreach(var eachData in dataOfFirstThreeStudents){
                if (score.studentNumber == eachData.studentNumber){
                    eachData.AddScore(score.score);
                    break;
                }
            }
        }
    }

    private void PrintAnswer(){
        foreach (var eachData in dataOfFirstThreeStudents){
            Console.WriteLine(eachData.firstName + " " +
                eachData.lastName + " : " + eachData.average);
        }
    }
}

