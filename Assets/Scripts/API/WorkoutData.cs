using System;
using System.Collections.Generic;

[Serializable]
public class Workout
{
    public string name;
    public int sets;
    public int reps;
    // API 응답에 다른 필드가 있다면 여기에 추가할 수 있습니다.
    // public string type; 
    // public int weight;
}

[Serializable]
public class ApiRoutinesResponse
{
    public List<Workout> routines;
}
