using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class API : MonoBehaviour
{
	public Model latestModel;

	public string currentModel = "test";
	public string username = "Emily";

	// after / is the model ID
	//private string urlGetModel = "http://192.168.1.73:5000/getModel/test";
	private string baseURL = "http://192.168.1.73:5000/";
	
	public void SetModelId(string newID)
	{
		currentModel = newID;
	}

	public void Setusername(string newName)
	{
		username = newName;
	}

	public void GetModel()
    {
		StartCoroutine(SendModelRequest(currentModel));
    }

	/// <summary>
	/// Updates the users editing setting
	/// </summary>
	/// <param name="state">bool, False to stop editing, true to start editing</param>
	public void UpdateEditing(bool newState)
	{
		if (newState == true)
		{
			StartCoroutine(SendEditStatus(currentModel));
		}
		else
		{
			StartCoroutine(SendEditStatus("False"));
		}
	}

	IEnumerator SendModelRequest(string modelID)
	{
		UnityWebRequest request = UnityWebRequest.Get(baseURL+"getModel/"+modelID);
		yield return request.SendWebRequest();

		if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
		{
			// Error Occurred
			Debug.Log(request.error);
		}

		else // The request is alis
		{
			// Response can be accessed through: request.downloadHandler.text
			Debug.Log(request.downloadHandler.text);
			ParseModelJSON(request.downloadHandler.text);
		}
	}

	public void ParseModelJSON(string recievedModelJSON)
	{
		latestModel = JsonUtility.FromJson<Model>(recievedModelJSON);
		//models.Add(outputModel);
	}


	IEnumerator SendEditStatus(string newEditstatus)
	{
		// Editing status is the new model we want to edit send string 'False'

		UnityWebRequest request = UnityWebRequest.Get(baseURL +"updateUserEditing/" + username + "/" + newEditstatus);
		yield return request.SendWebRequest();

		if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
		{
			// Error Occurred
			Debug.Log(request.error);
		}

		else // The request is alis
		{
			// Response can be accessed through: request.downloadHandler.text
			Debug.Log(request.downloadHandler.text);
		}
	}


}
