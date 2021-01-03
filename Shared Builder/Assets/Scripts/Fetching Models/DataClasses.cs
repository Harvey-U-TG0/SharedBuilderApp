using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// The data strucutre for model information
[System.Serializable]
public class Model
{
    public List<UserContrib> userContributions;
    public string name;
    public float cost;
}

[System.Serializable]
public class UserContrib
{
    public List<BrickInfo> bricks;
    public string username;
}

[System.Serializable]
public class BrickInfo
{
    public string type;
    public int[] position;
    public string colour;
}
