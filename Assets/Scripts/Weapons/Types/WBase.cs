using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WBase : MonoBehaviour
{
    //Script base de todas las armas, la logica implementada aqui se implementara en todas las armas del juego
    public bool WeaponEquipped;

    private void Start()
    {
        GameObject Hand = this.transform.parent.gameObject;
        if(Hand.tag == "Hand")
        {
            WeaponEquipped = true;
        }
    }
}
