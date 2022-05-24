using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{    
    public Transform room;
    public bool isEmpty = true;
    
    // Start is called before the first frame update
    void Start()
    {
        room = GetComponent<Transform>();
        isEmpty = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
