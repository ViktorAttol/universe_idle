using Godot;
using System;

/// <Summary>
/// Displays the upgrades for Consciousness Cores.
/// </Summary>
public partial class ViewConsciousnessCore : View
{
	[Export]
	private Control ccuArea;
	
	[Export]
	private PackedScene compoUpgradeScene;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		Visible = false;
		InitializeUpgrades();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void InitializeUpgrades(){
		Upgrade[] upgrades = HandlerCCUpgrades.Instance.GetAllUpgrades();
		foreach(Upgrade upgrade in upgrades){
			CompoUpgrade upgradeNode = compoUpgradeScene.Instantiate() as CompoUpgrade;
			
			upgradeNode.SetUpgrade(upgrade);
			ccuArea.AddChild(upgradeNode);
		}
	}
}
