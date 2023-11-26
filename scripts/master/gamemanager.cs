using Godot;
using System;

public partial class GameManager : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SetMeta("GameManager", true);
	}

	public void ChangeScene(string TargetScene){

	}

}
