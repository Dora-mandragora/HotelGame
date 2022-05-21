using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    public static bool IsGamePause = false;
    public GameObject ShopMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))       
        {            
            Close();           
        }
    }

    private void OnMouseDown()
    {
        //if (Input.GetMouseButtonDown(2))
        {
            OpenMenu();
        }
    }

    public void Close()
    {
        Cursor.lockState = CursorLockMode.Locked;
        ShopMenuUI.SetActive(false);        
    }

    public void OpenMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        ShopMenuUI.SetActive(true);        
    }
}
