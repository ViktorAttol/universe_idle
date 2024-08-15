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
	
	/// Node managing stardust milestones, creatin consciousness core;
	private StardustMilestones _stardustMilestones = new StardustMilestones();
	
	private HandlerConsciousnessCore(){
		GD.Print("ConsciousnessCore handler created");
		_instance = this;
	}
	
	public static HandlerConsciousnessCore Instance{
		get{
			return _instance;
		}
	}
	
	public StardustMilestones StardustMilestone{
		get{
			return _stardustMilestones;
		}
	}
	
	public override void _EnterTree(){
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
	public void CreateConsciousnessCores(int amount){
		Game.Instance.Data.AddConsciousnessCores(amount);
		Game.Instance.Data.Universe.AddConsciousnessCores(amount);
		OnConsciousnessCoresCreated(amount);
	}
	
	/// Consumes amount of ConsciousneddCores.
	public bool ConsumeConsciousnessCores(int amount){
		if(amount > Game.Instance.Data.ConsciousnessCore) return false;
		Game.Instance.Data.SubtractConsciousnessCores(amount);
		OnConsciousnessCoresConsumed(amount);
		return true;
	}
}
