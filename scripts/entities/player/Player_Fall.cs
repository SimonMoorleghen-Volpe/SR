using Godot;
using System;
using System.ComponentModel.DataAnnotations;

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

    public override string Operate(double delta)
    {
        if(Body.IsOnFloor()){
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
            if(Body.Velocity.X + change.X >= MaxDriftSpeed){
                change.X = MaxDriftSpeed - Body.Velocity.X;
            }
        }   else if(Input.IsActionPressed("move_left")){
            change += Vector2.Left * DriftAcceleration;
            if(Math.Abs(Body.Velocity.X + change.X) >= MaxDriftSpeed){
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
