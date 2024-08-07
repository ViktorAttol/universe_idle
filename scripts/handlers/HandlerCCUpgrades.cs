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

	/// References to the upgrades.
	private CCU01StardustGenerator _u01StardustGeneration;
	private CCU02StardustBoost _u02StardustBoost;
	private CCU03UnlockNebulas _u03UnlockNebulas;
	
	/// Properties which gives access to the upgrades.
	public CCU01StardustGenerator U01StardustGeneration{
		get{	return _u01StardustGeneration;	}
	}
	
	public CCU02StardustBoost U02StardustBoost{
		get{	return _u02StardustBoost;	}
	}

	public CCU03UnlockNebulas U03UnlockNebulas{
		get{	return _u03UnlockNebulas;	}
	}
	
	private HandlerCCUpgrades(){
		_u01StardustGeneration = new CCU01StardustGenerator();
		_u02StardustBoost = new CCU02StardustBoost();
		_u03UnlockNebulas = new CCU03UnlockNebulas();
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
		//if(_u02StardustBoost == null) _u02StardustBoost = new CCU02StardustBoost();
	}
	
	public void OnCCUpgradeLevelUp(Upgrade upgrade){
		//GD.Print("OnCCUpgradeLevelUp called for upgrade: " + upgrade.GetTitle());
		EmitSignal(SignalName.CCUpgradeLeveledUp, upgrade);
	}
	
	/// Returns all CCUpgrades
	public Upgrade[] GetAllUpgrades(){
		if(_u01StardustGeneration == null) _u01StardustGeneration = new CCU01StardustGenerator();
		if(_u02StardustBoost == null) _u02StardustBoost = new CCU02StardustBoost();	
		if(_u03UnlockNebulas == null) _u03UnlockNebulas = new CCU03UnlockNebulas();	
		return new Upgrade[] {_u01StardustGeneration, _u02StardustBoost, _u03UnlockNebulas};
	}
}
