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
            return "idle";
        }

        Body.Velocity += FallVector * (float)delta;
        if(Body.Velocity.Y > MaxFallSpeed){
            Body.Velocity = new Vector2(Body.Velocity.X, MaxFallSpeed);
        }
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
