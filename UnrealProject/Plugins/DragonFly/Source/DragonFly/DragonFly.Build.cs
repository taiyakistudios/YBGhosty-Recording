// Copyright 2016-2021 Glassbox Inc. All Rights Reserved.
using Path = System.IO.Path;
using UnrealBuildTool;

public class DragonFly : ModuleRules
{
	public DragonFly(ReadOnlyTargetRules Target) : base(Target)
    {
        PrivatePCHHeaderFile = "Private/DragonFlyPrivatePCH.h";
        bUsePrecompiled = true; // this is set to true as a post-build step by PackagePluginForRelease.cmd
        DefaultBuildSettings = BuildSettingsVersion.V2;
        ShadowVariableWarningLevel = WarningLevel.Error;

        PrivateIncludePaths.Add(Path.Combine(Path.GetFullPath(Target.RelativeEnginePath), "Plugins/Compositing/Composure/Source/Composure/Private"));
        PrivateIncludePaths.Add(Path.Combine(Path.GetFullPath(Target.RelativeEnginePath), "Plugins/Compositing/Composure/Source/ComposureLayersEditor/Private"));

        PublicIncludePaths.AddRange(
            new string[] {
                    ModuleDirectory + "/Public",
                    ModuleDirectory + "/Public/Core",
                    ModuleDirectory + "/Public/Bindings",
                    ModuleDirectory + "/Public/Localization",
                    ModuleDirectory + "/Public/MaUI",
                    ModuleDirectory + "/Public/Helper",
                    ModuleDirectory + "/Public/Presets",
                    ModuleDirectory + "/Public/Playback",
                    ModuleDirectory + "/Public/CameraMode",
                    ModuleDirectory + "/Public/CameraMode/Simulcam",
                    ModuleDirectory + "/Public/CameraMode/VirtualCamera",
                    ModuleDirectory + "/Public/Review",
                    ModuleDirectory + "/Public/Setup",
                    ModuleDirectory + "/Public/DeveloperTools",
                    ModuleDirectory + "/Public/Slate",
                    ModuleDirectory + "/Public/Snapshots",
                    ModuleDirectory + "/Public/Viewport",
                    ModuleDirectory + "/Public/AssetEditor",
                    ModuleDirectory + "/Public/Lenses",
                    ModuleDirectory + "/Public/CameraProfile",
                    ModuleDirectory + "/Public/Materials",
            }
        );

        PrivateIncludePaths.AddRange(
			new string[] {
                // ... add other private include paths required here ...
				"DragonFly/Private/Slate",
                "DragonFly/Private/MaUI",
                "DragonFly/Private/MaUI/Styles",
                "DragonFly/Private/Bindings",
                "DragonFly/Private/CameraMode/Simulcam",
			}
		);
				
		PublicDependencyModuleNames.AddRange(
			new string[]
            {
                // ... add other public dependencies that you statically link with here ...
                "Core",
                "CoreUObject",
                "Engine",
                "InputCore",
                "DragonFlyRuntime",
                "MediaAssets",
			}
		);

        PrivateDependencyModuleNames.AddRange(
			new string[]
            {
                // ... add private dependencies that you statically link with here ...	
                "RenderCore",
                "HeadMountedDisplay",
                "Projects",
				"InputCore",
				"UnrealEd",
				"LevelEditor",
                "Sequencer",
                "MovieScene",
                "MovieSceneTools",
                "LevelSequenceEditor",
                "SequenceRecorder",
                "CoreUObject",
				"Engine",
				"Settings",
				"Slate",
				"SlateCore",
                "CinematicCamera",
                "EditorStyle",
                "DragonFlyRuntime",
                "MovieSceneTracks",
                "LevelSequence",
                "PropertyEditor",
                "EditorWidgets",
                "SequencerWidgets",
                "AssetRegistry",
                "AssetTools",//By ExportSystem for LevelSequence Asset creation!
				"KismetWidgets",
                "MovieSceneCapture",
                "DesktopPlatform",
                "Json",
                "JsonUtilities",
                "SessionServices",
                "ImageWrapper",
                "FBX",
                "BlueprintGraph",
                "UMG",
                "Blutility",
                "UMGEditor",             
                //Required by NDI
                "MediaUtils",
                "Renderer",
                "RenderCore",
                "RHI",
                "MaterialUtilities",
                //Multi-User stuff
                "Concert",
                "ConcertSyncClient",
                "ConcertSyncCore",
                "ConcertTransport",
                "MultiUserClient",
                "LiveLink",
                "LiveLinkInterface",
                //Compositing
                "Composure",
                "BlueprintMaterialTextureNodes",
                "ComposureLayersEditor",
                "AppFramework",
                "OpenColorIO",
                // Editor UE5
                "ToolMenus",
                //Media Capture
                "MediaIOCore",
            }
        );
			
		DynamicallyLoadedModuleNames.AddRange(
			new string[]
			{
                "Media"
				// ... add any modules that your module loads dynamically here ...
			}
		);

        PublicDefinitions.Add("WITH_OCIO=0");
    }
}
