using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralSpawnPoint : MonoBehaviour
{
    public int openSide;
    private RoomTemplate templates;
    public bool spawned;
    void Start()
    {
        spawned = false;
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>(); 
        Invoke("Spawn", 0.1f);
    }

    public void Spawn()
    {
        if (!spawned)
        {
            if (openSide == 1 || openSide == 2)
            {
                Instantiate(templates.bottomRooms[3], transform.position, templates.bottomRooms[3].transform.rotation);
                
            }
            else if (openSide == 3 || openSide == 4)
            {
                Instantiate(templates.rightRooms[3], transform.position, templates.rightRooms[3].transform.rotation);
            }
            
            spawned = true;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            Destroy(other.gameObject);
        }
    }
}
