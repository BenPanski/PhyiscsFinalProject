using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject Ball;
    [SerializeField] GameObject Fan;
    [SerializeField] Goal _goal;
    [SerializeField] int BallAmount = 50;
    [SerializeField] float Force = 50;
    [SerializeField] float Gravity = 50;
    [SerializeField] float GroundFriction = 0.2f;
    [SerializeField] float AirFriction = 0.1f;
    [SerializeField] float Mass = 0.1f;
    [SerializeField] float windSpeed = 0.1f;
    [SerializeField] float FanRange = 4;
    List<Ball> balls = new List<Ball>();
    private void Awake()
    {
        for (int i = 0; i < BallAmount; i++)
        {
           var g = Instantiate(Ball,transform.position,Quaternion.identity);
            g.SetActive(false);
            balls.Add(g.GetComponent<Ball>());
        }
        
    }


    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space) && balls.Count > 0)
        {
            balls[0].gameObject.SetActive(true);
            balls[0].ShootMe(Force,Gravity,GroundFriction,AirFriction,Mass,transform.forward,_goal,Fan, windSpeed, FanRange);
            balls.RemoveAt(0);
        }
        
    }

  public void UpdateGoal(Goal goal)
    {
        _goal = goal;
    }







}
