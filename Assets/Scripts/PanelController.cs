using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    private const string nameOdj = "IncreaseButton";
    private const string nameBut = "DecreaseButton";

    public GameObject rotatorableObj;
    public Button DecreaseBut;
           
    public void OnClickButtonDecreaseButton()
    {
        if (rotatorableObj != null)
        {
            rotatorableObj.transform.Rotate(Vector3.forward, -90.0f);
        }
    }
    
    public void OnClickTestButton(string value = "default")
    {
        Debug.Log(value);
    }
        
    private void Start()
    {
        var objBut = GameObject.Find(nameBut);//?.GetComponent<Button>();
        if(objBut != null)
        {
            DecreaseBut = objBut.GetComponent<Button>();
            if (DecreaseBut != null)
            {
                DecreaseBut.onClick.AddListener(() => OnClickButtonDecreaseButton());
                DecreaseBut.onClick.AddListener(() => OnClickTestButton());
            }
        }

        //DecreaseButton = GameObject.Find(nameBut);
        rotatorableObj = GameObject.Find(nameOdj);


    }
}
