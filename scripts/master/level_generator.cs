using Godot;
using System;
using System.Collections.Generic;


public partial class level_generator : Node
{
    public override void _Ready()
    {
		Json LevelsJson = ResourceLoader.Load<Json>("res://resources/LevelLists.tres");
		
		GlobalData Global = GetNode<GlobalData>("/root/GlobalData");

		rand = new(Global.GetSeed());
		var Levels = LevelsJson.Data;
		LevelsLists = Levels.AsGodotDictionary();
		Node2D level = new();

		AddChild(level);

		PackedScene LevelScene = ResourceLoader.Load<PackedScene>(Get_Level_Section("start"));
		Level_Section levelsect = (Level_Section)LevelScene.Instantiate();
		level.AddChild(levelsect);
		Vector2 basepoint = levelsect.GetConnection();
		
		LevelScene = ResourceLoader.Load<PackedScene>(Get_Level_Section("basic"));
		levelsect = (Level_Section)LevelScene.Instantiate();
		levelsect.GlobalPosition = basepoint;
		level.AddChild(levelsect);
		basepoint = levelsect.GetConnection();
		rand.Next();
		
    }

	private String Get_Level_Section(String List){
		if(!LevelsLists.ContainsKey(List)){
			List = "basic";
		}
		int len = ((Godot.Collections.Array)LevelsLists[List]).Count;

		String selection = (string)((Godot.Collections.Array)LevelsLists[List])[rand.Next(len)];
		return PathFront + selection + PathEnd;
	}


	private Godot.Collections.Dictionary LevelsLists;
	private Random rand;
	private string PathFront = "res://scenes/levels/";
	private string PathEnd = ".tscn";
}
