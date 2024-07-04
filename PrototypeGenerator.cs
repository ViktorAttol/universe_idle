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
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		UpdateStardustLabel();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	/// Creates 1 stardust
	private void CreateStardust(){
		_stardust += 1;
		UpdateStardustLabel();
	}
	
	/// Updates stardust label to stardust amount
	private void UpdateStardustLabel(){
		_label.Text = "Stardust : " + _stardust;	
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
}






