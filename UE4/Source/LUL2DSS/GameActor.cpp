// Fill out your copyright notice in the Description page of Project Settings.

#include "GameActor.h"

// Sets default values
AGameActor::AGameActor() : Super()
{	
	bNetLoadOnClient = false;
}

// Called when the game starts or when spawned
void AGameActor::BeginPlay()
{
	Super::BeginPlay();
	UE_LOG(LogClass, Log, TEXT("Spawned a GameActor custom class!"));
}

