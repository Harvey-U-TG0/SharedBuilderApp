using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerRotControl : MonoBehaviour
{
    public float angularSpeedY;
    public float angularSpeedX;

    public float angleY;
    public float angleX;

    public float angleXMin;
    public float angleXMax;

    // Update is called once per frame
    void Update()
    {
        angleX += Input.GetAxis("Vertical") * angularSpeedX * Time.deltaTime;
        angleX = Mathf.Clamp(angleX, angleXMin, angleXMax);

        angleY -= Input.GetAxis("Horizontal") * angularSpeedY * Time.deltaTime;
        transform.rotation = Quaternion.Euler(angleX, angleY, 0f);
    }
}
