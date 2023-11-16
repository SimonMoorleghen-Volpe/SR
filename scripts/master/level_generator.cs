using Godot;
using System;
using System.Collections.Generic;


public partial class level_generator : Node
{
    public override void _Ready()
    {
		Json LevelsJson = ResourceLoader.Load<Json>("res://resources/LevelLists.tres");
		
		var Levels = LevelsJson.Data;
		Godot.Collections.Dictionary LevelLists = Levels.AsGodotDictionary();
		GD.Print(((Godot.Collections.Array)LevelLists["basic"])[1]);
		
    }

}
