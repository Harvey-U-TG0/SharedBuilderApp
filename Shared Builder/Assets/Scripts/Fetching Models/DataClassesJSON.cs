using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// The data strucutre for model information from server
[System.Serializable]
public class Model
{
    public List<UserContrib> userContributions;
    public string _id; //The id of the model
    public float cost; // The cost of the model
}

[System.Serializable]
public class UserContrib
{
    public List<BrickInfo> brickConfig;
    public string _id; // The users personal id
}

[System.Serializable]
public class BrickInfo
{
    public int shapeID;
    public int[] position;
    public int colourID;
}
