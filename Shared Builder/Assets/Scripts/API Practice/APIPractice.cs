using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class APIPractice : MonoBehaviour
{
	// Call Method Through: StartCourotine(SendRequest());

	private void Update()
	{
		if ((Input.anyKeyDown)) //|| (Input.GetTouch(0).phase == TouchPhase.Began))
		{
			StartCoroutine(SendTestRequest());
			print("test");
		}
	}


	IEnumerator SendRequest()
	{
		UnityWebRequest request = UnityWebRequest.Get("http://192.168.1.73:5000/getUser/Edward");
		yield return request.SendWebRequest();

		if (request.isNetworkError || request.isHttpError)
		{
			// Error Occurred
			Debug.Log(request.error);
		}

		else
		{
			// Response can be accessed through: request.downloadHandler.text
			Debug.Log(request.downloadHandler.text);
		}
	}

	IEnumerator SendTestRequest()
	{
		UnityWebRequest request = UnityWebRequest.Get("http://192.168.1.73:5000/unityTestGet");
		yield return request.SendWebRequest();

		if (request.isNetworkError || request.isHttpError)
		{
			// Error Occurred
			Debug.Log(request.error);
		}

		else
		{
			// Response can be accessed through: request.downloadHandler.text
			Debug.Log(request.downloadHandler.text);
			ProcessTestRequest(request.downloadHandler.text);
		}
	}

	public void ProcessTestRequest(string recievedJSON)
	{
		TestDataClass testBackFromJson = JsonUtility.FromJson<TestDataClass>(recievedJSON);
		print("Data in received converted object level" + testBackFromJson.level);
		print("Data in received converted object timeElapsed" + testBackFromJson.timeElapsed);
		print("Data in received converted object player Name" + testBackFromJson.playerName);
	}
}
