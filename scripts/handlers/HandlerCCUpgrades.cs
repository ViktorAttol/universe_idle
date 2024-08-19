using Godot;
using System;
using System.Collections.Generic; 
/// <Summary>
/// Manages upgrades for consciousness cores.
/// </Summary>
public partial class HandlerCCUpgrades : Node
{
	private static HandlerCCUpgrades _instance;
	
	/// Emitted when consciousness core is created.
	[Signal]
	public delegate void CCUpgradeLeveledUpEventHandler(Upgrade upgrade);
	/// Emmitted when an upgrade is unlocked.
	[Signal]
	public delegate void UpgradeUnlockedEventHandler(Upgrade upgrade);

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
		_instance = this;
		_u01StardustGeneration = new CCU01StardustGenerator();
		_u02StardustBoost = new CCU02StardustBoost();
		_u03UnlockNebulas = new CCU03UnlockNebulas();
		GD.Print("CCUpgrades created");
	}
	
	public static HandlerCCUpgrades Instance{
		get{
			return _instance;
		}
	}
	
	public void OnUpgradeUnlocked(Upgrade upgrade){
		EmitSignal(SignalName.UpgradeUnlocked, upgrade);
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
	
	/// Returns all unlocked Upgrades.
	public Upgrade[] GetAllUnlockedUpgrades(){
		List<Upgrade> upgradeList = new List<Upgrade>();
		foreach(Upgrade upgrade in GetAllUpgrades()){
			if(upgrade.IsUnlocked()) upgradeList.Add(upgrade);
		}
		return upgradeList.ToArray();
	}
}
