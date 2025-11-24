using System;
using System.Collections.Generic;

[Serializable]
public class Workout
{
    public string name;
    public int sets;
    public int reps;
}

[Serializable]
public class ApiRoutinesResponse
{
    public List<Workout> routines;
}
