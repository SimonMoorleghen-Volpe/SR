using Godot;
using System;

public partial class PlayerState : Node
{
	[Export]
	public Player_States State_ID = Player_States.none;
	public override void _Ready()
	{
		SetMeta("PlayerState", true);
	}

	public Player_States Operate(double delta){
		return Player_States.none;
	}

}
