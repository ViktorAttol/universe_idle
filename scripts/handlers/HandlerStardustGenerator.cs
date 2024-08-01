using Godot;
using System;

/// <Summary>
/// Passively generates stardust.
/// </Summary>
public partial class HandlerStardustGenerator : Node
{
	private static HandlerStardustGenerator _instance;

	/// 
	private int generatorPower = 1;

	/// Reference to the generator timer
	[Export]
	private Timer timer;
	
	private HandlerStardustGenerator(){
		
	}
	
	public static HandlerStardustGenerator Instance{
		get{
			
			if(_instance == null) _instance = new HandlerStardustGenerator();
			return _instance;
		}
	}
	
	public override void _EnterTree(){
		if(_instance == null) _instance = new HandlerStardustGenerator();
	}	
	public override void _Ready(){
		CalculateGeneratorPower();
		
		HandlerCCUpgrades.Instance.CCUpgradeLeveledUp += WatchForUpgradesLevelUp;
		
		if(Game.Instance.Data.CCUpgrades.U01StardustGeneration){
			timer.Start();
			return;
		}

		HandlerCCUpgrades.Instance.U01StardustGeneration.UpgradeLevelUp += WatchForCCU01LevelUp;		
	}
	
	private void _OnTimerTimeout()
	{
		HandlerStardust.Instance.CreateStardust(generatorPower);
	}
	
	/// Callback function to recalculate generatorPower when there is an ccupgrade.
	private void WatchForUpgradesLevelUp(Upgrade upgrade){
		if(upgrade.GetType() == typeof(CCU01StardustGenerator)){
			OnUpgrade01StardustGeneration();
			return;
		}
		if(upgrade.GetType() == typeof(CC02StardustBoost)){
			OnUpgrade02StardustBoost();
			return;
		}
	}
	
	private void OnUpgrade01StardustGeneration(){
		GD.Print("stardust generation timer started");
		timer.Start();
	}
	
	private void OnUpgrade02StardustBoost(){
		GD.Print("calculate power");
		CalculateGeneratorPower();
	}
	/// Callback function for consciousness core upgrades.
	private void WatchForCCU01LevelUp(){
		GD.Print("stardust generation timer started");
		timer.Start();
		HandlerCCUpgrades.Instance.U01StardustGeneration.UpgradeLevelUp -= WatchForCCU01LevelUp;
	}
	/// Calculate the amount of stardust which should be created every seconds.
	private void CalculateGeneratorPower(){
		int newPower = 1;
		newPower += Game.Instance.Data.CCUpgrades.U02StardustBoostLevel;
		generatorPower = newPower;
	}
}



