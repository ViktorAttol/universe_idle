using Godot;
using System;

/// <Summary>
/// Component displaying an upgrade.
/// </Summary>
public partial class CompoUpgrade : Control
{
	[Export]
	public Label labelTitle;
		
	[Export]
	public RichTextLabel labelDescription;
	
	///Reference to purchase button
	[Export]
	public Button button;
	
	/// Upgrade to display.
	private Upgrade upgrade;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(upgrade == null) upgrade = new Up01ClickerUpgrade();
		UpdateLabelTitle();
		UpdateLabelDescription();
		UpdateButton();
		
		
		
		MountUpgrade();
		//upgrade.Upgrade01LevelUp += UpdateLabelTitle;
		//upgrade.Upgrade01LevelUp += UpdateLabelDescription;
		//upgrade.Upgrade01LevelUp += UpdateButton;
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void SetUpgrade(Upgrade newUpgrade){
		upgrade = newUpgrade;
	}
	
	private void UnmountUpgrade(Upgrade upgrade){
		HandlerStardust.Instance.StardustCreated -= UpdateButton;
		HandlerStardust.Instance.StardustConsumed -= UpdateButton;
		
		upgrade.Upgrade01LevelUp -= UpdateLabelTitle;
		upgrade.Upgrade01LevelUp -= UpdateLabelDescription;
		upgrade.Upgrade01LevelUp -= UpdateButton;

	}
	
	private void MountUpgrade(){
	
		HandlerStardust.Instance.StardustCreated += UpdateButton;
		HandlerStardust.Instance.StardustConsumed += UpdateButton;
		
		upgrade.Upgrade01LevelUp += UpdateLabelTitle;
		upgrade.Upgrade01LevelUp += UpdateLabelDescription;
		upgrade.Upgrade01LevelUp += UpdateButton;
	
	}
	
	/// Updates the title of the upgrade.
	public void UpdateLabelTitle(){
		String text = upgrade.GetTitle() + " (" + upgrade.GetLevel() + ")";
		labelTitle.Text = text;
	}
	
	public void UpdateLabelDescription(){
		labelDescription.Text = upgrade.GetDescription();
	}
	
	/// Updates the button availability.
	public void UpdateButton(int amount = -1){
		if(upgrade.CanAfford()){
			button.Disabled = false;
			return;
		}
		button.Disabled = true;
	}
	public void UpdateButton(){
		if(upgrade.CanAfford()){
			button.Disabled = false;
			return;
		}
		button.Disabled = true;
	}
	
	/// Triggered when the purchase button is pressed.
	private void OnPurchaseBtnPressed()
	{
		upgrade.LevelUp();
	}
}



