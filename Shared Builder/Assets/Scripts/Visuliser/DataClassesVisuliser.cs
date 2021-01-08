using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
// Class for storing brick data for the required visuals
public class BrickVisual
{
    public int type; // 2x2, 1x4 
    public int[] position; //{0,4}
    public int colour; // red,green, blue, yellow
    public List<string> users; // List of usernames that have the brick in that position

    // Constructor
    public BrickVisual(int _type, int[] _position, int _colour, List<string> _users)
    {
        type = _type;
        position = _position;
        colour = _colour;
        users = _users;
    }
}

[System.Serializable]
public class BrickTexture 
{
    public int textureKey;
    public Texture2D texture;
}

[System.Serializable]
public class BrickType
{
    public int brickTypeKey;
    public GameObject brickObject;
}

