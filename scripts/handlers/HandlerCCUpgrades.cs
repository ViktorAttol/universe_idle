using Godot;
using System;

/// <Summary>
/// Manages upgrades for consciousness cores.
/// </Summary>
public partial class HandlerCCUpgrades : Node
{
	private static HandlerCCUpgrades _instance;
	
	/// Emitted when consciousness core is created.
	[Signal]
	public delegate void CCUpgradeLeveledUpEventHandler(Upgrade upgrade);

	private CCU01StardustGenerator = u01StardustGeneration;

	private HandlerCCUpgrades(){
		
	}
	
	public static HandlerCCUpgrades Instance{
		get{
			return _instance;
		}
	}
	
	public override void _EnterTree(){
		if(_instance == null) _instance = new HandlerCCUpgrades();
	}
	
	public void OnCCUpgradeLevelUp(Upgrade upgrade){
		EmitSignal(SignalName.CCUpgradeLeveledUp, upgrade);
	}
}
