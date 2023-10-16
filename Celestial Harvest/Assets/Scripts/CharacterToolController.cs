// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CharacterToolController : MonoBehaviour
// {
//     CharacterController2D character;
//     Rigidbody2D rd;
//     [SerializeField] float offsetDistance = 1f;
//     [SerializeField] float sizeOfInteractableArea = 1.2f;

//     void Awake (){
//         character = getComponent<CharacterController2D>();
//         rd = getComponent<Ridgidbody2D>();
        

//     }

//     void Update (){
//         if (Input.GetMouseButtonDown(0)){
//             UseTool();
//         }
//     }

//     void UseTool (){
//         Vector2 position = rd.position + character.lastMotionVector * offsetDistance;

//         Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

//         foreach(Collider2D c in colliders){
//             ToolHit hit = c.GetComponent<ToolHit>();
//             if (hit != null){
//                 hit.Hit();
//                 break;
//             }
//         }
//     }
// }
