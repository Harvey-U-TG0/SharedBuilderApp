using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Brick object
[System.Serializable]
public class Brick : MonoBehaviour
{
    public string type; // 2x2, 1x4 
    public int[] position; //{0,4}
    public string colour; // red,green, blue, yellow
    public List<string> users; // List of usernames that have the brick in that position

    [SerializeField]
    private GameObject defaultModel;

    private void Start()
    {
        //create relevent prefab model in world
        CreateDefaultModel();

        // Move to correct location
        transform.localPosition = new Vector3(-position[0]*.008f, 0 , -position[1] * .008f);
    }

    private void CreateDefaultModel()
    {
        GameObject model = GameObject.Instantiate(defaultModel);
        model.transform.parent = transform;
        model.transform.localScale = Vector3.one;
        model.transform.localPosition = Vector3.zero;
    }

    public void DestroyBrick()
    {
        // Other animation or sound functionality can be executed here
        Destroy(gameObject);
    }
}
