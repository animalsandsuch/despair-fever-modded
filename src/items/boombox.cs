datablock AudioProfile(boomBoxInsertSound)
{
	fileName =  $Despair::Path @ "res/sounds/tape_insert.wav";
	description = AudioQuiet3d;
	preload = true;
};
datablock AudioProfile(boomBoxRemoveSound)
{
	fileName =  $Despair::Path @ "res/sounds/tape_remove.wav";
	description = AudioQuiet3d;
	preload = true;
};
datablock ItemData(boomboxItem)
{
	category = "Weapon";  // Mission editor category
	className = "Weapon"; // For inventory system

	shapeFile = $Despair::Path @ "res/shapes/items/boombox.dts";
	uiName = "Boombox";
	
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;

	image = boomboxEmptyImage;
	canDrop = true;
};
datablock ShapeBaseImageData(boomboxImage)
{
	className = "WeaponImage";
	shapeFile = $Despair::Path @ "res/shapes/items/boombox.dts";
	emap = true;

	mountPoint = 0;
	offset = "-0.15 -0.67 0.1";
	eyeOffset = "0 0 0";
	rotation = "1 0.4 0.1 90";
	rotation = eulerToMatrix("90 20 180");

	doColorShift = boomboxItem.doColorShift;
	colorShiftColor = boomboxItem.colorShiftColor;
	item = boomboxItem;
	armReady = true;
};
datablock ShapeBaseImageData(boomboxEmptyImage)
{
	className = "WeaponImage";
	shapeFile = $Despair::Path @ "res/shapes/items/boombox_empty.dts";
	emap = true;

	mountPoint = 0;
	offset = "-0.15 -0.67 0.1";
	eyeOffset = "0 0 0";
	rotation = "1 0.4 0.1 90";
	rotation = eulerToMatrix("90 20 180");

	doColorShift = boomboxItem.doColorShift;
	colorShiftColor = boomboxItem.colorShiftColor;
	item = boomboxItem;
	armReady = true;
};
function boomboxImage::onMount(%db,%pl,%slot)
{
	parent::onMount(%db,%pl,%slot);
}
function boomboxEmptyImage::onMount(%db,%pl,%slot)
{
	
	if(%pl.boomBoxMountSwapIgnore)
		return;
	parent::onMount(%db,%pl,%slot);
		if(%player.investigationBoombox $= true)
	{
		%pl.unMountImage(0);
		%pl.removeTool(%pl.currTool);
		%pl.playThread(2,root);
		%pl.unHideNode(%pl.boomboxHandHide);
		if(isObject(%pl.boomBoxMusicBrick))
		{
		%pl.boomBoxMusicBrick.delete();
		%pl.boomBoxMusicBrick = "";
		}
		if(isObject(%cl.boomBoxMusicTmp))
		%cl.boomBoxMusicTmp.delete();
	}
	%pl.playThread(2,spearReady);
	if(%pl.isNodeVisible("rhand"))
		%pl.boomboxHandHide = "rhand";
	else if(%pl.isNodeVisible("rhook"))
		%pl.boomboxHandHide = "rhook";
	else
		%pl.boomboxHandHide = "";
	%pl.hideNode(%pl.boomboxHandHide);
}
function boomboxEmptyImage::onUnMount(%db,%pl,%slot)
{

	if(%pl.boomBoxMountSwapIgnore)
		return;
	%pl.playThread(2,root);
	%pl.unHideNode(%pl.boomboxHandHide);
	if(isObject(%pl.boomBoxMusicBrick))
	{
		%pl.boomBoxMusicBrick.delete();
		%pl.boomBoxMusicBrick = "";
	}
	if(isObject(%cl.boomBoxMusicTmp))
		%cl.boomBoxMusicTmp.delete();
	parent::onUnMount(%db,%pl,%slot);
}
function boomboxImage::onUnMount(%db,%pl,%slot)
{
	if(%pl.boomBoxMountSwapIgnore)
		return;
	%pl.playThread(2,root);
	%pl.unHideNode(%pl.boomboxHandHide);
	if(%pl.boomboxPlaying !$= "")
	{
		%pl.stopAudio(0);
		%pl.boomboxPlaying = "";
	}
	if(isObject(%pl.boomBoxMusicBrick))
	{
		%pl.boomBoxMusicBrick.delete();
		%pl.boomBoxMusicBrick = "";
	}
	if(isObject(%cl.boomBoxMusicTmp))
		%cl.boomBoxMusicTmp.delete();
	parent::onUnMount(%db,%pl,%slot);
}
package swol_boomboxItem
{
	function gameConnection::onClientLeaveGame(%cl)
	{
		if(isObject(%cl.boomBoxMusicTmp))
			%cl.boomBoxMusicTmp.delete();
		return parent::onClientLeaveGame(%cl);
	}
	function Armor::onTrigger(%this,%pl,%trig,%bool)
	{
		
		%pa = parent::onTrigger(%this,%pl,%trig,%bool);
		if(!isObject(%im = %pl.getMountedImage(0)))
			return %pa;
		if(!isObject(%cl = %pl.client))
			return %pa;
		if(%trig != 0)
			return %pa;
		if(!%bool)
			return %pa;
		if(getSimTime()-%pl.lastBoomBoxSelect < 300)
			return %pa;
		%pl.lastBoomBoxSelect = getSimTime();
		if(isObject(%im.item) && %im.item.getName() $= boomboxItem)
		{
			if(isObject(%pl.boomBoxMusicBrick))
			{
				%pl.boomBoxMusicBrick.delete();
				%pl.boomBoxMusicBrick = "";
				if (isObject(%pl.client))
				commandToClient(%pl.client, 'ClearCenterPrint');
			}
			if(isObject(%cl.boomBoxMusicTmp))
				%cl.boomBoxMusicTmp.delete();
			%br = %cl.boomBoxMusicTmp = %pl.boomBoxMusicBrick = new fxDtsBrick()
			{
				client = %cl;
				dataBlock = brickMusicData;
				position = "0 0 -100000";
			};
			echo(%br);
			%cl.wrenchBrick = %br;
			%br.sendWrenchSoundData(%cl);
			commandToClient(%cl,'openWrenchSoundDlg',"Boombox",1);
		}
		return %pa;
	}
	function serverCmdSetWrenchData(%cl,%data)
	{
		if(%player.investigationBoombox $= true)
		{
		 messageClient(%client, '', "\c5It's jammed...");
		 return;
		}
		%pa = parent::serverCmdSetWrenchData(%cl,%data);
		if(!isObject(%br = %cl.wrenchBrick))
			return %pa;
		if(!isObject(%pl = %cl.player))
			return %pa;
		if(%br != %pl.boomBoxMusicBrick)
			return %pa;
		if(!isObject(%im = %pl.getMountedImage(0)))
			return %pa;
		if(%im.item.getName() !$= boomboxItem)
			return %pa;
		%cnt = getFieldCount(%data);
		for(%i=0;%i<%cnt;%i++)
		{
			%field = getField(%data,%i);
			%type = getWord(%field,0);
			if(%type $= "SDB")
			{
				%music = getWord(%field,1);
				if(%music !$= 0 && %music.uiName $= "")
					return %pa;
				if(%music $= 0)
				{
					if(%pl.boomboxPlaying !$= "")
					{
						messageClient(%client, '', "\c3Music stopped.");
						%pl.stopAudio(0);
						%pl.boomboxPlaying = "";
						serverPlay3d(boomBoxRemoveSound,%pl.getPosition());
						%pl.boomBoxMountSwapIgnore = 1;
						%pl.mountImage(boomBoxEmptyImage,0);
						%pl.boomBoxMountSwapIgnore = "";
					}
					if(isObject(%pl.boomBoxMusicBrick))
					{
						%pl.boomBoxMusicBrick.delete();
						%pl.boomBoxMusicBrick = "";
					}
					if(isObject(%cl.boomBoxMusicTmp))
						%cl.boomBoxMusicTmp.delete();
				}
				else
				{
					%pl.playAudio(0,%music);
					%pl.boomboxPlaying = %music;
					commandToClient(%cl,'',"\c6Playing song \"\c4" @ %music.uiName @ "\"");
					if(%im.getName() $= boomboxEmptyImage)
					{
						serverPlay3d(boomBoxInsertSound,%pl.getPosition());
						%pl.boomBoxMountSwapIgnore = 1;
						%pl.mountImage(boomBoxImage,0);
						%pl.boomBoxMountSwapIgnore = "";
					}
					if(isObject(%pl.boomBoxMusicBrick))
					{
						%pl.boomBoxMusicBrick.delete();
						%pl.boomBoxMusicBrick = "";
					}
					if(isObject(%cl.boomBoxMusicTmp))
						%cl.boomBoxMusicTmp.delete();
				}
				return %pa;
			}
		}
		return %pa;
	}
};
activatePackage(swol_boomboxItem);