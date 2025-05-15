datablock ItemData(SmokeItem)
{
	shapeFile = $Despair::Path @ "res/shapes/smoke.dts";
	mass = 1;
	density = 0.4;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	uiName = "Smoke";

	iconName = $Despair::Path @ "res/shapes/food/Icon_Cheeseburger";

	image = SmokeImage;
	canDrop = true;
	
	waitForKiller = false;
};

datablock ShapeBaseImageData(SmokeImage)
{
	shapeFile = $Despair::Path @ "res/shapes/smoke.dts";

	emap = true;
	mountPoint = 0;

	className = "WeaponImage";
	item = SmokeItem;

	armReady = true;

	stateName[0]					= "Activate";
	stateTransitionOnTimeOut[0]		= "Ready";
	stateAllowImageChange[0]		= true;
	stateTimeoutValue[0]			= 0.5;

	stateName[1]					= "Ready";
	stateTransitionOnTriggerDown[1]	= "Fire";
	stateAllowImageChange[1]		= true;

	stateName[2]					= "Fire";
	stateTransitionOnTimeout[2]		= "Ready";
	stateAllowImageChange[2]		= true;
	stateScript[2]					= "onSmoke";
	stateTimeoutValue[2]			= 1;
};

function SmokeImage::onSmoke(%this, %obj, %slot)
{
    
    if ($Sim::Time - %obj.lastSmoke < 5) //can only smoke every 5 mins
    {
        if(isObject(%obj.client))
            %obj.client.chatMessage("\c5You don't feel like smoking at the moment.");
        return;
    }
	if(%obj.character.trait["Glutton"])
	{	
		%obj.health = getMin(%obj.health + 25, %obj.maxHealth);
		%obj.unMountImage(0);
		%obj.removeTool(%obj.currTool);
		%obj.lastSmoke = $Sim::Time;
		serverPlay3d("EatSound", %obj.getEyePoint());
		%obj.addMood(8, "Mmm... Simply exquisite.");
		%obj.health = getMin(%obj.health + 25, %obj.maxHealth);
		return;
	}
	%obj.unMountImage(0);
	%obj.removeTool(%obj.currTool);
    %obj.lastSmoke = $Sim::Time;
	serverPlay3d("EatSound", %obj.getEyePoint());
	%obj.addMood(5, "das sum good shet");
	%obj.health = getMin(%obj.health + 25, %obj.maxHealth);
	
}