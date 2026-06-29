# Copyright Epic Games, Inc. All Rights Reserved.

using { /Verse.org/Native }
using { /Verse.org/SceneGraph }

@experimental
verse_example_component<public><native> := class<final_super>(component):

    @experimental
    Damage<public><native>(Amount:float):void

    @experimental
    DamagedEvent<public><native><final>:listenable(float) = subscribable_event_intrnl(float){}
