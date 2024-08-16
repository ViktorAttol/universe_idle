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
		UpdateComponent();
		
		MountUpgrade();
		//upgrade.Upgrade01LevelUp += UpdateLabelTitle;
		//upgrade.Upgrade01LevelUp += UpdateLabelDescription;
		//upgrade.Upgrade01LevelUp += UpdateButton;
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public override void _ExitTree(){
		UnmountUpgrade();
	}
	
	/// Updates every ui part of the component.
	private void UpdateComponent(){
		UpdateLabelTitle();
		UpdateLabelDescription();
		UpdateButton();	
	}
	
	/// Sets ne upgrade.
	public void SetUpgrade(Upgrade newUpgrade){
		upgrade = newUpgrade;
		UnmountUpgrade();
		MountUpgrade();
		UpdateComponent();
	}
	
	/// mounts current upgrade.
	private void MountUpgrade(){
		HandlerStardust.Instance.StardustCreated += UpdateButton;
		HandlerStardust.Instance.StardustConsumed += UpdateButton;
		
		upgrade.UpgradeLevelUp += UpdateLabelTitle;
		upgrade.UpgradeLevelUp += UpdateLabelDescription;
		upgrade.UpgradeLevelUp += UpdateButton;
	}
		
	/// Unmounts current upgrade.
	public void UnmountUpgrade(){
		HandlerStardust.Instance.StardustCreated -= UpdateButton;
		HandlerStardust.Instance.StardustConsumed -= UpdateButton;
		
		upgrade.UpgradeLevelUp -= UpdateLabelTitle;
		upgrade.UpgradeLevelUp -= UpdateLabelDescription;
		upgrade.UpgradeLevelUp -= UpdateButton;
	}
	
	/// Updates the title of the upgrade.
	public void UpdateLabelTitle(){
		labelTitle.Text = upgrade.GetTitle();
	}
	
	public void UpdateLabelDescription(){
		labelDescription.Text = upgrade.GetDescription();
	}
	
	/// Updates the button availability.
	public void UpdateButton(int amount = -1){
		UpdateButton();
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



