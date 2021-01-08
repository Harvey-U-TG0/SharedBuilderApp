using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisuliserCalculations
{
	/// <summary>
	/// Processes an input model ad turns it into a lit
	/// </summary>
	/// <param name="inputModel"></param>
	public static List<BrickVisual> ExtractBricksFromModel(Model inputModel)
	{
		// The list that this function defines
		List<BrickVisual> brickVisuals = new List<BrickVisual>();

		List<UserContrib> userContribs = inputModel.userContributions;

		foreach (UserContrib user in userContribs)
		{
			// Each usercontrib has a username and list of bricks
			foreach (BrickInfo brickInfo in user.brickConfig)
			{
				// Check it that brick type, position and colour is in the list already
				// If so add this username to it, if not make a new entry in the list
				BrickVisual exisitingBrick = brickVisuals.Find(x => (x.type == brickInfo.shapeID) && (x.position[0] == brickInfo.position[0]) && (x.position[1] == brickInfo.position[1]) && (x.colour == brickInfo.colourID));
				if (exisitingBrick != null)
				{
					// Add username to the existing brick
					exisitingBrick.users.Add(user._id);
				}
				else
				{
					BrickVisual newBrick = new BrickVisual(brickInfo.shapeID,brickInfo.position,brickInfo.colourID, new List<string> {user._id});
					brickVisuals.Add(newBrick);
				}

			}
		}


		return (brickVisuals);
	}



	/// <summary>
	/// Compares two lists to see if they contain the same strings
	/// </summary>
	/// <param name="a"></param>
	/// <param name="b"></param>
	/// <returns>bool, True if the lists contain the same contents</returns>
	public static bool CompareStringLists(List<string> a, List<string> b)
	{
		if (a.Count != b.Count)
		{
			return false;
		}
		else
		{
			foreach (string itemA in a)
			{
				bool inList = false;
				foreach (string itemB in b)
				{
					if (itemA == itemB)
					{
						inList = true;
						break;
					}
				}
				if (inList == false) return (false);
			}
		}
		return (true);
	}
}
