using Godot;
using System;

/// Sets visibility of the nebulas button link.
public partial class NebulasLinkButton : LinkButton
{
	/// Checks if player has unlocked nebulas.
	public override void _Ready(){
		if(Game.Instance.Data.CCUpgrades.U03UnlockNebulas){
			Visible = true;
			return;
		}
		Visible = false;
		HandlerCCUpgrades.Instance.U03UnlockNebulas.UpgradeLevelUp += OnCCU03LevelUp;
		
	}
	
	/// Triggered when CCU03 levels up.
	/// Mages the link visible.
	private void OnCCU03LevelUp(){
		Visible = true;
		HandlerCCUpgrades.Instance.U03UnlockNebulas.UpgradeLevelUp -= OnCCU03LevelUp;
	}
}
