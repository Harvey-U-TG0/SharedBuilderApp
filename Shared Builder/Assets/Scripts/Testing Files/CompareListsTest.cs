using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareListsTest : MonoBehaviour
{
    public List<string> usersA;
    public List<string> usersB;

    private void Start()
    {
        bool result = VisuliserCalculations.CompareStringLists(usersA, usersB);
        Debug.Log(result);
    }
    
}
