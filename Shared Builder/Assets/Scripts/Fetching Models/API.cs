using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class API : MonoBehaviour
{
	public List<Model> models;
	public Model outputModel;


	// after / is the model ID
	private string urlGetModel = "http://192.168.1.73:5000/getModel";


	public void GetModel()
    {
		StartCoroutine(SendRequest(urlGetModel));
    }

	IEnumerator SendRequest(string URL)
	{
		UnityWebRequest request = UnityWebRequest.Get(URL);
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
		outputModel = JsonUtility.FromJson<Model>(recievedModelJSON);
		//models.Add(outputModel);
	}
}
