using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionForCamera : MonoBehaviour
{
    public Scrollbar Scrollbar;
    public Transform N;
    public Transform E;
    public Transform S;
    public Transform W;
    public Transform[] MagneticPole;
    public GameObject[] DirLine;
    public TextMesh[] DirLinesText;

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = Camera.main.transform.position;
        TextMeshPos();
        LineToDir();
    }

    public void Btn_Even()
    {
        var direction = Scrollbar.value * 10;
        var CamPos = Camera.main.transform.position;
       
        N.position = CamPos + new Vector3(0, 0, 2 + direction);
        E.position = CamPos + new Vector3(2 + direction, 0, 0);
        S.position = CamPos + new Vector3(0, 0, -2 - direction);
        W.position = CamPos + new Vector3(-2 - direction, 0, 0);

    }

    void LineToDir()
    {
        var TextTR = Vector3.zero;
        TextTR.y -= 0.5f;
        for (int i = 0; i < DirLine.Length; i++)
        {
            var Pole = MagneticPole[i].name;
            DirLine[i].GetComponent<LineRenderer>().SetPosition(0, TextTR);
            DirLine[i].GetComponent<LineRenderer>().SetPosition(1, MagneticPole[i].localPosition);
            DirLinesText[i].text = Pole + " : " + TextMeshDir(DirLine[i].GetComponent<LineRenderer>().GetPosition(1));         
        }

    }

    void TextMeshPos()
    {
        var TextTR = this.transform.position;
        TextTR.y -= 0.5f;
        for (int i = 0; i < DirLine.Length; i++)
        {
            switch (i)
            {
                case 0:
                    DirLinesText[i].transform.position = TextTR + 2 * Vector3.forward;
                    break;
                case 1:
                    DirLinesText[i].transform.position = TextTR + 2 * Vector3.right;
                    break;
                case 2:
                    DirLinesText[i].transform.position = TextTR + 2 * Vector3.back;
                    break;
                case 3:
                    DirLinesText[i].transform.position = TextTR + 2 * Vector3.left;
                    break;
            }
        }

    }

    string TextMeshDir(Vector3 AzimuthCoordinates)
    {
        return Vector3.Distance(this.transform.position, AzimuthCoordinates).ToString("0.0");
    }

    public void GyroscopeImg_active()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }
}
