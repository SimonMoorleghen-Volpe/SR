using Godot;
using System;

public partial class Level_Section : Node2D
{
	
	public override void _Ready()
	{
		foreach(Node2D child in GetChildren()){
			if(child.HasMeta("connect")){
				EndPoint = child.GlobalPosition;
			}
		}
		if(EndPoint.IsZeroApprox()){
			TileMap tile = (TileMap)FindChild("tilemap");
			Rect2I rect = tile.GetUsedRect();
			EndPoint = new(x:rect.End.X, 0);
		}
	}

	[Export]
	public float BaseScore {get; private set;} = 100;
	[Export]
	public float BaseTime {get; private set;} = 5;
	public Vector2 EndPoint = Vector2.Zero;
}
