using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gyroscope : MonoBehaviour
{
    public Text UI_Gyroscope_Text1;
    public Text UI_Gyroscope_Text2;
    public Text UI_Gyroscope_Text3;
    public GameObject UI_Gyroscope;
    public GameObject UI_Gyroscope2;
    public GameObject GyroscopeGameObjects;
    public Scrollbar Scrollbar;

    // Start is called before the first frame update
    void Start()
    {
        //Input.gyro.enabled = true;
        Input.compass.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        var V3AT = Input.gyro.attitude;
        //UI_Gyroscope_Text1.text = "计非絋" + Input.compass.headingAccuracy.ToString("0.00") + "\n癸莱瞶伐" + Input.compass.trueHeading.ToString("0.00");
        //UI_Gyroscope_Text3.text = "癸合伐计" + Input.compass.magneticHeading.ToString("0.00");
        //UI_Gyroscope_Text3.text = Input.gyro.attitude.ToString();
        //UI_Gyroscope_Text3.text = (V3AT.x * 180).ToString("0.00") + "\n" + (V3AT.y * 180).ToString("0.00") + "\n" + (V3AT.z * 180).ToString("0.00");
        //UI_Gyroscope_Text3.text = Screen.orientation.ToString();
        //UI_Gyroscope_Text3.text = UI_Gyroscope2.transform.localEulerAngles.ToString() + "O\nC" + UI_Gyroscope.transform.localEulerAngles.ToString();
        UI_Gyroscope_Text2.text = "" + Scrollbar.value * 10;
        //UI_Gyroscope_Text2.text = Quaternion.ToEulerAngles(V3AT).ToString();
        //UI_Gyroscope_Text3.text = "合:" + Input.compass.rawVector.ToString("0.00");

        //if (Mathf.Abs(Input.gyro.gravity.z) <= 0.9f)
        //{
        //    if (Mathf.Abs(Input.gyro.gravity.x) > Mathf.Abs(Input.gyro.gravity.y))
        //    {
        //        if (Input.gyro.gravity.x > 0f)
        //        {
        //            UI_Gyroscope_Text3.text = "R";
        //        }
        //        else
        //        {
        //            UI_Gyroscope_Text3.text = "L";
        //        }
        //    }
        //}
        var nu = Quaternion.ToEulerAngles(Input.gyro.attitude);
        UI_Gyroscope_Text3.text = Input.gyro.gravity.ToString();
    }

}
