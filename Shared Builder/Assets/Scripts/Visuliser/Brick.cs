using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// The Brick object
[System.Serializable]
public class Brick : MonoBehaviour
{
    public int type; // 2x2, 1x4 
    public int[] position; //{0,4}
    public int colour; // red,green, blue, yellow
    public List<string> users; // List of usernames that have the brick in that position

    [SerializeField]
    private GameObject fallBackModel;

    [SerializeField]
    private Texture fallBackTexture;

    // Reference to scenes brick data
    public BrickData data;

    public GameObject modelHolder;

    public TextMeshProUGUI textLabel;

    public void Initialise(int _type, int[] _position, int _colour, List<string> _users)
    {
        type = _type;
        position = _position;
        colour = _colour;
        users = _users;
        SetText(users);
    }

    private void SetText(List<string> users)
    {
        if (users.Count == 1)
        {
            char c = users[0][0];
            textLabel.text = c.ToString();
        }
        else
        {
            textLabel.text = "";
        }
        
    }

    private void Start()
    {
        //create relevent prefab model in world
        AddModel();

        // Move to correct location (Position is in format rows,cols) In unity rows change in the z axis and cols change in the x axis
        transform.localPosition = new Vector3(position[1]*.008f, 0 , -position[0] * .008f);
    }

    private void AddModel()
    {
        GameObject model;
        BrickType brickType = data.brickTypes.Find(x => (x.brickTypeKey == type));
        if (brickType != null)
        {
            model = GameObject.Instantiate(brickType.brickObject);
        }
        else
        {
            Debug.LogError("Could not find model key matching " + type + " to set for this bricks model, Set to fall back model");
            model = GameObject.Instantiate(fallBackModel);
        }

        // Initialise position
        model.transform.parent = modelHolder.transform;
        model.transform.localScale = Vector3.one;
        model.transform.localPosition = Vector3.zero;

        // Set Texture
        BrickTexture textureObject = data.textureData.Find(x => (x.textureKey == colour));
        if (textureObject != null)
        {
            model.GetComponentInChildren<Renderer>().material.SetTexture("_BaseMap", textureObject.texture);
        }
        else
        {
            Debug.LogError("Could not find texture key matching " + colour + " to apply to this bricks model, Set to fall back texture");
            model.GetComponentInChildren<Renderer>().material.SetTexture("_BaseMap", fallBackTexture);
        }
        
    }

    public void DestroyBrick()
    {
        // Other animation or sound functionality can be executed here
        Destroy(gameObject);
    }
}
