using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Brick object
[System.Serializable]
public class Brick : MonoBehaviour
{
    public string type;
    public int[] position;
    public string colour;

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
}
