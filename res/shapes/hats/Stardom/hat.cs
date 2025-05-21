datablock ItemData(HatStarShadesItem)
{
	category = "Hat";
	classname = "Hat";
	shapeFile = "./StarShades.dts";
	image = HatStarShadesImage;
	mass = 1;
	drag = 0.3;
	density = 0.2;
	elasticity = 0;
	friction = 1;
	doColorShift = false;
	uiName = "Hat Stardom";
	canDrop = true;
	iconName = $Despair::Path @ "res/shapes/hats/icon_hat";

	disguise = false;
	hidehair = false;
};
datablock ShapeBaseImageData(HatStarShadesImage)
{
	item = HatStarShadesItem;
	shapeFile = "./StarShades.dts";
	doColorShift = false;
	mountPoint = $headSlot;
	eyeOffset = "0 0 -50";
	eyeOffset = "0 0 -50";
};
