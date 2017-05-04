#include "Level1.h"

#include "Floor.h"
#include "Wall.h"
#include "Door.h"
#include "Dwarf.h"
#include "Elf.h"
#include "Wizard.h"
#include "Potion.h"
#include "Staff.h"

void Level1::setupLevel() {
makeFloorAtTile(32 / 32, 32 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(32 / 32, 64 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(32 / 32, 96 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(64 / 32, 32 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(64 / 32, 64 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(64 / 32, 96 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(96 / 32, 32 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(96 / 32, 64 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(96 / 32, 96 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(128 / 32, 64 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(160 / 32, 64 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(192 / 32, 64 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(64 / 32, 128 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(64 / 32, 160 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(64 / 32, 192 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(64 / 32, 224 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(224 / 32, 32 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(256 / 32, 32 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(288 / 32, 32 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(320 / 32, 32 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(224 / 32, 64 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(224 / 32, 96 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(224 / 32, 128 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(224 / 32, 160 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(256 / 32, 160 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(256 / 32, 64 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(256 / 32, 96 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(256 / 32, 128 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(288 / 32, 160 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(288 / 32, 128 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(288 / 32, 96 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(288 / 32, 64 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(320 / 32, 64 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(320 / 32, 96 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(320 / 32, 128 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(320 / 32, 160 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(352 / 32, 64 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(384 / 32, 32 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(384 / 32, 64 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(384 / 32, 96 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(416 / 32, 32 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(416 / 32, 64 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(416 / 32, 96 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(448 / 32, 32 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(448 / 32, 64 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(448 / 32, 96 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(416 / 32, 128 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(416 / 32, 160 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(448 / 32, 160 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(448 / 32, 192 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(448 / 32, 224 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(448 / 32, 256 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(448 / 32, 288 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(448 / 32, 320 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(448 / 32, 352 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(480 / 32, 320 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(480 / 32, 288 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(480 / 32, 256 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(480 / 32, 224 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(480 / 32, 192 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(512 / 32, 224 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(512 / 32, 256 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(512 / 32, 288 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(544 / 32, 224 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(544 / 32, 256 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(544 / 32, 288 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(576 / 32, 224 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(576 / 32, 256 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(576 / 32, 288 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(608 / 32, 224 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(608 / 32, 256 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(608 / 32, 288 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(416 / 32, 352 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(384 / 32, 352 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(352 / 32, 352 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(320 / 32, 352 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(320 / 32, 320 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(320 / 32, 288 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(320 / 32, 256 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(320 / 32, 224 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(96 / 32, 224 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(128 / 32, 224 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(160 / 32, 224 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(192 / 32, 224 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(224 / 32, 224 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(256 / 32, 224 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(288 / 32, 224 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(96 / 32, 256 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(96 / 32, 288 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(96 / 32, 320 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(128 / 32, 320 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(96 / 32, 352 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(96 / 32, 384 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(64 / 32, 384 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(64 / 32, 416 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(64 / 32, 448 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(64 / 32, 480 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(64 / 32, 512 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(96 / 32, 448 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(128 / 32, 448 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(160 / 32, 448 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(160 / 32, 480 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(192 / 32, 480 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(224 / 32, 480 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(256 / 32, 480 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(160 / 32, 512 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(160 / 32, 544 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(192 / 32, 544 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(224 / 32, 544 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(160 / 32, 576 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(160 / 32, 608 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(192 / 32, 608 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(224 / 32, 608 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(160 / 32, 320 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(288 / 32, 352 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(256 / 32, 352 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(224 / 32, 384 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(224 / 32, 352 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(224 / 32, 320 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(192 / 32, 384 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(192 / 32, 352 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(192 / 32, 320 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(160 / 32, 384 / 32, "assets/sprites/Floor.png");
makeFloorAtTile(160 / 32, 352 / 32, "assets/sprites/Floor.png");

makeWallAtTile(0 / 32, 96 / 32, "assets/sprites/Wall.png");
makeWallAtTile(0 / 32, 64 / 32, "assets/sprites/Wall.png");
makeWallAtTile(0 / 32, 32 / 32, "assets/sprites/Wall.png");
makeWallAtTile(0 / 32, 0 / 32, "assets/sprites/Wall.png");
makeWallAtTile(32 / 32, 0 / 32, "assets/sprites/Wall.png");
makeWallAtTile(64 / 32, 0 / 32, "assets/sprites/Wall.png");
makeWallAtTile(96 / 32, 0 / 32, "assets/sprites/Wall.png");
makeWallAtTile(128 / 32, 0 / 32, "assets/sprites/Wall.png");
makeWallAtTile(128 / 32, 32 / 32, "assets/sprites/Wall.png");
makeWallAtTile(160 / 32, 32 / 32, "assets/sprites/Wall.png");
makeWallAtTile(192 / 32, 32 / 32, "assets/sprites/Wall.png");
makeWallAtTile(192 / 32, 0 / 32, "assets/sprites/Wall.png");
makeWallAtTile(224 / 32, 0 / 32, "assets/sprites/Wall.png");
makeWallAtTile(256 / 32, 0 / 32, "assets/sprites/Wall.png");
makeWallAtTile(288 / 32, 0 / 32, "assets/sprites/Wall.png");
makeWallAtTile(320 / 32, 0 / 32, "assets/sprites/Wall.png");
makeWallAtTile(352 / 32, 0 / 32, "assets/sprites/Wall.png");
makeWallAtTile(352 / 32, 32 / 32, "assets/sprites/Wall.png");
makeWallAtTile(384 / 32, 0 / 32, "assets/sprites/Wall.png");
makeWallAtTile(416 / 32, 0 / 32, "assets/sprites/Wall.png");
makeWallAtTile(448 / 32, 0 / 32, "assets/sprites/Wall.png");
makeWallAtTile(480 / 32, 0 / 32, "assets/sprites/Wall.png");
makeWallAtTile(480 / 32, 32 / 32, "assets/sprites/Wall.png");
makeWallAtTile(480 / 32, 64 / 32, "assets/sprites/Wall.png");
makeWallAtTile(480 / 32, 96 / 32, "assets/sprites/Wall.png");
makeWallAtTile(480 / 32, 128 / 32, "assets/sprites/Wall.png");
makeWallAtTile(448 / 32, 128 / 32, "assets/sprites/Wall.png");
makeWallAtTile(352 / 32, 96 / 32, "assets/sprites/Wall.png");
makeWallAtTile(352 / 32, 128 / 32, "assets/sprites/Wall.png");
makeWallAtTile(384 / 32, 128 / 32, "assets/sprites/Wall.png");
makeWallAtTile(128 / 32, 96 / 32, "assets/sprites/Wall.png");
makeWallAtTile(160 / 32, 96 / 32, "assets/sprites/Wall.png");
makeWallAtTile(192 / 32, 96 / 32, "assets/sprites/Wall.png");
makeWallAtTile(0 / 32, 128 / 32, "assets/sprites/Wall.png");
makeWallAtTile(32 / 32, 128 / 32, "assets/sprites/Wall.png");
makeWallAtTile(96 / 32, 128 / 32, "assets/sprites/Wall.png");
makeWallAtTile(128 / 32, 128 / 32, "assets/sprites/Wall.png");
makeWallAtTile(192 / 32, 128 / 32, "assets/sprites/Wall.png");
makeWallAtTile(32 / 32, 160 / 32, "assets/sprites/Wall.png");
makeWallAtTile(32 / 32, 192 / 32, "assets/sprites/Wall.png");
makeWallAtTile(32 / 32, 224 / 32, "assets/sprites/Wall.png");
makeWallAtTile(96 / 32, 160 / 32, "assets/sprites/Wall.png");
makeWallAtTile(96 / 32, 192 / 32, "assets/sprites/Wall.png");
makeWallAtTile(192 / 32, 160 / 32, "assets/sprites/Wall.png");
makeWallAtTile(128 / 32, 192 / 32, "assets/sprites/Wall.png");
makeWallAtTile(160 / 32, 192 / 32, "assets/sprites/Wall.png");
makeWallAtTile(192 / 32, 192 / 32, "assets/sprites/Wall.png");
makeWallAtTile(224 / 32, 192 / 32, "assets/sprites/Wall.png");
makeWallAtTile(288 / 32, 192 / 32, "assets/sprites/Wall.png");
makeWallAtTile(320 / 32, 192 / 32, "assets/sprites/Wall.png");
makeWallAtTile(352 / 32, 192 / 32, "assets/sprites/Wall.png");
makeWallAtTile(352 / 32, 160 / 32, "assets/sprites/Wall.png");
makeWallAtTile(352 / 32, 224 / 32, "assets/sprites/Wall.png");
makeWallAtTile(352 / 32, 256 / 32, "assets/sprites/Wall.png");
makeWallAtTile(352 / 32, 288 / 32, "assets/sprites/Wall.png");
makeWallAtTile(352 / 32, 320 / 32, "assets/sprites/Wall.png");
makeWallAtTile(384 / 32, 320 / 32, "assets/sprites/Wall.png");
makeWallAtTile(416 / 32, 320 / 32, "assets/sprites/Wall.png");
makeWallAtTile(416 / 32, 288 / 32, "assets/sprites/Wall.png");
makeWallAtTile(416 / 32, 256 / 32, "assets/sprites/Wall.png");
makeWallAtTile(416 / 32, 224 / 32, "assets/sprites/Wall.png");
makeWallAtTile(416 / 32, 192 / 32, "assets/sprites/Wall.png");
makeWallAtTile(384 / 32, 160 / 32, "assets/sprites/Wall.png");
makeWallAtTile(384 / 32, 192 / 32, "assets/sprites/Wall.png");
makeWallAtTile(480 / 32, 160 / 32, "assets/sprites/Wall.png");
makeWallAtTile(512 / 32, 160 / 32, "assets/sprites/Wall.png");
makeWallAtTile(512 / 32, 192 / 32, "assets/sprites/Wall.png");
makeWallAtTile(544 / 32, 192 / 32, "assets/sprites/Wall.png");
makeWallAtTile(576 / 32, 192 / 32, "assets/sprites/Wall.png");
makeWallAtTile(608 / 32, 192 / 32, "assets/sprites/Wall.png");
makeWallAtTile(640 / 32, 192 / 32, "assets/sprites/Wall.png");
makeWallAtTile(640 / 32, 224 / 32, "assets/sprites/Wall.png");
makeWallAtTile(640 / 32, 256 / 32, "assets/sprites/Wall.png");
makeWallAtTile(640 / 32, 288 / 32, "assets/sprites/Wall.png");
makeWallAtTile(640 / 32, 320 / 32, "assets/sprites/Wall.png");
makeWallAtTile(608 / 32, 320 / 32, "assets/sprites/Wall.png");
makeWallAtTile(576 / 32, 320 / 32, "assets/sprites/Wall.png");
makeWallAtTile(544 / 32, 320 / 32, "assets/sprites/Wall.png");
makeWallAtTile(512 / 32, 320 / 32, "assets/sprites/Wall.png");
makeWallAtTile(480 / 32, 352 / 32, "assets/sprites/Wall.png");
makeWallAtTile(512 / 32, 352 / 32, "assets/sprites/Wall.png");
makeWallAtTile(128 / 32, 256 / 32, "assets/sprites/Wall.png");
makeWallAtTile(160 / 32, 256 / 32, "assets/sprites/Wall.png");
makeWallAtTile(192 / 32, 256 / 32, "assets/sprites/Wall.png");
makeWallAtTile(224 / 32, 256 / 32, "assets/sprites/Wall.png");
makeWallAtTile(256 / 32, 256 / 32, "assets/sprites/Wall.png");
makeWallAtTile(288 / 32, 256 / 32, "assets/sprites/Wall.png");
makeWallAtTile(128 / 32, 288 / 32, "assets/sprites/Wall.png");
makeWallAtTile(160 / 32, 288 / 32, "assets/sprites/Wall.png");
makeWallAtTile(192 / 32, 288 / 32, "assets/sprites/Wall.png");
makeWallAtTile(224 / 32, 288 / 32, "assets/sprites/Wall.png");
makeWallAtTile(256 / 32, 288 / 32, "assets/sprites/Wall.png");
makeWallAtTile(288 / 32, 288 / 32, "assets/sprites/Wall.png");
makeWallAtTile(288 / 32, 320 / 32, "assets/sprites/Wall.png");
makeWallAtTile(256 / 32, 320 / 32, "assets/sprites/Wall.png");
makeWallAtTile(32 / 32, 256 / 32, "assets/sprites/Wall.png");
makeWallAtTile(64 / 32, 256 / 32, "assets/sprites/Wall.png");
makeWallAtTile(64 / 32, 288 / 32, "assets/sprites/Wall.png");
makeWallAtTile(64 / 32, 320 / 32, "assets/sprites/Wall.png");
makeWallAtTile(64 / 32, 352 / 32, "assets/sprites/Wall.png");
makeWallAtTile(32 / 32, 352 / 32, "assets/sprites/Wall.png");
makeWallAtTile(32 / 32, 384 / 32, "assets/sprites/Wall.png");
makeWallAtTile(32 / 32, 416 / 32, "assets/sprites/Wall.png");
makeWallAtTile(32 / 32, 448 / 32, "assets/sprites/Wall.png");
makeWallAtTile(32 / 32, 480 / 32, "assets/sprites/Wall.png");
makeWallAtTile(32 / 32, 512 / 32, "assets/sprites/Wall.png");
makeWallAtTile(32 / 32, 544 / 32, "assets/sprites/Wall.png");
makeWallAtTile(64 / 32, 544 / 32, "assets/sprites/Wall.png");
makeWallAtTile(96 / 32, 544 / 32, "assets/sprites/Wall.png");
makeWallAtTile(96 / 32, 512 / 32, "assets/sprites/Wall.png");
makeWallAtTile(96 / 32, 480 / 32, "assets/sprites/Wall.png");
makeWallAtTile(128 / 32, 480 / 32, "assets/sprites/Wall.png");
makeWallAtTile(128 / 32, 512 / 32, "assets/sprites/Wall.png");
makeWallAtTile(128 / 32, 544 / 32, "assets/sprites/Wall.png");
makeWallAtTile(128 / 32, 576 / 32, "assets/sprites/Wall.png");
makeWallAtTile(128 / 32, 608 / 32, "assets/sprites/Wall.png");
makeWallAtTile(128 / 32, 640 / 32, "assets/sprites/Wall.png");
makeWallAtTile(160 / 32, 640 / 32, "assets/sprites/Wall.png");
makeWallAtTile(192 / 32, 640 / 32, "assets/sprites/Wall.png");
makeWallAtTile(224 / 32, 640 / 32, "assets/sprites/Wall.png");
makeWallAtTile(256 / 32, 640 / 32, "assets/sprites/Wall.png");
makeWallAtTile(256 / 32, 608 / 32, "assets/sprites/Wall.png");
makeWallAtTile(256 / 32, 576 / 32, "assets/sprites/Wall.png");
makeWallAtTile(224 / 32, 576 / 32, "assets/sprites/Wall.png");
makeWallAtTile(192 / 32, 576 / 32, "assets/sprites/Wall.png");
makeWallAtTile(256 / 32, 544 / 32, "assets/sprites/Wall.png");
makeWallAtTile(256 / 32, 512 / 32, "assets/sprites/Wall.png");
makeWallAtTile(224 / 32, 512 / 32, "assets/sprites/Wall.png");
makeWallAtTile(192 / 32, 512 / 32, "assets/sprites/Wall.png");
makeWallAtTile(288 / 32, 512 / 32, "assets/sprites/Wall.png");
makeWallAtTile(288 / 32, 480 / 32, "assets/sprites/Wall.png");
makeWallAtTile(288 / 32, 448 / 32, "assets/sprites/Wall.png");
makeWallAtTile(256 / 32, 448 / 32, "assets/sprites/Wall.png");
makeWallAtTile(224 / 32, 448 / 32, "assets/sprites/Wall.png");
makeWallAtTile(192 / 32, 448 / 32, "assets/sprites/Wall.png");
makeWallAtTile(128 / 32, 352 / 32, "assets/sprites/Wall.png");
makeWallAtTile(128 / 32, 384 / 32, "assets/sprites/Wall.png");
makeWallAtTile(96 / 32, 416 / 32, "assets/sprites/Wall.png");
makeWallAtTile(128 / 32, 416 / 32, "assets/sprites/Wall.png");
makeWallAtTile(160 / 32, 416 / 32, "assets/sprites/Wall.png");
makeWallAtTile(192 / 32, 416 / 32, "assets/sprites/Wall.png");
makeWallAtTile(224 / 32, 416 / 32, "assets/sprites/Wall.png");
makeWallAtTile(256 / 32, 416 / 32, "assets/sprites/Wall.png");
makeWallAtTile(256 / 32, 384 / 32, "assets/sprites/Wall.png");
makeWallAtTile(288 / 32, 384 / 32, "assets/sprites/Wall.png");
makeWallAtTile(320 / 32, 384 / 32, "assets/sprites/Wall.png");
makeWallAtTile(416 / 32, 384 / 32, "assets/sprites/Wall.png");
makeWallAtTile(448 / 32, 384 / 32, "assets/sprites/Wall.png");
makeWallAtTile(480 / 32, 384 / 32, "assets/sprites/Wall.png");
makeWallAtTile(352 / 32, 384 / 32, "assets/sprites/Wall.png");
makeWallAtTile(384 / 32, 384 / 32, "assets/sprites/Wall.png");

makeDoorAtTile(64 / 32, 128 / 32, "assets/sprites/Door.png");
makeDoorAtTile(128 / 32, 64 / 32, "assets/sprites/Door.png");
makeDoorAtTile(192 / 32, 64 / 32, "assets/sprites/Door.png");
makeDoorAtTile(352 / 32, 64 / 32, "assets/sprites/Door.png");
makeDoorAtTile(416 / 32, 128 / 32, "assets/sprites/Door.png");
makeDoorAtTile(96 / 32, 256 / 32, "assets/sprites/Door.png");
makeDoorAtTile(352 / 32, 352 / 32, "assets/sprites/Door.png");
makeDoorAtTile(192 / 32, 480 / 32, "assets/sprites/Door.png");
makeDoorAtTile(192 / 32, 608 / 32, "assets/sprites/Door.png");
getTile(192 / 32, 608 / 32)->getDoor()->setLocked(true);
makeDoorAtTile(64 / 32, 480 / 32, "assets/sprites/Door.png");
makeDoorAtTile(256 / 32, 192 / 32, "assets/sprites/Door.png");
makeDoorAtTile(128 / 32, 320 / 32, "assets/sprites/Door.png");
makeDoorAtTile(256 / 32, 352 / 32, "assets/sprites/Door.png");

{
Enemy *dwarf = new Dwarf();
dwarf->setPosition(260, 62);
addEnemy(dwarf);
}
{
Enemy *dwarf = new Dwarf();
dwarf->setPosition(286, 140);
addEnemy(dwarf);
}
{
Enemy *dwarf = new Dwarf();
dwarf->setPosition(167, 380);
addEnemy(dwarf);
}
{
Enemy *dwarf = new Dwarf();
dwarf->setPosition(211, 318);
addEnemy(dwarf);
}
{
Enemy *dwarf = new Dwarf();
dwarf->setPosition(64, 510);
addEnemy(dwarf);
}

{
Enemy *elf = new Elf();
elf->setPosition(433, 48);
elf->getLoot()->addKey();
addEnemy(elf);
}
{
Enemy *elf = new Elf();
elf->setPosition(597, 232);
addEnemy(elf);
}
{
Enemy *elf = new Elf();
elf->setPosition(595, 279);
addEnemy(elf);
}
{
Enemy *elf = new Elf();
elf->setPosition(258, 480);
addEnemy(elf);
}
{
Enemy *elf = new Elf();
elf->setPosition(223, 545);
addEnemy(elf);
}

{
Player *player = new Wizard();
player->setPosition(56, 52);
addPlayer(player);
}

putItemAtTile(new Potion(), 320 / 32, 32 / 32, "assets/sprites/Potion.png");
putItemAtTile(new Potion(), 480 / 32, 256 / 32, "assets/sprites/Potion.png");
putItemAtTile(new Potion(), 192 / 32, 352 / 32, "assets/sprites/Potion.png");
putItemAtTile(new Potion(), 160 / 32, 544 / 32, "assets/sprites/Potion.png");

putItemAtTile(new Staff(), 224 / 32, 608 / 32, "assets/sprites/Staff.png");
}