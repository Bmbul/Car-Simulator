using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Building"))
        {
            //Stop Movement
            CarController.inputX = 0;
            CarController.inputY = 0;
        }
    }
}
