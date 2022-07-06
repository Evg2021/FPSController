using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseMenu : MonoBehaviour
{
    public GameObject menu;
    private const string menuName = "Panel";
    // Start is called before the first frame update

    private void Awake()
    {
        InitializedMenuPanel();
    }
    private void InitializedMenuPanel()
    {
        menu = GameObject.Find(menuName);
        if(menu != null)
        {
            menu.SetActive(false);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (menu != null && Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(!menu.activeSelf);
        }
        
    }
}
