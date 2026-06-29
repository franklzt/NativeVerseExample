
// Copyright Epic Games, Inc. All Rights Reserved.

#include "VerseExampleComponent.h"
#include "VerseEvent.h"
#include "NativeVerseExample.verse_example_component.gen.ipp"

namespace verse {
	VERSE_EXAMPLE_COMPONENT_IMPL()

	void verse_example_component::Damage(double Amount)
	{
		OnDamagedNativeEvent.Broadcast(Amount);
		DispatchDamagedEvent(Amount);
	}

	void verse_example_component::DispatchDamagedEvent(double Amount)
	{
		if (verse::subscribable_event_intrnl* Event = Cast<verse::subscribable_event_intrnl>(DamagedEvent.Get().GetObject().Get()))
		{
			Event->Signal(FVerseValue(Amount));
		}
	}
	
} // namespace verse
