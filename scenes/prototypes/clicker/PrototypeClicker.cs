using Godot;
using System;

/// <Summary>
/// A cklicker prototype creating stardust
/// </Summary>
public partial class PrototypeClicker : Control
{
	/// Label which displays current stardust amount
	[Export]
	private Label _label;
	
	/// View reference
	[Export]
	private UserInterface userInterface;
	
	/// View reference
	[Export]
	private UserInterface.Views view;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//UpdateLabelText();
		userInterface.navigation_requested += OnNavigationRequest;
		Visible = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		UpdateLabelText();
	}
	
	/// Callback function for creating stardust
	private void _on_btn_pressed_create_stardust()
	{
		CreateStardust();
		//UpdateLabelText();
	}
	
	/// Creates stardust
	private void CreateStardust(){
		Game.Instance.Data.AddStardust(1);
	}
	
	/// Updates stardust label with current stardust ammount
	private void UpdateLabelText(){
		_label.Text = "Stardust : " + Game.Instance.Data.Stardust;
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





