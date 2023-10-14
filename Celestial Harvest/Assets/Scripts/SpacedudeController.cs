using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacedudeController : MonoBehaviour
{
    DiscreteMovement move;

    void Awake(){
        move = GetComponent<DiscreteMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 vel = Vector3.zero; //dont include the new with static vectors 
        
        if (Input.GetKey(KeyCode.A)){
            vel.x = -1;
        }
        if (Input.GetKey(KeyCode.D)){
            vel.x = 1;
        }
        if (Input.GetKey(KeyCode.W)){
            vel.y = 1;
        }
        if (Input.GetKey(KeyCode.S)){
            vel.y = -1;
        }
        //move.Movement(vel);
        move.MoveRB(vel);
        
    }
}
