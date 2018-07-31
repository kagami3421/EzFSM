using UnityEngine;
using Kagami.EasyFSM;

public class TestScript : StateMachine
{
    public override void InitFSM()
    {
        AddState("Idle" , new IdleBall(this) , true);
        AddState("Move", new MovingBall(this) , false);
    }
}

public class IdleBall : State
{
    public IdleBall(StateMachine context) : base(context)
    {
    }

    public override void Enter()
    {
        Debug.Log("Enter Idle!!");
    }

    public override State Stay()
    {
        Debug.Log("I'm Idle!!");

        if (Input.GetKeyUp(KeyCode.G))
            return _context.GetState("Move");
        else
            return null;
    }

    public override void Exit()
    {
        Debug.Log("Exit Idle!!");
    }
}

public class MovingBall : State
{
    public MovingBall(StateMachine context) : base(context)
    {
    }

    public override void Enter()
    {
        Debug.Log("Enter Moving!!");
    }

    public override State Stay()
    {
        Debug.Log("I'm Moving!!");

        _context.transform.Translate(Vector3.right * Time.deltaTime);

        if (Input.GetKeyUp(KeyCode.H))
            return _context.GetState("Idle");
        else
            return null;
    }

    public override void Exit()
    {
        Debug.Log("Exit Moving!!");
    }
}
