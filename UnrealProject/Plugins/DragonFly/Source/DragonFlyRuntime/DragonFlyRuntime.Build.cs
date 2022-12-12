// Copyright 2016-2021 Glassbox Inc. All Rights Reserved.
using Path = System.IO.Path;
using UnrealBuildTool;

public class DragonFlyRuntime : ModuleRules
{
    public DragonFlyRuntime(ReadOnlyTargetRules Target) : base(Target)
    {
        PrivatePCHHeaderFile = "Private/DragonFlyRuntimePrivatePCH.h";
        bUsePrecompiled = true; // this is set to true as a post-build step by PackagePluginForRelease.cmd
        DefaultBuildSettings = BuildSettingsVersion.V2;
        ShadowVariableWarningLevel = WarningLevel.Error;

        //For some reason we need this so AJAMedia can access the AJALib.h file
        var EngineDir = Path.GetFullPath(Target.RelativeEnginePath);
        PublicIncludePaths.Add(Path.Combine(EngineDir, "Plugins/Media/AjaMedia/Source/ThirdParty/Build/Include"));
        PublicIncludePaths.Add(Path.Combine(EngineDir, "Plugins/Media/BlackmagicMedia/Source/ThirdParty/Build/Include"));
        PublicIncludePaths.Add(Path.Combine(EngineDir, "Plugins/Animation/LiveLink/Source/LiveLink/Private"));

        PublicIncludePaths.AddRange(
            new string[] {
                ModuleDirectory + "/Public/NDI",
                ModuleDirectory + "/Public/Core",
                ModuleDirectory + "/Public/Export",
                ModuleDirectory + "/Public/Helper",
                ModuleDirectory + "/Public/Playback",
                ModuleDirectory + "/Public/Review",
                ModuleDirectory + "/Public/Presets",
                ModuleDirectory + "/Public/Snapshots",
                ModuleDirectory + "/Public/MediaCapture",
                ModuleDirectory + "/Public/MultiUser",
                ModuleDirectory + "/Public/Trackers",
                ModuleDirectory + "/Public/TimeManagement",
                ModuleDirectory + "/Public/Lenses",
                ModuleDirectory + "/Public/Simulcam",
                ModuleDirectory + "/Public/CameraProfile",
                }
        );


        PrivateIncludePaths.AddRange(
            new string[] {
				// ... add other private include paths required here ...
                "DragonFlyRuntime/Private",
            }
        );

        PublicDependencyModuleNames.AddRange(
            new string[]
            {
                "Core",
                "MediaAssets",
                "NDIIOShaders",
                "Engine",
                "CoreUObject",
                "Projects",
                "MediaFrameworkUtilities",
                "MediaIOCore",
            }
        );

        PrivateDependencyModuleNames.AddRange(
            new string[]
            {
                "Projects",
                "InputCore",
                "CoreUObject",
                "Engine",
                "CinematicCamera",
                "LevelSequence",
                "Json",
                "JsonUtilities",
                "SessionServices",
                "ImageWrapper",
                "FBX",
                "Media",
                "MediaAssets",
                "MediaUtils",
                "Renderer",
                "RenderCore",
                "RHI",
                "CinematicCamera",
                "LiveLink",
                "LiveLinkInterface",
                "TimeManagement",
                "Blackmagic",
                "BlackmagicMedia",
                "BlackmagicMediaOutput",
                "AjaMedia",
                "AjaMediaOutput",
                "MediaFrameworkUtilities",
                "MediaIOCore",
                "AssetRegistry",
                "Composure",
            }
         );

        //For use with accessing level-sequence editor in runtime module...
        if (Target.bBuildEditor == true)
        {
            PrivateDependencyModuleNames.Add("UnrealEd");
            PrivateDependencyModuleNames.Add("AssetTools");
            PrivateDependencyModuleNames.Add("LevelSequenceEditor");
            PrivateDependencyModuleNames.Add("AssetTools");
            PrivateDependencyModuleNames.Add("Sequencer");
            PrivateDependencyModuleNames.Add("MovieScene");
            PrivateDependencyModuleNames.Add("MovieSceneTracks");
            PrivateDependencyModuleNames.Add("MovieSceneTools");
            PrivateDependencyModuleNames.Add("Slate");
            PrivateDependencyModuleNames.Add("SlateCore");
            PrivateDependencyModuleNames.Add("DesktopPlatform");
            PrivateDependencyModuleNames.Add("LevelEditor");
            PrivateDependencyModuleNames.Add("PropertyEditor");
            PrivateDependencyModuleNames.Add("EditorWidgets");
            PrivateDependencyModuleNames.Add("BlueprintGraph");
            PrivateDependencyModuleNames.Add("UMG");
            PrivateDependencyModuleNames.Add("Blutility");
            PrivateDependencyModuleNames.Add("UMGEditor");
            PrivateDependencyModuleNames.Add("LevelEditor");


            //Multi-User stuff
            PrivateDependencyModuleNames.AddRange(
                new string[] {
                    "Concert",
                    "ConcertSyncClient",
                    "ConcertSyncCore",
                    "ConcertTransport",
                    "MultiUserClient"
                });
            PrivateDependencyModuleNames.AddRange(
                new string[] {
                    "PropertyEditor",
                    "EditorWidgets",
                    "BlueprintGraph",
                    "UMG",
                    "Blutility",
                    "UMGEditor"
                });
        }

        // VirtualCameraCore
        bool bReadyForDeploy = true;

        string DragonFlyCorePath = Path.GetFullPath(Path.Combine(ModuleDirectory, "..", "..", "VirtualCameraCore", "x64"));
        string CoreLibPath = "";

        if (Target.Configuration == UnrealTargetConfiguration.DebugGame)
        {
            CoreLibPath = Path.Combine(DragonFlyCorePath, "Debug");
            PrivateDefinitions.Add("DFLY_DEBUG"); 
        }
        else if (!bReadyForDeploy)
        {
            CoreLibPath = Path.Combine(DragonFlyCorePath, "Release");
            PrivateDefinitions.Add("DFLY_RELEASE");
        }
        else
        {
            CoreLibPath = Path.Combine(DragonFlyCorePath, "Deploy");
            PrivateDefinitions.Add("DFLY_DEPLOY");
        }

        PublicAdditionalLibraries.Add(Path.Combine(CoreLibPath, "VirtualCameraCore.lib"));
        PublicDelayLoadDLLs.Add("VirtualCameraCore.dll");
        RuntimeDependencies.Add(Path.Combine(CoreLibPath, "VirtualCameraCore.dll"));
        PublicIncludePaths.Add(Path.Combine(DragonFlyCorePath, "..", "VirtualCameraCore"));

        // NatNet Include
        string NatNetLibPath = Path.Combine(DragonFlyCorePath, "..", "VirtualCameraCore", "ThirdParty", "NatNetSDK", "lib", "x64");
        RuntimeDependencies.Add(Path.Combine(NatNetLibPath, "NatNetLib.dll"));
        PublicDelayLoadDLLs.Add("NatNetLib.dll");
    }
}
