using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    public API apiController;
    public BuildPlate buildPlate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        apiController.GetModel();
        buildPlate.UpdateBuildPlate();

    }
}
