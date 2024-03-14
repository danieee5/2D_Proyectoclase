using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GargabeCollector : MonoBehaviour
{ 
    void OnTriggerEnter2D(Collider2D collision)
    {
       Destroy(collision.gameObject);
    } 
}
   // el garbage debe estar con trigger activado ya que sirve como detección, no para que las cosas choquen, si el trigger esta actviado, no va a chocar

    // debe estar en kinematic dentro del Rigidbody2D para que no este afectado por la fisica, lo puedo dejar fijo y aun así va a detectar colisiones con otros objetos,