using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float _force;
    private float _gravity;
    private float _windSpeed;
    private float _fanRange;
    // private Wind Script
    [SerializeField] Transform MyGroundCheck;
    private float _groundFriction = 0.2f;
    private float _mass = 1;
    private Vector3 _direction;
    private float _airFriction = 0.1f;
    List<Vector3> AllMovment = new List<Vector3>();
    Vector3 HowToMove;
    Vector3 WindSum;
    bool Grounded;
    Goal _goal;
    GameObject _fan;
    List<Vector3> WindMovment = new List<Vector3>();



    private float timer;

    [SerializeField] float GroundY = 0.1f;

 
    void Update()
    {
        GoalScoreCheck();

        WindEffect();
        // calculate where the wind is and if its in range
        // if it is AddMovment wind

        AddFriction(); // lower force by an amount depending if the ball is airborn or not

        GravityIfAirborn();// adds gravity if the ball is in the air

        AddMovment(_direction, _force); // thrown force

        // AddMovment(Vector3.down, _windSpeed); // wind

        SummerizeMovment(); // adds up all the vectors from all movment into howtomove
        Move();// moves in the howtomove direction

        timer += Time.deltaTime;


        if (timer > 100)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void WindEffect()
    {
        if (Mathf.Abs( this.transform.position.x - _fan.transform.position.x ) < _fanRange) // if the ball is in fan range
        {

            if (this.transform.position.z < _fan.transform.position.z) // if the fan is to the left
            {
                AddMovment(Vector3.back, _windSpeed);
            }
            else                                                      // if the fan is to the right
            {
                AddMovment(Vector3.forward, _windSpeed);
            }

            if (this.transform.position.x < _fan.transform.position.x) // if the fan is in front of the ball
            {
                AddMovment(Vector3.left, _windSpeed);
            }
            else                                                      // if the fan is behind
            {
                AddMovment(Vector3.right, _windSpeed);
            }
        }

    }

    private void GoalScoreCheck()
    {
        
            if (_goal.AreWeColliding(this.transform))
            {
                gameObject.SetActive(false);
            }
        
    }

    private void GravityIfAirborn()
    {
       
        if (!Grounded)
        {
            AddMovment(Vector3.down, _gravity); // gravity
        }

    }

    private void AddFriction()
    {
        Grounded = MyGroundCheck.position.y < GroundY;

        

        if (_force <= 0.01)        // if force is close to 0
        {
            _force = 0;               // if force is 0
            return;
        }

        if (!Grounded)
        {
            _force -=  _airFriction; // add air friction
        }
        else
        {
            _force -= _groundFriction; // add air ground friction

        }


        if (_force <= 0.01)        // if force is close to 0
        {
            _force = 0;               // if force is 0
            return;
        }
    }

    void AddMovment(Vector3 direction, float TimesWhat) // adds movment to all movment list
    {
        AllMovment.Add(direction * TimesWhat);

    }
    void AddWindMovement(Vector3 direction, float TimesWhat) // adds movment to all movment list
    {
        WindMovment.Add(direction * TimesWhat*Time.deltaTime);

    }
    void SummerizeMovment() // adds up all the vectors from all movment into howtomove
    {
        HowToMove =Vector3.zero;
        

        foreach (Vector3 movement in AllMovment)
        {

            HowToMove += movement;

        }
     
    }
    void Move()
    {
        if (Grounded)
        {
            HowToMove.y = 0;
           
        }
        transform.Translate(HowToMove * Time.deltaTime / _mass );


    } // moves in the howtomove direction
    public void ShootMe(float Force, float gravity,float GroundFriction,float AirFriction,float Mass,Vector3 Direction,Goal goal,GameObject Fan,float windSpeed,float FanRange)
    {
        _force = Force;
        _gravity = gravity;
        _airFriction = AirFriction;
        _groundFriction = GroundFriction;
        _mass = Mass;
        _direction = Direction;
        _goal = goal;
        _fan = Fan;
        _windSpeed = windSpeed;
        _fanRange = FanRange; 
    }

}
