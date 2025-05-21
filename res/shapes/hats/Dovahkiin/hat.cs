datablock ItemData(HatDragonbornItem)
{
	category = "Hat";
	classname = "Hat";
	shapeFile = "./Dovahkiin.dts";
	image = HatDragonbornImage;
	mass = 1;
	drag = 0.3;
	density = 0.2;
	elasticity = 0;
	friction = 1;
	doColorShift = false;
	uiName = "Hat Dragonborn";
	canDrop = true;
	iconName = $Despair::Path @ "res/shapes/hats/icon_hat";

	disguise = true;
	disguiseName = "Dragonborn";
	hidehair = true;
};
datablock ShapeBaseImageData(HatDragonbornImage)
{
	item = HatDragonbornItem;
	shapeFile = "./Dovahkiin.dts";
	doColorShift = false;
	mountPoint = $headSlot;
	eyeOffset = "0 0 -50";
};
