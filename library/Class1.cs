namespace library;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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