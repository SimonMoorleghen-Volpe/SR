using Godot;
using System;
using System.Collections;


public partial class Player : CharacterBody2D
{
	
	public override void _Ready()
	{
		Godot.Collections.Array<Node> childList = GetChildren();
		foreach(Node child in childList){
			if(child.HasMeta("brain")){
				Controller = (State_Machine)child;
			}
		}
		if(Controller == null){
			QueueFree();
		}
	}

	
	public override void _Process(double delta)
	{
	}

	public float WalkSpeed {get; private set;} = 0f;
	public float RunSpeed {get; private set;} = 0f;
	public float JumpVelocity {get; private set;} = 0f;
	public float JumpGravity {get; private set;}  = 0f;
	public float FallGravity {get; private set;} = 0f;
	private State_Machine Controller;

	

}
