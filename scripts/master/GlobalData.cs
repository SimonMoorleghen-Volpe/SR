using Godot;
using System;

[GlobalClass]
public partial class GlobalData : Node
{
	public int seed = new Random(Guid.NewGuid().GetHashCode()).Next();


	public int GetSeed(){
		return seed;
	}
}
