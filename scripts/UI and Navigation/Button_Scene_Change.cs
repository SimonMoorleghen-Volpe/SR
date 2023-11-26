using Godot;
using System;

public partial class Button_Scene_Change : Button
{
    public override void _Ready()
    {
		Pressed += ChangeScene;
    }

	private void ChangeScene(){
		foreach(Node child in GetTree().Root.GetChildren()){
			if(child.HasMeta("GameManager")){
				((GameManager)child).ChangeScene(TargetScene);
				return;
			}
		}
	}

	[Export(PropertyHint.File)]
	public string TargetScene = null;


}
