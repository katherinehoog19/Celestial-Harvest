using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SpacedudeController : MonoBehaviour
{
    DiscreteMovement move;
    [SerializeField] GameObject cp;
    FarmManager fm;
    [SerializeField] Text taunt;

    void Awake(){
        fm = cp.GetComponent<FarmManager>(); 
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
        if (Input.GetKey(KeyCode.F)){
            //Debug.Log(fm.currentWallet());
            if(fm.currentWallet() >= 500){
                SceneManager.LoadScene("End Screen");
            } 
            else {
                taunt.text = "Not Enough Money! You need $" + (500 - fm.currentWallet()).ToString();
            }
        }
        //move.Movement(vel);
        move.MoveRB(vel);
        
    }
}
