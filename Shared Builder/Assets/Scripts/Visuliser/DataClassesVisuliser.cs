using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
// Class for storing brick data for the required visuals
public class BrickVisual
{
    public string type; // 2x2, 1x4 
    public int[] position; //{0,4}
    public string colour; // red,green, blue, yellow
    public List<string> users; // List of usernames that have the brick in that position

    // Constructor
    public BrickVisual(string _type, int[] _position, string _colour, List<string> _users)
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
    public string textureKey;
    public Texture2D texture;
}

