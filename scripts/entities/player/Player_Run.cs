using Godot;
using System;

public partial class Player_Run : PlayerState
{


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
		} else {
			Change += Body.Velocity.Normalized() * IdleDeceleration * (float)delta * -1;
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

    [Export]
    private float RunAcceleration = 200;
    [Export]
    private float RunSpeedMax = 600;
    [Export]
	private float IdleDeceleration = 800;


}
