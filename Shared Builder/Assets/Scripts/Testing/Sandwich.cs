using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class MyClass
{
    public int level;
    public float timeElapsed;
    public string playerName;
    public List<int> numbers;
    public List<List<int>> nestedLists;
    public int[] array;
    public int[][] TwoArray;
    public Cucumber cucmber;
}

[System.Serializable]
public class TestDataClass
{
    public int level;
    public float timeElapsed;
    public string playerName;
}
