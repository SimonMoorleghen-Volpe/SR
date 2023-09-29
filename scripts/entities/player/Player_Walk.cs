using Godot;
using System;

public partial class Player_Walk : PlayerState
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
	}

    public override void Enter()
    {
		GD.Print("walk");
    }

    public override string Operate(double delta)
    {
		if(!Body.Check_Ground()){
			return "fall";
		}
		Vector2 Change = Vector2.Zero;
        if(Input.IsActionPressed("move_left")){
			Change += Vector2.Left * WalkAcceleration * (float)delta;
			float sum = MathF.Abs((Body.Velocity + Change).X);
			if(sum >= WalkSpeedMax){
				Change = (sum - WalkSpeedMax) * Vector2.Left * (float)delta;
			}
		} else if(Input.IsActionPressed("move_right")){
			Change += Vector2.Right * WalkAcceleration * (float)delta;
			float sum = (Body.Velocity + Change).X;
			if(sum >= WalkSpeedMax){
				Change = (sum - WalkSpeedMax) * Vector2.Right * (float)delta;
			}
		} else {
			Change += Body.Velocity.Normalized() * IdleDeceleration * (float)delta * -1;
			if(Math.Abs(Change.X) > Math.Abs(Body.Velocity.X)){
				Change.X = -Body.Velocity.X;
				Body.Velocity += Change;
				return "idle";
			}
			
		}
		Body.Velocity += Change;
		if(Input.IsActionPressed("run")){
			return "run";
		}
		
		return null;
    }


    [Export]
	private float WalkAcceleration = 500;
	[Export]
	private float WalkSpeedMax = 500;
	[Export]
	private float IdleDeceleration = 800;


}
