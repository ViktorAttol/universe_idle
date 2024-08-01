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
		_u01StardustGeneration = new CCU01StardustGenerator();
		_u02StardustBoost = new CC02StardustBoost();
	}
	
	public static HandlerCCUpgrades Instance{
		get{
			if(_instance == null) _instance = new HandlerCCUpgrades();
			return _instance;
		}
	}
	
	/// Creates 
	public override void _EnterTree(){
		if(_instance == null) _instance = new HandlerCCUpgrades();
	}
	
	/// Sets instances of upgrades if not already set.
	public override void _Ready(){
		if(_instance == null) _instance = new HandlerCCUpgrades();
		//if(_u01StardustGeneration == null) _u01StardustGeneration = new CCU01StardustGenerator();
		//if(_u02StardustBoost == null) _u02StardustBoost = new CC02StardustBoost();
	}
	
	public void OnCCUpgradeLevelUp(Upgrade upgrade){
		GD.Print("OnCCUpgradeLevelUp called for upgrade: " + upgrade.GetTitle());
		EmitSignal(SignalName.CCUpgradeLeveledUp, upgrade);
	}
	
	/// Returns all CCUpgrades
	public Upgrade[] GetAllUpgrades(){
		if(_u01StardustGeneration == null) _u01StardustGeneration = new CCU01StardustGenerator();
		if(_u02StardustBoost == null) _u02StardustBoost = new CC02StardustBoost();	
		return new Upgrade[] {_u01StardustGeneration, _u02StardustBoost};
	}
}
