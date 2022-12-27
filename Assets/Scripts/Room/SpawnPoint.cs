using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public int openSide;
    private RoomTemplate templates;
    private int random;
    private bool spawn;
    void Start()
    {
        spawn = false;
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>(); 
        Invoke("Spawn",3f);
    }
    private void Spawn()
    {
        if (!spawn)
        {
            if (openSide == 1)
            {
                random = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[random], transform.position, templates.bottomRooms[random].transform.rotation);
            }
            else if (openSide == 2)
            {
                random = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[random], transform.position, templates.topRooms[random].transform.rotation);
            }
            else if (openSide == 3)
            {
                random = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[random], transform.position, templates.leftRooms[random].transform.rotation);
            }
            else if (openSide == 4)
            {
                random = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[random], transform.position, templates.rightRooms[random].transform.rotation);
            }
            spawn = true;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint") && other.GetComponent<SpawnPoint>().spawn == true)
        {
            Destroy(gameObject);
        }
    }
}

