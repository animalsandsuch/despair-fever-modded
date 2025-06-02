// extraResources by port
// URI: https://github.com/qoh/bl-lib/blob/master/extraResources.cs
// ---------

// addExtraResource(string fileName)
// Add a new file for clients to download. Not all extensions are allowed by the engine.
// You should call this before the mission is created (inside add-on execution is fine).
// If you do need to add files after that, you'll need to call the following to update:
//
//     EnvGuiServer::PopulateEnvResourceList();
//     snapshotGameAssets();
//
// Example:
//

function addExtraResource(%fileName)
{
	// Don't add the same file multiple times
	if (!ServerGroup.addedExtraResource[%fileName])
	{
		// Maintain a list of "extra" files so we can work nicely with the existing
		// resources, and call PopulateEnvResourceList without getting overwritten.
		if (ServerGroup.extraResourceCount $= "")
			ServerGroup.extraResourceCount = 0;

		ServerGroup.extraResource[ServerGroup.extraResourceCount] = %fileName;
		ServerGroup.extraResourceCount++;

		ServerGroup.addedExtraResource[%fileName] = true;
	}
}

package ExtraResources
{
	function EnvGuiServer::PopulateEnvResourceList()
	{
		Parent::PopulateEnvResourceList();

		for (%i = 0; %i < ServerGroup.extraResourceCount; %i++)
		{
			$EnvGuiServer::Resource[$EnvGuiServer::ResourceCount] = ServerGroup.extraResource[%i];
			$EnvGuiServer::ResourceCount++;
		}
	}
};

activatePackage(ExtraResources);

addExtraResource("Add-Ons/Face_WBPlus/smileyST.png");
addExtraResource("Add-Ons/Face_WBPlus/KleinerSmiley2ST.png");
addExtraResource("Add-Ons/Face_WBPlus/KleinerSmiley2.png");
addExtraResource("Add-Ons/Face_WBPlus/KleinerfSmileysST.png");
addExtraResource("Add-Ons/Face_WBPlus/KleinerfSmiley.png");
addExtraResource("Add-Ons/Face_WBPlus/smileyf.png");
addExtraResource("Add-Ons/Face_WBPlus/smileyfCreepy.png");
addExtraResource("Add-Ons/Face_WBPlus/smileyfST.png");
addExtraResource("Add-Ons/Face_WBPlus/smileySnakeST.png");
addExtraResource("Add-Ons/Face_Useful/evilsmirk.png");
addExtraResource("Add-Ons/Face_Useful/neutraleyebrows.png");
addExtraResource("Add-Ons/Face_Useful/neutralconcentrated.png");
addExtraResource("Add-Ons/Face_Useful/neutralorly.png");
addExtraResource("Add-Ons/Face_Useful/smileyidea.png");
addExtraResource("Add-Ons/Face_Useful/smileyneutral.png");
addExtraResource("Add-Ons/Face_Useful/smirk2.png");
addExtraResource("Add-Ons/Face_Useful/ehface.png");
addExtraResource("Add-Ons/Face_Useful/sigh.png");
addExtraResource("Add-Ons/Face_Useful/smilyevil.png");
addExtraResource("Add-Ons/Face_Useful/smilyworried.png");
addExtraResource("Add-Ons/Face_Useful/neutralwhat.png");
addExtraResource("Add-Ons/Face_Useful/neutralmad.png");
addExtraResource("Add-Ons/Face_Useful/neutralworried.png");
addExtraResource("Add-Ons/Face_Useful/smileysexy2.png");
addExtraResource("Add-Ons/Face_Useful/smileysexy.png");
addExtraResource("Add-Ons/Decal_PlayerFitNE/flanntemp.png");
addExtraResource("Add-Ons/Decal_PlayerFitNE/polologo.png");
addExtraResource("Add-Ons/Decal_PlayerFitNE/polosoft.png");
addExtraResource("Add-Ons/Decal_PlayerFitNE/polostripel.png");
addExtraResource("Add-Ons/Decal_PlayerFitNE/polostripels.png");
addExtraResource("Add-Ons/Decal_PlayerFitNE/polotemp.png");
addExtraResource("Add-Ons/Decal_PlayerFitNE/zhwindnike.png");
addExtraResource("Add-Ons/Decal_PlayerFitNE/zhnorthface.png");
addExtraResource("Add-Ons/Decal_PlayerFitNE/underarm.png");
addExtraResource("Add-Ons/Decal_PlayerFitNE/underarms.png");
addExtraResource("Add-Ons/Decal_PlayerFitNE/loveny.png");
addExtraResource("Add-Ons/Decal_PlayerFitNE/uzacdc.png");
addExtraResource("Add-Ons/Decal_PlayerFitNE/uzdchood.png");
addExtraResource("Add-Ons/Decal_PlayerFitNE/dcshirt.png");
addExtraResource("base/data/shapes/player/decal.ifl");
addExtraResource("base/data/shapes/player/face.ifl");