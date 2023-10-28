using Godot;
using System;

public partial class Player_Walk : PlayerState
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
	}

    public override void Enter(){
		float d = 0.02f;
		Vector2 Change = Vector2.Zero;
        if(Input.IsActionPressed("move_left")){
			Change += Vector2.Left * WalkAcceleration * d;
			float sum = MathF.Abs((Body.Velocity + Change).X);
			if(sum >= WalkSpeedMax){
				Change = (sum - WalkSpeedMax) * Vector2.Left * d;
			}
		} else if(Input.IsActionPressed("move_right")){
			Change += Vector2.Right * WalkAcceleration * d;
			float sum = (Body.Velocity + Change).X;
			if(sum >= WalkSpeedMax){
				Change = (sum - WalkSpeedMax) * Vector2.Right * d;
			}
		}
		Body.Velocity += Change;
	}

    public override string Take_Input(InputEvent @event)
    {
		if(@event.IsActionPressed("move_up")){
			return "jump";
		}
		return null;
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
				if(Input.IsActionPressed("run")){
					return "run";
				}
			}
		} else if(Input.IsActionPressed("move_right")){
			Change += Vector2.Right * WalkAcceleration * (float)delta;
			float sum = (Body.Velocity + Change).X;
			if(sum >= WalkSpeedMax){
				Change = (sum - WalkSpeedMax) * Vector2.Right * (float)delta;
				if(Input.IsActionPressed("run")){
					return "run";
				}
			}
		}

		if(Math.Sign(Change.X) != Math.Sign(Body.Velocity.X) | Change.X == 0){
			Change.X += -Math.Sign(Body.Velocity.X) * IdleDeceleration * (float)delta;
			if(Math.Abs(Change.X) > Math.Abs(Body.Velocity.X)){
				Change.X = -Body.Velocity.X;
				Body.Velocity += Change;
				return "idle";
			}
		}

		Body.Velocity += Change;
		
		return null;
    }


    [Export]
	private float WalkAcceleration = 500;
	[Export]
	private float WalkSpeedMax = 500;
	[Export]
	private float IdleDeceleration = 800;


}
