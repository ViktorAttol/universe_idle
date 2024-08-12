using Godot;
using System;

/// <Summary>
/// Manages stardust and related signals.
/// </Summary>
public partial class HandlerStardust : Node
{
	private static HandlerStardust _instance;
	
	private HandlerStardust(){
		GD.Print("HandlerStardust created");
		_instance = this;
	}
	
	public static HandlerStardust Instance{
		get{
			if(_instance == null) _instance = new HandlerStardust();
			return _instance;
		} 
		private set {}
	}
	
	public override void _EnterTree(){
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	/// Emitted when stardust is created.
	[Signal]
	public delegate void StardustCreatedEventHandler(int amount);
		
	private void OnStardustCreated(int amount)
	{
		EmitSignal(SignalName.StardustCreated, amount);
	}
	
	/// Emitted when stardust is consumed.
	[Signal]
	public delegate void StardustConsumedEventHandler(int amount);
		
	private void OnStardustConsumed(int amount)
	{
		EmitSignal(SignalName.StardustConsumed, amount);
	}
	
	/// Returns the current amount of stardust available.
	public int StardustAvailable(){
		return Game.Instance.Data.Stardust;
	}
	
	/// Creates amount of stardust.
	public void CreateStardust(int amount){
		Game.Instance.Data.AddStardust(amount);
		Game.Instance.Data.Universe.AddStardust(amount);
		OnStardustCreated(amount);
	}
	
	/// Consumes amount of stardust.
	public bool ConsumeStardust(int amount){
		if(amount > Game.Instance.Data.Stardust) return false;
		Game.Instance.Data.SubtractStardust(amount);
		OnStardustConsumed(amount);
		return true;
	}
	
	/// Triggered by the Clicker. Creates stardust.
	public void TriggerClicker(){
		int amount = 1;
		amount += Game.Instance.Data.Up01Level;
		
		CreateStardust(amount);
	}
}
