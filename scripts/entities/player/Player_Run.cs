using Godot;
using System;

public partial class Player_Run : PlayerState
{

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
			Change += Vector2.Left * RunAcceleration * (float)delta;
			float sum = MathF.Abs((Body.Velocity + Change).X);
			if(sum >= RunSpeedMax){
				Change = (sum - RunSpeedMax) * Vector2.Left * (float)delta;
			}
		} else if(Input.IsActionPressed("move_right")){
			Change += Vector2.Right * RunAcceleration * (float)delta;
			float sum = (Body.Velocity + Change).X;
			if(sum >= RunSpeedMax){
				Change = (sum - RunSpeedMax) * Vector2.Right * (float)delta;
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
        if(!Input.IsActionPressed("run")){
            return "walk";
        }
		
		return null;
    }

    public override void Enter()
    {
		float d = 0.02f;
		Vector2 Change = Vector2.Zero;
        if(Input.IsActionPressed("move_left")){
			Change += Vector2.Left * RunAcceleration * d;
			float sum = MathF.Abs((Body.Velocity + Change).X);
			if(sum >= RunSpeedMax){
				Change = (sum - RunSpeedMax) * Vector2.Left * d;
			}
		} else if(Input.IsActionPressed("move_right")){
			Change += Vector2.Right * RunAcceleration * d;
			float sum = (Body.Velocity + Change).X;
			if(sum >= RunSpeedMax){
				Change = (sum - RunSpeedMax) * Vector2.Right * d;
			}
		}
		Body.Velocity += Change;
    }
    [Export]
    private float RunAcceleration = 200;
    [Export]
    private float RunSpeedMax = 600;
    [Export]
	private float IdleDeceleration = 800;


}
