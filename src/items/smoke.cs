datablock ParticleData(cigsmokeParticle)
{
   textureName          = "base/data/particles/cloud";
   dragCoefficient      = 0.0;
   windCoefficient      = 0.0;
   gravityCoefficient   = -0.15; 
   inheritedVelFactor   = 0.2;
   lifetimeMS           = 3000;
   lifetimeVarianceMS   = 0;
   useInvAlpha = true;
   spinRandomMin = 0.0;
   spinRandomMax = 0.0;

   colors[0]     = "1 1 1 0.8";
   colors[1]     = "1 1 1 0.8";
   colors[1]     = "1 1 1 0.0";

   sizes[0]      = 0.1;
   sizes[1]      = 0.05;
   sizes[1]      = 0.05;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[1]      = 1.0;
};

datablock ParticleEmitterData(cigsmokeEmitter)
{
   ejectionPeriodMS = 50;
   periodVarianceMS = 5;

   ejectionOffset = 0;
   ejectionOffsetVariance = 0.01;
	
   ejectionVelocity = 0.0;
   velocityVariance = 0.05;

   thetaMin         = 0.0;
   thetaMax         = 10.0;  

   phiReferenceVel  = 0;
   phiVariance      = 360;

   particles = cigsmokeParticle;   
   useEmitterColors = true;
	uiName = "Cigarette smoke";
};

datablock ShapeBaseImageData(cigsmokeImage)
{
   shapeFile = "base/data/shapes/empty.dts";
	emap = false;

	mountPoint = 1;
    rotation = "0 0 0 0";

	stateName[0]					= "Ready";
	stateTransitionOnTimeout[0]		= "FireA";
	stateTimeoutValue[0]			= 0.01;

	stateName[1]					= "FireA";
	stateTransitionOnTimeout[1]		= "Done";
	stateWaitForTimeout[1]			= True;
	stateTimeoutValue[1]			= 10000;
	stateEmitter[1]					= cigsmokeEmitter;
	stateEmitterTime[1]				= 10000;

	stateName[2]					= "Done";
	stateScript[2]					= "onDone";
};

datablock ItemData(ViceSmokeItem : HammerItem) {
	shapeFile = $Despair::Path @ "res/shapes/smoke.dts";
	uiName = "Cigarette";

	doColorShift = false;

	botDatablock = ViceItemsArmor;

	iconName = "";
	image = ViceSmokeImage;
};

datablock ShapeBaseImageData(ViceSmokeImage) {
	shapeFile = "base/data/shapes/empty.dts";
	emap = true;

	// Specify mount point & offset for 3rd person, and eye offset
	// for first person rendering.
	mountPoint = 0;
	eyeOffset = 0; //"0.7 1.2 -0.5";

	className = "WeaponImage";
	item = ViceSmokeItem;

	botDatablock = ViceItemsArmor;

	armReady = true;

	doColorShift = false;

	stateName[0]						= "Activate";
	stateScript[0]						= "onActivate";
	stateTimeoutValue[0]				= 0.5;
	stateTransitionOnTimeout[0]			= "Ready";

	stateName[1]						= "Ready";
	stateTransitionOnTriggerDown[1]		= "Fire";
	stateScript[1]						= "onReady";
	stateAllowImageChange[1]			= true;

	stateName[2]						= "Fire";
	stateTransitionOnTriggerUp[2]		= "Ready";
	stateTimeoutValue[2]				= 0.34;
	stateWaitForTimeout[2]				= true;
	stateAllowImageChange[2]			= true;
	stateScript[2]						= "onFire";
};

function ViceSmokeImage::onMount(%this, %obj, %slot) {
	equipViceHands(%obj, %this.botDatablock);
	%obj.ViceItemBot.playThread(0, smoke_root);
	%obj.isSmoking = 0;
}

function ViceSmokeImage::onUnmount(%this, %obj, %slot) {
	%obj.ViceItemBot.delete();
	%obj.emptyBot.delete();
	%obj.client.applyBodyParts();
	%obj.client.applyBodyColors();
}

function ViceSmokeImage::onFire(%this, %obj, %slot) {
	if ($Sim::Time - %obj.lastSmoke < 120) //can only eat every 2 mins
    {
        if(isObject(%obj.client))
            %obj.client.chatMessage("\c5You don't feel like smoking at the moment.");
        return;
    }
	 
	if (isObject(%obj.ViceItemBot)) {
		%obj.ViceItemBot.playThread(0, smoke_start);
		$deleteSchedule = schedule(6000, 0, "deleteSmoke", %this, %obj, %slot); 
	}
	$smokeSchedule = schedule(6000, 0, "ViceSmokeMood", %obj);
	schedule(300, 0, "ViceSmokeSetSmoke", %obj);
	%obj.isSmoking = 1;
}

function ViceSmokeMood(%obj)
{
	%slot = $SE_passiveSlot;
	%effect = "hankering";
	if(%obj.character.trait["Chain Smoker"])
	{
	%obj.removeStatusEffect(%slot, %effect);
	%obj.lastSmoke = $Sim::Time;
	%obj.addMood(3, "Never gets old.");
	}
	else
	%obj.addMood(6, "Nice and smooth...");
	%obj.lastSmoke = $Sim::Time;
}

function ViceSmokeSetSmoke(%obj) {
	%obj.ViceItemBot.mountImage(cigsmokeImage, 1);
	%obj.ViceItemBot.hidenode(cigtop_off);
	%obj.ViceItemBot.unhidenode(cigtop_on);
}

function deleteSmoke(%this, %obj, %slot) {
	for(%i=0;%i<5;%i++)
	{
		%toolDB = %obj.tool[%i];
		if(%toolDB $= %this.item.getID())
		{
			%obj.tool[%i] = 0;
			%obj.weaponCount--;
			messageClient(%obj.client, 'MsgItemPickup', '',%i, 0);
			serverCmdUnUseTool(%obj.client);
			break;
		}
	}
}

function ViceSmokeImage::onReady(%this, %obj, %slot) {
	if (isObject(%obj.ViceItemBot)) {
		if (%obj.isSmoking) {
			%obj.ViceItemBot.playThread(0, smoke_end);
		} else {
			%obj.ViceItemBot.playThread(0, smoke_root);
		}
	}
	cancel($smokeSchedule);
	cancel($deleteSchedule);
	%obj.ViceItemBot.unMountImage(1);
	%obj.ViceItemBot.unhidenode(cigtop_off);
	%obj.ViceItemBot.hidenode(cigtop_on);
	%obj.isSmoking = 0;
}



