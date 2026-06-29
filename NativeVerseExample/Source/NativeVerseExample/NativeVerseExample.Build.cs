// Copyright Epic Games, Inc. All Rights Reserved.

using System;
using EpicGames.Core;
using Microsoft.Extensions.Logging;
using UnrealBuildTool;
using System.IO;

public class NativeVerseExample : ModuleRules
{
	public NativeVerseExample(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;

		string TempDirectory = PluginDirectory;
		
		Log.Logger.LogWarning("Plugin info: {0}",TempDirectory);
		//SetupVerse("/NativeVerseExample/SceneGraph", VerseScope.InternalUser);
		SetupVerse("/Verse.org/NativeVerseExample", VerseScope.PublicAPI,
			String.IsNullOrEmpty(TempDirectory)
				? "/Source/NativeVerseExample/Verse"
				: "G:/Remake/VerseWorking/Plugins/NativeVerseExample/Source/NativeVerseExample/Verse");


		/*SetupVerse("/NativeVerseExample/SceneGraph", VerseScope.InternalUser,
			"G:/Remake/VerseWorking/Plugins/NativeVerseExample/Source/NativeVerseExample/Verse");*/
		//SetupVerse("/NativeVerseExample", VerseScope.InternalUser);
		PublicDependencyModuleNames.AddRange(new string[] {
			"Core",
			"CoreUObject",
			"Engine",
			"InputCore",

		});

		PrivateDependencyModuleNames.AddRange(new string[] {
			"Entity",
			"VerseNative",
			"VerseEngine",
			"VerseSimulation",
			"VerseSimulationMetadata",
			"VerseSpatialMath",
			"VerseTags",
			"VerseRestricted",
			"VerseColors",
			"Component",
			"Verse",
            "VersePrint"

        });
		
		PublicDefinitions.Add("WITH_VERSE_NATIVE=1");
	}
}
