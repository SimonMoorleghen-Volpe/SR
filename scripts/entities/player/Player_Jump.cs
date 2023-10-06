using Godot;
using System;

public partial class Player_Jump : PlayerState
{
    public override void _Ready()
    {
        base._Ready();
        JumpVector = new(){X=0, Y=JumpHeight/JumpTime * -1};
        JumpTimer = new(){
            OneShot=true,
            WaitTime=JumpTime
        };
        AddChild(JumpTimer);
    }

    public override string Take_Input(InputEvent @event)
    {
        if(@event.IsActionReleased("move_up")){
            JumpTimer.Stop();
        }
        return null;
    }

    public override void Exit(){
        if(Body.Velocity.Y == JumpVector.Y){
            Body.Velocity -= 0.5f * JumpVector;
        }
        
    }

    public override void Enter()
    {
        JumpTimer.Start();
        Body.Velocity += JumpVector;
    }
    public override string Operate(double delta)
    {
        if(Body.Velocity.Y >= 0 | JumpTimer.TimeLeft == 0){
            return "fall";
        }
        return null;
    }

    [Export]
    private float JumpTime = 0.5f;
    [Export]
    private float JumpHeight = 500;
    private Vector2 JumpVector;
    private Timer JumpTimer;
}
