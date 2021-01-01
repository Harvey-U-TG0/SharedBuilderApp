using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class API : MonoBehaviour
{
	// Call Method Through: StartCourotine(SendRequest());

	private void Update()
	{
		if (Input.anyKeyDown)
		{
			StartCoroutine(SendRequest());
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
}
