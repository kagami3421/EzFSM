using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestScript : StateMachine
{
	void Awake()
	{

	}

	void Start ()
	{
        IdleBall idle = new IdleBall();
        MovingBall moving = new MovingBall();


        idle.AddTransition(moving, "GoToMove");
        moving.AddTransition(idle, "GoToIdle");

        AddState(idle, "Idle");
        AddState(moving, "Moving");

        InitFSM();
	}
	
	void Update ()
	{
        if (Input.GetKeyUp(KeyCode.G))
        {
            ChangeState("GoToMove");
        }

        if (Input.GetKeyUp(KeyCode.H))
        {
            ChangeState("GoToIdle");
        }
	}
}

public class IdleBall : State
{
    public override void Enter(GameObject Go)
    {
        Debug.Log("Enter Idle!!");
    }

    public override void Stay(GameObject Go)
    {
        Debug.Log("I'm Idle!!");
    }

    public override void Exit(GameObject Go)
    {
        Debug.Log("Exit Idle!!");
    }
}

public class MovingBall : State
{
    public override void Enter(GameObject Go)
    {
        Debug.Log("Enter Moving!!");
    }

    public override void Stay(GameObject Go)
    {
        Debug.Log("I'm Moving!!");

        Go.transform.Translate(Vector3.right * Time.deltaTime);
    }

    public override void Exit(GameObject Go)
    {
        Debug.Log("Exit Moving!!");
    }
}
