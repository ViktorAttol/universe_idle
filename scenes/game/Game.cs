using Godot;
using System;

/// <Summary>
/// Main node of the game.
/// </Summary>
public partial class Game : Node
{
	/// singletion reference
	private static Game _instance;
	
	/// Contains data to save and load
	private Data _data;
	
	private Game(){
		_data = new Data();
	}
	
	public static Game Instance {
		get {
			return _instance;
		}
	}
	
	public Data Data {
		get {
			return _instance._data;
		}
	}
	
	public override void _EnterTree(){
		if(_instance == null) _instance = new Game();
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
