using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscreteMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] AnimationStateChanger animationStateChanger;
    [SerializeField] float speed = 1; 
    [SerializeField] Transform body;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }
    public void Movement(Vector3 vel)
    {
        transform.position += vel * speed * Time.deltaTime;
    }
    public void MoveRB(Vector3 vel)
    {
        rb.velocity = vel * speed; 
        if( vel.magnitude > 0)
        {
            animationStateChanger.ChangeAnimationState("Walk");
            if(vel.x > 0)
            {
                body.localScale = new Vector3(1,1,1);
            }
            else if( vel.x < 0){
                body.localScale = new Vector3(-1,1,1);
            }
        }
        else{
            animationStateChanger.ChangeAnimationState("Idle");
        }
    }

}