using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{

    private NavMeshAgent agent;
    public Transform reception;
    public List<Room> rooms;    

    public bool isServe = false;
    public float moneyPerSec = 0.1f;
    public float mood = 1;
    public int room;

    // Start is called before the first frame update
    void Awake()
    {
        isServe = false;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(reception.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mood -= 0.0001f;
    }

    private void OnMouseDown()
    {
        if(mood <= 1.2f) mood += 0.3f;
        if (mood <= 0.1f) Destroy();
        if (!isServe)
            try
            {
                isServe = true;
                var emptyRoom = (rooms.Find(r => r.isEmpty));
                agent.SetDestination(emptyRoom.room.position);
                emptyRoom.isEmpty = false;
                room = rooms.LastIndexOf(emptyRoom);
            }
            catch
            {
                print("Rooms are full!");
            }
    }

    public float GetMoney()
    {
        if (isServe) return moneyPerSec * mood;
        else return 0;
    }

    public void Destroy()
    {
        print("NPC leave");
        rooms[room].isEmpty = true;
        Destroy(this.gameObject);
    }
}
