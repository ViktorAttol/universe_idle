using Godot;
using System;

/// <Summary>
/// A generator prototype creating stardust
/// </Summary>
public partial class PrototypeGenerator : Control
{
	/// Amount of stardust
	private int _stardust = 0;
	
	/// Label which shows stardust amount
	[Export]
	private Label _label;
	
	/// Button which starts generation of stardust
	[Export]
	private Button _button;
	
	/// Timer for stardust generation
	[Export]
	private Timer _timer;
	
	/// View reference
	[Export]
	private UserInterface userInterface;
	
	/// View reference
	[Export]
	private UserInterface.Views view;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//UpdateStardustLabel();
		userInterface.navigation_requested += OnNavigationRequest;
		Visible = true;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		UpdateStardustLabel();
	}
	
	/// Creates stardust
	private void CreateStardust(){
		Game.Instance.Data.AddStardust(1);
	}
	
	/// Updates stardust label with current stardust ammount
	private void UpdateStardustLabel(){
		_label.Text = "Stardust : " + Game.Instance.Data.Stardust;
	}
	
	/// Beginnst stardust generation
	private void BeginnGeneratingStardust(){
		_timer.Start();
		_button.Disabled = true;
	}
	
	/// Start generation cb
	private void _on_button_pressed()
	{
		BeginnGeneratingStardust();
	}
	
	/// Timer cb
	private void _on_timer_timeout()
	{
		CreateStardust();
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






