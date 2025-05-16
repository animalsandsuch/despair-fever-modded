//Contains all 2d sound effects as well as music
datablock AudioProfile(AnnouncementSound)
{
	fileName = $Despair::Path @ "res/sounds/dingdong.wav";
	description = audio2D;
	preload = true;
};

datablock AudioProfile(KillerJingleSound)
{
	fileName = $Despair::Path @ "res/sounds/dundun.wav";
	description = audio2D;
	preload = true;
};

datablock AudioProfile(DespairBodyDiscoverySound1)
{
	fileName = $Despair::Path @ "res/music/BodyDiscoveryNoise1.ogg";
	description = audio2D;
	preload = true;
};

datablock AudioProfile(DespairBodyDiscoverySound2)
{
	fileName = $Despair::Path @ "res/music/BodyDiscoveryNoise2.ogg";
	description = audio2D;
	preload = true;
};

datablock AudioProfile(DespairBodyDiscoverySound3)
{
	fileName = $Despair::Path @ "res/music/BodyDiscoveryNoise3.ogg";
	description = audio2D;
	preload = true;
};

datablock AudioProfile(DespairBodyDiscoverySound4)
{
	fileName = $Despair::Path @ "res/music/BodyDiscoveryNoise4.ogg";
	description = audio2D;
	preload = true;
};

datablock AudioProfile(DespairBodyDiscoverySound5)
{
	fileName = $Despair::Path @ "res/music/BodyDiscoveryNoise5.ogg";
	description = audio2D;
	preload = true;
};

datablock AudioProfile(DespairMusicGameStart)
{
	fileName = $Despair::Path @ "res/music/gameStart.ogg";
	description = audio2D;
	preload = true;
};

datablock AudioProfile(DespairMusicInvestigationStart)
{
	fileName = $Despair::Path @ "res/music/investigationStart.ogg";
	description = audio2D;
	preload = true;
};

datablock AudioProfile(DespairMusicVoteStart)
{
	fileName = $Despair::Path @ "res/music/VoteStart.ogg";
	description = audio2D;
	preload = true;
};

datablock AudioProfile(DespairMusicPreamble)
{
	fileName = $Despair::Path @ "res/music/rolesDecided.ogg";
	description = audio2D;
	preload = true;
};

datablock AudioProfile(DespairPrayers)
{
	fileName = $Despair::Path @ "res/music/prayers.ogg";
	description = audio2D;
	preload = true;
};

datablock AudioProfile(DespairMusicOpeningIntro)
{
	fileName = $Despair::Path @ "res/music/OpeningIntro.ogg";
	description = audio2D;
	preload = true;
};

datablock AudioProfile(DespairMusicOpeningLoop)
{
	fileName = $Despair::Path @ "res/music/OpeningLoop.ogg";
	description = AudioLooping2D;
	preload = true;
};

datablock AudioProfile(DespairMusicTrialDiscussionIntro1)
{
	fileName = $Despair::Path @ "res/music/TrialDiscussionintro1.ogg";
	description = audio2D;
	preload = true;
	loopStart = 54833;
	loopProfile = DespairMusicTrialDiscussionLoop1;
};

datablock AudioProfile(DespairMusicTrialDiscussionLoop1)
{
	fileName = $Despair::Path @ "res/music/TrialDiscussionloop1.ogg";
	description = AudioLooping2D;
	preload = true;
};

datablock AudioProfile(DespairMusicTrialDiscussionIntro2)
{
	fileName = $Despair::Path @ "res/music/TrialDiscussionintro2.ogg";
	description = audio2D;
	preload = true;
	loopStart = 13061;
	loopProfile = DespairMusicTrialDiscussionLoop2;
};

datablock AudioProfile(DespairMusicTrialDiscussionLoop2)
{
	fileName = $Despair::Path @ "res/music/TrialDiscussionloop2.ogg";
	description = AudioLooping2D;
	preload = true;
};

datablock AudioProfile(DespairMusicTrialDiscussionIntro3)
{
	fileName = $Despair::Path @ "res/music/TrialDiscussionintro3.ogg";
	description = audio2D;
	preload = true;
	loopStart = 86401;
	loopProfile = DespairMusicTrialDiscussionLoop3;
};

datablock AudioProfile(DespairMusicTrialDiscussionLoop3)
{
	fileName = $Despair::Path @ "res/music/TrialDiscussionloop3.ogg";
	description = AudioLooping2D;
	preload = true;
};

datablock AudioProfile(DespairMusicTrialDiscussionIntro4)
{
	fileName = $Despair::Path @ "res/music/TrialDiscussionintro4.ogg";
	description = audio2D;
	preload = true;
	loopStart = 69335;
	loopProfile = DespairMusicTrialDiscussionLoop4;
};

datablock AudioProfile(DespairMusicTrialDiscussionLoop4)
{
	fileName = $Despair::Path @ "res/music/TrialDiscussionloop4.ogg";
	description = AudioLooping2D;
	preload = true;
};
datablock AudioProfile(DespairMusicTrialDiscussionLoop5)
{
	fileName = $Despair::Path @ "res/music/TrialDiscussionloop5.ogg";
	description = AudioLooping2D;
	preload = true;
};
datablock AudioProfile(DespairMusicInvestigationIntro1)
{
	fileName = $Despair::Path @ "res/music/investigationintro1.ogg";
	description = audio2D;
	preload = true;
	loopStart = 27042;
	loopProfile = DespairMusicInvestigationLoop1;
};

datablock AudioProfile(DespairMusicInvestigationLoop1)
{
	fileName = $Despair::Path @ "res/music/investigationloop1.ogg";
	description = AudioLooping2D;
	preload = true;
};

datablock AudioProfile(DespairMusicInvestigationIntro2)
{
	fileName = $Despair::Path @ "res/music/investigationintro2.ogg";
	description = audio2D;
	preload = true;
	loopStart = 5649;
	loopProfile = DespairMusicInvestigationLoop2;
};

datablock AudioProfile(DespairMusicInvestigationLoop2)
{
	fileName = $Despair::Path @ "res/music/investigationloop2.ogg";
	description = AudioLooping2D;
	preload = true;
};

datablock AudioProfile(DespairMusicInvestigationIntro3)
{
	fileName = $Despair::Path @ "res/music/investigationintro3.ogg";
	description = audio2D;
	preload = true;
	loopStart = 80433;
	loopProfile = DespairMusicInvestigationLoop3;
};

datablock AudioProfile(DespairMusicInvestigationLoop3)
{
	fileName = $Despair::Path @ "res/music/investigationloop3.ogg";
	description = AudioLooping2D;
	preload = true;
};

datablock AudioProfile(DespairMusicIntense)
{
	fileName = $Despair::Path @ "res/music/deadManWalking.ogg";
	description = AudioLooping2D;
	preload = true;
};

datablock AudioProfile(DespairMusicIntense2)
{
	fileName = $Despair::Path @ "res/music/deadManWalking2.ogg";
	description = AudioLooping2D;
	preload = true;
};

datablock AudioProfile(DespairMusicWonderfulIntro)
{
	fileName = $Despair::Path @ "res/music/wonderfulStoryIntro.ogg";
	description = audio2D;
	preload = true;
	loopStart = 1;
	loopProfile = DespairMusicWonderfulLoop;
};

datablock AudioProfile(DespairMusicWonderfulLoop)
{
	fileName = $Despair::Path @ "res/music/wonderfulStoryLoop.ogg";
	description = AudioLooping2D;
	preload = true;
};

datablock AudioProfile(DespairMusicKillerWin)
{
	fileName = $Despair::Path @ "res/music/killerWinsShort.ogg";
	description = audio2D;
	preload = true;
};
datablock AudioProfile(DespairMusicInnocentsWin)
{
	fileName = $Despair::Path @ "res/music/hollowWin.ogg";
	description = audio2D;
	preload = true;
};

datablock AudioProfile(DespairMusicWorldendDominator)
{
	fileName = $Despair::Path @ "res/music/WorldendDominator.ogg";
	description = AudioLooping2D;
	preload = true;
};

function ServerStopSong()
{
	if(isObject(ServerMusic))
	{
		cancel(ServerMusic.loopSchedule);
		ServerMusic.delete();
	}
}

function ServerPlaySong(%profile)
{
	ServerStopSong();
	%isLooping = %profile.description == nameToID("AudioLooping2D");
	new AudioEmitter(ServerMusic)
	{
		position = "0 0 0";
		profile = %profile;
		useProfileDescription = 0;
		description = %profile.description;
		is3d = false;
		type = "0";
		volume = "1.5";
		outsideAmbient = "1";
		ReferenceDistance = "9001";
		maxDistance = "9001";
		isLooping = %isLooping;
	};
	scopeToAll(ServerMusic);
	if(isObject(%profile.loopProfile))
		ServerMusic.loopSchedule = schedule(%profile.loopStart, 0, ServerPlaySong, %profile.loopProfile);
}

function IndexSongs()
{
	%size = getDataBlockGroupSize();

	for(%i=0;%i<%size;%i++)
	{
		%data = getDataBlock(%i);
		%class = %data.getClassName();
		if (%class !$= "AudioProfile")
			continue;
		echo(%data.getName() SPC %class);
	}
}