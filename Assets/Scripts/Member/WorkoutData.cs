using System;

[Serializable]
public class WorkoutData
{
    public string name;
    public int sets;
    public int reps;
    public string exerciseType;
    public bool completed;

    public WorkoutData(string name, int sets, int reps, string exerciseType)
    {
        this.name = name;
        this.sets = sets;
        this.reps = reps;
        this.exerciseType = exerciseType;
        this.completed = false;
    }
}