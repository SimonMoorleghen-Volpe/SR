using Godot;
using System;

public partial class Player_Idle : PlayerState
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
	}



    public override string Operate(double delta)
    {
		if(!Body.Check_Ground()){ return "fall";}
		if(Input.IsActionPressed("move_left") | Input.IsActionPressed("move_right")){ return "walk"; }
        return null;
    }

    public override string Take_Input(InputEvent @event)
    {
		if(@event.IsActionPressed("move_up")){
			return "jump";
		}
		return null;
    }

}
