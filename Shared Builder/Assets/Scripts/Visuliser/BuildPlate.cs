using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlate : MonoBehaviour
{
    public List<BrickVisual> latestBrickVisuals;

    public List<Brick> bricksOnPlate;

    public GameObject brickPrefab;

    public API api;

    public BrickData brickData;

    public void UpdateBuildPlate()
    {
        // Get latest model from API
        Model latestModel = api.latestModel;

        // Convert model to list of latest brick visuals
        latestBrickVisuals = VisuliserCalculations.ExtractBricksFromModel(latestModel);
        Debug.Log("Updated Build Plate");

        CompareLists();
    }

    /// <summary>
    /// Compares the plate bricks and visual bricks and updates the plate accordingly
    /// </summary>
    private void CompareLists()
    {
        List<Brick> bricksToRemove = new List<Brick>();

        foreach (Brick plateBrick in bricksOnPlate)
        {
            // Try and find it in the latest bricks on plate
            BrickVisual brickInLatestVisuals = latestBrickVisuals.Find(x => (x.type == plateBrick.type) && (x.position[0] == plateBrick.position[0]) && (x.position[1] == plateBrick.position[1]) && (x.colour == plateBrick.colour));

            // If brick found on plate in visual bricks
            if (brickInLatestVisuals != null)
            {
                // Check if the usernames lists are the same
                bool listEqual = VisuliserCalculations.CompareStringLists(brickInLatestVisuals.users, plateBrick.users);
                if (listEqual == false) brickInLatestVisuals = null;
            }

            // If its not there then remove the plate brick
            if (brickInLatestVisuals == null)
            {
                bricksToRemove.Add(plateBrick);
            }
        }

        foreach (Brick brick in bricksToRemove)
        {
            RemoveBrick(brick);
        }

        
        foreach (BrickVisual visualBrick in latestBrickVisuals)
        {
            // Try and find it in the latest bricks on plate
            Brick brickOnPlate = bricksOnPlate.Find(x => (x.type == visualBrick.type) && (x.position[0] == visualBrick.position[0]) && (x.position[1] == visualBrick.position[1]) && (x.colour == visualBrick.colour));
            
            // If brick found on plate in visual bricks
            if (brickOnPlate != null)
            {
                // Check if the usernames lists are the same
                bool listEqual = VisuliserCalculations.CompareStringLists(brickOnPlate.users, visualBrick.users);             
                if (listEqual == false) brickOnPlate = null;      
            }

            // If its not there then add the brick to the plate
            if (brickOnPlate == null)
            {
                AddBrick(visualBrick.type, visualBrick.position, visualBrick.colour, visualBrick.users);
            }
        }
    }

    


    /// <summary>
    /// Adds a brick ameobject to the scene and brick componenet of that to the list of bricks 
    /// </summary>
    public void AddBrick(int type, int[] position, int colour, List<string> users)
    {
        // Create brick
        Brick newBrick = GameObject.Instantiate(brickPrefab).GetComponent<Brick>();
        newBrick.Initialise(type, position, colour, users);
        
        newBrick.transform.parent = transform;
        newBrick.transform.localScale = Vector3.one;
        newBrick.transform.localPosition = Vector3.zero;
        newBrick.data = brickData;
      
        // Add bricks to the list
        bricksOnPlate.Add(newBrick);
    }

    public void RemoveBrick(Brick removeBrick)
    {   
        // Remove brick from the list
        bricksOnPlate.Remove(removeBrick);
        
        // Remove the brick
        removeBrick.DestroyBrick();
    }
}
