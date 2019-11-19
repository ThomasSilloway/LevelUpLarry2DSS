// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "GameActor.generated.h"

UCLASS(Config=Game, Blueprintable, BlueprintType)
class LUL2DSS_API AGameActor : public AActor
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	AGameActor();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

};
