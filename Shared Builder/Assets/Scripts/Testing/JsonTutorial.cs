using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JsonTutorial : MonoBehaviour
{
    public MyClass myObject = new MyClass();

    public List<MyClass> objects;

    private void Start()
    {
        myObject = new MyClass();
        objects.Add(myObject);
        myObject.level = 1;
        myObject.timeElapsed = 47.5f;
        myObject.playerName = "Dr Charles Francis";
        myObject.numbers = new List<int> { 1, 2, 3 };
        myObject.nestedLists = new List<List<int>> { new List<int>{ 1, 2 }, new List<int> { 1 }, new List<int> { 2 } };
        myObject.array = new int[] { 1, 2, 3 };
        myObject.TwoArray = new int[][] { new int[] { 1, 2 } };
        myObject.cucmber = new Cucumber();

        print(myObject.TwoArray);

        string json = JsonUtility.ToJson(myObject,true);
        print(json);

        MyClass backFromJson = JsonUtility.FromJson<MyClass>(json);

        objects.Add(backFromJson);
        print(backFromJson.TwoArray);
    }


}
