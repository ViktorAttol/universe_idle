using Godot;
using System;

public partial class Data : Resource
{
	/// Values have to be Export to save and load properly with Resource system.
	[Export]
	private int _stardust = 0;
	[Export]
	private int _up01Level = 0;
	
	
	public int Up01Level {
		get {
			return _up01Level;
		}
		set{
			_up01Level = value;
		}
	}
	
	public int Stardust {
		get {
			return _stardust;	
		}
	}
	
	public void AddStardust(int amount){
		_stardust += amount;
	}
	
	public void SubtractStardust(int amount){
		_stardust -= amount;
	}
}
