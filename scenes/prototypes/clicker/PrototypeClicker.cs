using Godot;
using System;

/// <Summary>
/// A cklicker prototype creating stardust
/// </Summary>
public partial class PrototypeClicker : Control
{

	/// View reference
	[Export]
	private UserInterface userInterface;
	
	/// View reference
	[Export]
	private UserInterface.Views view;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		userInterface.navigation_requested += OnNavigationRequest;
		Visible = false;
	}
	
	/// Callback function for creating stardust
	private void _on_btn_pressed_create_stardust()
	{
		CreateStardust();
	}
	
	/// Creates stardust
	private void CreateStardust(){
		HandlerStardust.Instance.CreateStardust(1);
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





