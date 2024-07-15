using Godot;
using System;

/// <Summary>
/// A abstract class defining a the basis of a view.
/// </Summary>
public abstract partial class View : Control
{
	/// View reference
	[Export]
	private UserInterface userInterface;
	/// View reference
	[Export]
	private UserInterface.Views view;
	
	// Connects to the navigation request events.
	public override void _Ready()
	{
		userInterface.navigation_requested += OnNavigationRequest;
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
