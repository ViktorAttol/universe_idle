using Godot;
using System;

/// <Summary>
/// A prototype for upgrades.
/// </Summary>
public partial class PrototypeUpgrades : Control
{
	/// View reference
	[Export]
	private UserInterface userInterface;
	
	/// View reference
	[Export]
	private UserInterface.Views view;
	
	public override void _Ready()
	{
		userInterface.navigation_requested += OnNavigationRequest;
		Visible = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	/// Navigation cb function
	private void OnNavigationRequest(int requestedView){
		if((UserInterface.Views)requestedView == view) {
			Visible = true;
			return;
		}
		Visible = false;
	}
}
