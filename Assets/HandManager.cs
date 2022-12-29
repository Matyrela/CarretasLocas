using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    int half;
    [SerializeField] Vector3 R;
    [SerializeField] Vector3 L;

    void Start()
    {
        half = Screen.width / 2;
    }

    //Dibujado:

    //Espada atras 9
    //Personaje 10
    //Espada adelante 11

    void Update()
    {
        if(Input.mousePosition.x >= half)
        {
            this.transform.localPosition = R;
        }
        else
        {
            this.transform.localPosition = L;
        }
        
        //Apretas W
        if(Input.GetAxisRaw("Vertical") > 0)
        {
            this.transform.GetComponentInChildren<SpriteRenderer>().sortingOrder = 9;
        }
        else if(Input.GetAxisRaw("Vertical") <= 0)
        {
            this.transform.GetComponentInChildren<SpriteRenderer>().sortingOrder = 11;
        }

        //Mouse Position in the world. It's important to give it some distance from the camera. 
        //If the screen point is calculated right from the exact position of the camera, then it will
        //just return the exact same position as the camera, which is no good.
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);

        //Angle between mouse and this object
        float angle = AngleBetweenPoints(transform.GetComponentInChildren<Transform>().position, mouseWorldPosition);

        //Ta daa
        transform.GetComponentInChildren<Transform>().rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 90));
    }

    float AngleBetweenPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
