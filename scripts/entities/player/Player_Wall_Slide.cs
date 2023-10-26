using Godot;
using System;

public partial class Player_Wall_Slide : PlayerState
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		SlideAccelVector = new(x:0, y:WallSlideAccel);
		SlideMaxVector = new(x:0, y:WallSlideSpeedMax);
	}

    public override void Enter()
    {
		Body.Velocity = Vector2.Zero;
    }

	    public override string Take_Input(InputEvent @event)
    {
        if(@event.IsActionPressed("move_up")){
            return "wall jump";
        }
        return null;
    }

    public override string Operate(double delta)
    {

		Body.Velocity += SlideAccelVector * (float)delta;

		Body.Velocity = Body.Velocity.Clamp(Vector2.Zero, SlideMaxVector);

		if(Body.Check_Ground()){
			return "idle";
		}
        return null;
    }

    [Export]
	private float WallSlideAccel = 75;
	[Export]
	private float WallSlideSpeedMax = 300;
	private Vector2 SlideAccelVector;
	private Vector2 SlideMaxVector;

}
