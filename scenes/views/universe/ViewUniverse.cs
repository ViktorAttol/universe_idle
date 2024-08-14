using Godot;
using System;

/// <Summary>
/// Main view of the game displaying universe related information.
/// </Summary>
public partial class ViewUniverse : View
{
	/// Text to display on launch on a new game.
	[Export]
	private Label introText;
	
	/// Maint content to display once tha player has created the universe.
	[Export]
	private MarginContainer mainContent;
	
	public override void _Ready()
	{
		base._Ready();
		Visible = false;
		InitializeView();
	}
	
	/// Displays the relevant content based on CCU01 purchase status.
	private void InitializeView(){
		if(!Game.Instance.Data.CCUpgrades.U01StardustGeneration){
			introText.Visible = true;
			mainContent.Visible = false;
			
			HandlerCCUpgrades.Instance.U01StardustGeneration.UpgradeLevelUp += OnCCU01LevelUp;
		}
		else {
			introText.Visible = false;
			mainContent.Visible = true;
		}
	}
	
	/// Wait for CCU01 to be bought. Displays the main content and hides the introText.
	private void OnCCU01LevelUp(){
		introText.Visible = false;
		mainContent.Visible = true;
		
		HandlerCCUpgrades.Instance.U01StardustGeneration.UpgradeLevelUp -= OnCCU01LevelUp;
	}
}
