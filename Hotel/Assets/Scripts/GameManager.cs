using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float money = 1000f;
    public float updateMultiplier = 1;
    public GameObject NPCPrefab;
    public GameObject PlayerPrefab;

    public float startX;
    public float startY;

    private GameObject[] NPCs;
    private GUIStyle style;

    void Start()
    {
        startX = 0;
        startY = 0;

        style = new GUIStyle();
        style.normal.textColor = new Color(255,252,189);
        style.fontSize = 40;

        StartCoroutine(SpawnNPC());

        StartCoroutine(FindNPCs());
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 25, 50), money.ToString(), style);    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        NPCs = GameObject.FindGameObjectsWithTag("NPC");
        if (NPCPrefab == null) NPCPrefab = NPCs[0];
        else if (NPCs.Length == 0) print("Game over");
    }

    IEnumerator SpawnNPC()
    {
        yield return new WaitForSeconds(10);
        if (NPCs.Length < 7)
            Instantiate(NPCPrefab, new Vector3(startX,startY,0),Quaternion.identity);
        StartCoroutine(SpawnNPC());
    }
    IEnumerator DestroyNPC(AIController npc)
    {
        yield return new WaitForSeconds(180);
        if (npc != null)
        {
            npc.Destroy();
        }
    }
    IEnumerator FindNPCs()
    {
        yield return new WaitForSeconds(1);
        foreach (GameObject NPC in NPCs)
        {
            var npc = NPC.GetComponent<AIController>();
            if (npc.isServe)
            {
                StartCoroutine(GetMoney(npc));
                StartCoroutine(DestroyNPC(npc));
            }
        }
        StartCoroutine(FindNPCs());
    }
    IEnumerator GetMoney(AIController npc)
    {
        yield return new WaitForSeconds(1);
        money += npc.GetMoney()*updateMultiplier;
        //StartCoroutine(GetMoney(npc));
    }
}
