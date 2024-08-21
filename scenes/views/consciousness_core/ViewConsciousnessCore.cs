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
		HandlerCCUpgrades.Instance.UpgradeUnlocked += OnUpgradeUnlocked;
	}
	
	private void InitializeUpgrades(){
		Upgrade[] upgrades = HandlerCCUpgrades.Instance.GetAllUnlockedUpgrades();
		foreach(Upgrade upgrade in upgrades){
			CompoUpgrade upgradeNode = compoUpgradeScene.Instantiate() as CompoUpgrade;
			
			upgradeNode.SetUpgrade(upgrade);
			ccuArea.AddChild(upgradeNode);
		}
	}
	
	/// Triggered when an upgrade unlocks. 
	/// Deletes all upgrades nodes and initializes new ones.
	private void OnUpgradeUnlocked(Upgrade upgrade){
		int count = 0;
		foreach(Node child in ccuArea.GetChildren()){
			CompoUpgrade childAsUpgrade = (CompoUpgrade) child;
			//GD.Print("childrencount: " + count + ", with name " + childAsUpgrade.labelTitle.Text);
			count++;
			childAsUpgrade.UnmountUpgrade();
			child.QueueFree();
		}
		InitializeUpgrades();
	}
}
