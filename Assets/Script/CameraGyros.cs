using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGyros : MonoBehaviour
{
    public GameObject ARSessionOrigin;

    private void Awake()
    {
        Input.gyro.enabled = true;
        Input.compass.enabled = true;
        CamareaGyro();
    }

    // Start is called before the first frame update
    void Start() => CamareaCompass();

    void CamareaGyro()
    {
        var GyroSensor = Input.gyro.attitude;
        ARSessionOrigin.transform.Rotate(Quaternion.ToEulerAngles(GyroSensor));
        ARSessionOrigin.transform.Rotate(ARSessionOrigin.transform.localEulerAngles.x, 0, ARSessionOrigin.transform.localEulerAngles.z);
        //ARSessionOrigin.transform.Rotate(GyroSensor.ToEuler());
    }

    void CamareaCompass()
    {
        var MagneticDec = (decimal)Input.compass.magneticHeading;
        var MagneticFloat = (float)System.Math.Round(MagneticDec, 2, System.MidpointRounding.AwayFromZero);
        if (Input.gyro.gravity.x <= -0.9f && Mathf.Abs(Input.gyro.gravity.y) < 0.2f)
        {
            MagneticFloat += 90;
        }
        else if(Input.gyro.gravity.x >= 0.9f && Mathf.Abs(Input.gyro.gravity.y) < 0.2f)
        {
            MagneticFloat -= 90;
        }
        //else if ((Input.gyro.gravity.x + Input.gyro.gravity.y) < -1.1f && Mathf.Abs(Input.gyro.gravity.x) < 0.5f)
        //{
        //    MagneticFloat += 90;
        //}
        //else if ((Input.gyro.gravity.x + Input.gyro.gravity.y) > 0.3f && Input.gyro.gravity.x < 0.3f)
        //{
        //    MagneticFloat -= 90;
        //}

        //else if(Input.gyro.gravity.y >= 0.9f && Mathf.Abs(Input.gyro.gravity.x) < 0.5f)
        ARSessionOrigin.transform.Rotate(0, MagneticFloat, 0);
    }

}
