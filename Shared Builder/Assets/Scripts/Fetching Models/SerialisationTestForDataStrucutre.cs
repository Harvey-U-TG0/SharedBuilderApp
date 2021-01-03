using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// If the JSON serialisation is working correctly then the ouput and input model should be the same when program is run
public class SerialisationTestForDataStrucutre : MonoBehaviour
{
    public Model inputModel = new Model();

    public Model outputModel = new Model();

    private void Start()
    {
        string jsonTest = JsonUtility.ToJson(inputModel, true);
        print("The serialised data in JSON Format " + jsonTest);

        outputModel = JsonUtility.FromJson<Model>(jsonTest);

    }
}
