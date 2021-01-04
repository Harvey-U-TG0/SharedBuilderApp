using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlate : MonoBehaviour
{
    public List<Brick> bricks;

    public GameObject brickPrefab;

    public void AddBrick()
    {
        Brick newBrick = GameObject.Instantiate(brickPrefab).GetComponent<Brick>();
        newBrick.transform.parent = transform;
        newBrick.transform.localScale = Vector3.one;
        newBrick.transform.localPosition = Vector3.zero;
      
        newBrick.type = "2x2";
        newBrick.position = new int[2] { (int) Random.Range(0, 12), (int)Random.Range(0, 12) };
        newBrick.colour = "Red";

        bricks.Add(newBrick);
    }

    public void RemoveBrick()
    {
        Brick remove = bricks.Find(x => (x.type == "2x2") && (x.type == "2x2"));
        bricks.Remove(remove);
        Destroy(remove.gameObject);
    }
}
