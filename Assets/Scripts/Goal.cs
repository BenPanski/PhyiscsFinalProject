using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{

    // defined from the player perspective!
    [SerializeField] GameObject TopRight;
    [SerializeField] GameObject TopLeft;
    [SerializeField] GameObject BotRight;
    [SerializeField] GameObject BotLeft;

    [SerializeField] Goal nextGoal;
    [SerializeField] Shoot _shoot;
    [SerializeField] Instructions instructions;


    float BotRightX;
    float TopRightX;
    float TopRightZ;
    float TopLeftZ;
    

   

    private void Awake()
    {
        TopRightX = TopRight.transform.position.x;
        BotRightX = BotRight.transform.position.x;
        TopRightZ = TopRight.transform.position.z;
        TopLeftZ = TopLeft.transform.position.z;

    }
    public bool AreWeColliding(Transform ballPos) 
    {

        if (ballPos.position.x < TopRightX && ballPos.position.x > BotRight.transform.position.x) // ball inside the x axis of the goal (forward)
        {
            if (ballPos.position.z> TopRightZ && ballPos.position.z < TopLeftZ) // ball inside the y axis of the goal (sideways)
            {
                instructions.Goalllllllllll();
                nextGoal.transform.parent.gameObject.SetActive(true);
             
                _shoot.UpdateGoal(nextGoal);
                gameObject.transform.parent.gameObject.SetActive(false);

                return true;
            }
           
        }

        return false;
    }

   




}
