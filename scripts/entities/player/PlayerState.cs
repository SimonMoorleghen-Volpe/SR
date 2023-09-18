using Godot;
using System;

public partial class PlayerState : Node
{
	[export]
	public Player_States State_ID = Player_States.none;
	public override void _Ready()
	{
		SetMeta("PlayerState", true);
	}


}
