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

        int i = Body.Check_Walls();
        if((i == 0 & Input.IsActionPressed("move_left")) | (i == 1 & Input.IsActionPressed("move_right"))){
            return "wall slide";
        }

        Vector2 change = FallVector * (float)delta;
        if(Body.Velocity.Y + change.Y > MaxFallSpeed){
            change.Y = Math.Clamp(MaxFallSpeed - Body.Velocity.Y, 0, FallAcceleration);
        }
        
        if(Input.IsActionPressed("move_right")){
            change.X += DriftAcceleration * (float)delta;
            if(Help.CheckSign(Body.Velocity.X, change.X) & Body.Velocity.X + change.X >= MaxDriftSpeed){
                change.X = Math.Clamp((MaxDriftSpeed - Body.Velocity.X) * (float)delta, 0, DriftAcceleration);
            }
        }   else if(Input.IsActionPressed("move_left")){
            change.X -=  DriftAcceleration * (float)delta;
            if(Help.CheckSign(Body.Velocity.X, change.X) & Math.Abs(Body.Velocity.X + change.X) >= MaxDriftSpeed){
                change.X = Math.Clamp((-MaxDriftSpeed - Body.Velocity.X) * (float)delta, -DriftAcceleration, 0);
            }
        }

        Body.Velocity += change;

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
    private Vector2 FallVector = new(x:0, y:0);
}
