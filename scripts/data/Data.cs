using Godot;
using System;

public partial class Data : Resource
{
	[Export]
	public int _stardust = 0;
	
	public int Stardust {
		get {
			return _stardust;	
		}
	}
	
	public void AddStardust(int amount){
		_stardust += amount;
	}
}
