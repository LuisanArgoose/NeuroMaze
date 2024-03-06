using System.Collections;
using UnityEngine;
using System;
using System.Net.Http;
using UnityEngine.UI;
using UnityEngine.Networking;



public class ArrowController : MonoBehaviour
{
    public LevelCreateScript GameController;
    public float RotationSpeed = 1.0f;
    private Vector2 velocity;
    Rigidbody2D m_Rigidbody;
    Vector2 VectorMath;
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        
        m_Rigidbody.velocity *=.0f;
        m_Rigidbody.angularVelocity *= .0f;
        velocity = new Vector2(Mathf.Cos(m_Rigidbody.rotation*Mathf.PI/180)*0.05f , Mathf.Sin(m_Rigidbody.rotation * Mathf.PI / 180) * 0.05f);
        if (ContrillerScript.SG.IsArmMode)
        {
            if (Input.GetKey(KeyCode.Space) )//& ArmCondition)// || Pot > 0.5 & NeuroCondition)
            {
                ContrillerScript.SG.Bar.ActualParameter = 100;

            }
            else
            {
                ContrillerScript.SG.Bar.ActualParameter = 0;
            }
        }
        

        if (ContrillerScript.SG.Bar.ActualParameter > 50 )//& ArmCondition)// || Pot > 0.5 & NeuroCondition)
        {
            m_Rigidbody.MovePosition(m_Rigidbody.position + velocity);
        }
        else
        {
            transform.Rotate(0.0f, 0.0f, RotationSpeed);
        }
    }   
    
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Finish"){
            GameController.EndGame();
        }

    }

}
