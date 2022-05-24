using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    public static bool IsGamePause = false;
    public GameObject ShopMenuUI;
    public bool isOpen = false;
    public GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isOpen)       
        {            
            Close();           
        }
        if (Input.GetKeyDown(KeyCode.Escape)) Cursor.lockState = CursorLockMode.None;
        if(Input.GetKeyDown(KeyCode.Mouse1)) Cursor.lockState = CursorLockMode.Locked;

    }

    private void OnMouseDown()
    {
        if(GameManager.money> 500 * GameManager.updateMultiplier && !isOpen)
        {
            GameManager.money -= 500 * GameManager.updateMultiplier;
            GameManager.updateMultiplier += 0.1f;
            StartCoroutine(OpenMenu());
        }       
    }

    public void Close()
    {
        isOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
        ShopMenuUI.SetActive(false);        
    }

    IEnumerator OpenMenu()
    {
        isOpen = true;
        //Cursor.lockState = CursorLockMode.None;
        ShopMenuUI.SetActive(true);        
        yield return new WaitForSeconds(1);
        ShopMenuUI.SetActive(false);
    }
}
