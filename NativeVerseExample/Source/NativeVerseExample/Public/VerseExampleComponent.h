// Copyright Epic Games, Inc. All Rights Reserved.


#pragma once

#include "Component.h"
#include "NativeVerseExample.verse_example_component.gen.h"

namespace verse {

class verse_example_component : public component
{
	VERSE_EXAMPLE_COMPONENT_DEF()
public:

	NATIVEVERSEEXAMPLE_API virtual void Damage(double Amount);

	DECLARE_MULTICAST_DELEGATE_OneParam(FOnDamaged, double)
	FOnDamaged OnDamagedNativeEvent;

protected:
	NATIVEVERSEEXAMPLE_API void DispatchDamagedEvent(double Amount);

	TVal<TInterfaceInstance<verse::listenable>> DamagedEvent{ EDefaultConstructNonNullPtr::UnsafeDoNotUse };
	
};

} // namespace verse
