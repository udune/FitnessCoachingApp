using System;
using System.Collections.Generic;

// 사용자 타입
[Serializable]
public class User
{
    public int id;
    public string name;
    public string email;
    public int level;
    public string role; // "member" or "trainer"
}

// 인바디 데이터 타입
[Serializable]
public class InBodyData
{
    public int id;
    public int userId;
    public float weight;
    public float bodyFat;
    public float muscleMass;
    public float bmi;
    public string measuredAt;
}

// 운동 루틴 타입
[Serializable]
public class WorkoutRoutine
{
    public int id;
    public string name;
    public int sets;
    public int reps;
    public bool completed;
}

// 운동 기록 타입
[Serializable]
public class WorkoutLog
{
    public int id;
    public int userId;
    public string date;
    public List<WorkoutRoutine> routines;
    public float completionRate;
}

// AI 추천 운동
[Serializable]
public class AIRecommendation
{
    public int id;
    public int userId;
    public string date;
    public List<WorkoutRoutine> routines;
    public string reason;
}

// 3D 능력치
[Serializable]
public class AbilityStats
{
    public int userId;
    public float strength;
    public float metabolism;
    public float balance;
    public float flexibility;
}

// 회원 요약 정보 타입 (트레이너용)
[Serializable]
public class MemberSummary
{
    public int id;
    public string name;
    public string riskLevel; // "low", "medium", "high"
    public string lastWorkoutDate;
    public float weeklyCompletionRate;
}