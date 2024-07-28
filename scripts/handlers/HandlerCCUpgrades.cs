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

	private CCU01StardustGenerator _u01StardustGeneration;
	private CC02StardustBoost _u02StardustBoost;
	
	public CCU01StardustGenerator U01StardustGeneration{
		get{
			return _u01StardustGeneration;
		}
	}
	
	public CC02StardustBoost U02StardustBoost{
		get{
			return _u02StardustBoost;
		}
	}

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
	
	public override void _Ready(){
		if(_u01StardustGeneration == null) _u01StardustGeneration = new CCU01StardustGenerator();
		if(_u02StardustBoost == null) _u02StardustBoost = new CC02StardustBoost();
	}
	
	public void OnCCUpgradeLevelUp(Upgrade upgrade){
		EmitSignal(SignalName.CCUpgradeLeveledUp, upgrade);
	}
	
	/// Returns all CCUpgrades
	public Upgrade[] GetAllUpgrades(){
		if(_u01StardustGeneration == null) _u01StardustGeneration = new CCU01StardustGenerator();	
		return new Upgrade[] {_u01StardustGeneration, _u02StardustBoost};
	}
}
