using Godot;
using System;
using HelperFuncs;

public partial class Player_Fall : PlayerState
{

    public override void _Ready()
    {
        base._Ready();
        FallVector.Y = FallAcceleration;
    }

    public override void init()
    {
        Body.Set("FallGravity", FallAcceleration);
    }

    public override string Take_Input(InputEvent @event)
    {
        if(@event.IsActionPressed("move_up")){
            int i = Body.Check_Walls();
            if((i == 0 & Input.IsActionPressed("move_left")) | (i == 1 & Input.IsActionPressed("move_right"))){
                return "wall jump";
            }
        }
        return null;
    }

    public override string Operate(double delta)
    {
        if(Body.Check_Ground()){
            if(Input.IsActionPressed("run")){
                return "run";
            }
            if(Body.Velocity.X != 0){
                return "walk";
            }
            return "idle";
        }

        Vector2 change = FallVector;
        if(Body.Velocity.Y + change.Y > MaxFallSpeed){
            change.Y = MaxFallSpeed - Body.Velocity.Y;
        }
        
        if(Input.IsActionPressed("move_right")){
            change += Vector2.Right * DriftAcceleration;
            if(Help.CheckSign(Body.Velocity.X, change.X) & Body.Velocity.X + change.X >= MaxDriftSpeed){
                change.X = MaxDriftSpeed - Body.Velocity.X;
            }
        }   else if(Input.IsActionPressed("move_left")){
            change += Vector2.Left * DriftAcceleration;
            if(Help.CheckSign(Body.Velocity.X, change.X) & Math.Abs(Body.Velocity.X + change.X) >= MaxDriftSpeed){
                change.X = -MaxDriftSpeed - Body.Velocity.X;
            }
        }

        Body.Velocity += change * (float)delta;

        return null;
    }

    [Export]
    private float FallAcceleration = 250;
    [Export]
    private float MaxFallSpeed = 500;
    [Export]
    private float MaxDriftSpeed = 150;
    [Export]
    private float DriftAcceleration = 50;
    private Vector2 FallVector = new();
}
