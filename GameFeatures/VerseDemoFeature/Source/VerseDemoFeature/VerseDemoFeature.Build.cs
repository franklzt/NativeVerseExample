// Fill out your copyright notice in the Description page of Project Settings.

using System;
using UnrealBuildTool;
using  System.IO;
public class VerseDemoFeature : ModuleRules
{
	public VerseDemoFeature(ReadOnlyTargetRules Target) : base(Target)
	{
        SetupVerse("/Verse.org/SceneGraph", VerseScope.PublicAPI);
        // "/Verse/VerseDemoFeatures"
        //SetupVerse("/VerseDemoFeature/Verse", VerseScope.PublicAPI);
        //SetupVerse("/VerseDemoFeature.org/VerseDemo", VerseScope.PublicAPI);
        PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

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
           
        });
	}
}
