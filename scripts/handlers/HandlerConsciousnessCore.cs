using Godot;
using System;

/// <Summary>
/// Manages consciousness cores and related signals.
/// </Summary>
public partial class HandlerConsciousnessCore : Node
{
	private static HandlerConsciousnessCore _instance;
	
	/// Emitted when consciousness core is created.
	[Signal]
	public delegate void ConsciousnessCoreCreatedEventHandler(int amount);
	
	/// Emitted when consciousness core is consumed.
	[Signal]
	public delegate void ConsciousnessCoreConsumedEventHandler(int amount);
	
	private HandlerConsciousnessCore(){
		
	}
	
	public static HandlerConsciousnessCore Instance{
		get{
			if(_instance == null) _instance = new HandlerConsciousnessCore();
			return _instance;
		}
	}
	
	public override void _EnterTree(){
		if(_instance == null) _instance = new HandlerConsciousnessCore();
	}
	
	private void OnConsciousnessCoresCreated(int amount)
	{
		EmitSignal(SignalName.ConsciousnessCoreCreated, amount);
	}
	
	private void OnConsciousnessCoresConsumed(int amount)
	{
		EmitSignal(SignalName.ConsciousnessCoreConsumed, amount);
	}
	
	/// Returns the current amount of ConsciousneddCores available.
	public int ConsciousneddCoresAvailable(){
		return Game.Instance.Data.ConsciousnessCore;
	}
	
	/// Creates amount of ConsciousneddCores.
	public void CreateConsciousneddCores(int amount){
		Game.Instance.Data.AddConsciousnessCores(amount);
		OnConsciousnessCoresCreated(amount);
	}
	
	/// Consumes amount of ConsciousneddCores.
	public bool ConsumeConsciousneddCores(int amount){
		if(amount > Game.Instance.Data.ConsciousnessCore) return false;
		Game.Instance.Data.SubtractConsciousnessCores(amount);
		OnConsciousnessCoresConsumed(amount);
		return true;
	}
}
