using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public int openSide;
    private RoomTemplate templates;
    private int random;
    public bool spawn;
    private Vector3 centralRoomError; //por alguna razón el prefab de la central room es la unica que su transform 0,0 aparece corrida 3 unidades a la izquierda 
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
                if (templates.bottomRooms[random].CompareTag("CentralRoom"))
                {
                    centralRoomError = new Vector3(transform.position.x + 3f, transform.position.y);
                    Instantiate(templates.bottomRooms[random], centralRoomError, templates.bottomRooms[random].transform.rotation);
                }
                else
                {
                    Instantiate(templates.bottomRooms[random], transform.position, templates.bottomRooms[random].transform.rotation);
                }
            }
            else if (openSide == 2)
            {
                random = Random.Range(0, templates.topRooms.Length);
                if (templates.topRooms[random].CompareTag("CentralRoom"))
                {
                    centralRoomError = new Vector3(transform.position.x + 3f, transform.position.y);
                    Instantiate(templates.topRooms[random], centralRoomError, templates.topRooms[random].transform.rotation);
                }
                else
                {
                    Instantiate(templates.topRooms[random], transform.position, templates.topRooms[random].transform.rotation);
                }
            }
            else if (openSide == 3)
            {
                random = Random.Range(0, templates.leftRooms.Length);
                if (templates.leftRooms[random].CompareTag("CentralRoom"))
                {
                    centralRoomError = new Vector3(transform.position.x + 3f, transform.position.y);
                    Instantiate(templates.leftRooms[random], centralRoomError, templates.leftRooms[random].transform.rotation);
                }
                else
                {
                    Instantiate(templates.leftRooms[random], transform.position, templates.leftRooms[random].transform.rotation);
                }
            }
            else if (openSide == 4)
            {
                random = Random.Range(0, templates.rightRooms.Length);
                if (templates.rightRooms[random].CompareTag("CentralRoom"))
                {
                    centralRoomError = new Vector3(transform.position.x + 3f, transform.position.y);
                    Instantiate(templates.rightRooms[random], centralRoomError, templates.rightRooms[random].transform.rotation);
                }
                else
                {
                    Instantiate(templates.rightRooms[random], transform.position, templates.rightRooms[random].transform.rotation);
                }
            }
            spawn = true;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            Destroy(gameObject);
            Debug.Log("destruido en segundos");
        }
    }
}

