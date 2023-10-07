using Godot;
using System;

public partial class Player_Wall_Jump : Player_Jump
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		JumpVector.X += WallJumpX;
	}

    public override void Enter()
    {
        JumpTimer.Start();
        Body.Velocity *= Vector2.Right;
		if(Input.IsActionPressed("move_left")){
			Body.Velocity += JumpVector;
			return;
		}
        Body.Velocity += JumpVector * new Vector2(-1, 1);
    }

	public override string Take_Input(InputEvent @event)
    {
        return null;
    }

    public override void Exit()
    {
        if(Body.Velocity.Y == JumpVector.Y){
            Body.Velocity -= 0.6f * JumpVector * Vector2.Down;
        }
        
    }

    [Export]
	private float WallJumpX = 300;

}
