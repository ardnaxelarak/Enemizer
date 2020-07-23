using System;
using System.Linq;

namespace EnemizerLibrary
{
    public class DungeonEnemyRandomizer
    {
        Random rand;
        RomData romData;
        SpriteRequirementCollection spriteRequirementCollection;

        public SpriteGroupCollection spriteGroupCollection { get; set; }

        public RoomCollection roomCollection { get; set; }

        public DungeonEnemyRandomizer(RomData romData, Random rand, SpriteGroupCollection spriteGroupCollection, SpriteRequirementCollection spriteRequirementCollection)
        {
            this.romData = romData;
            this.rand = rand;
            this.spriteGroupCollection = spriteGroupCollection;
            this.spriteRequirementCollection = spriteRequirementCollection;

            this.roomCollection = new RoomCollection(romData, rand, spriteGroupCollection, spriteRequirementCollection);
        }

        public void RandomizeDungeonEnemies(OptionFlags optionFlags)
        {
            GenerateGroups();

            RandomizeRooms(optionFlags);

            WriteRom();
        }

        private void GenerateGroups()
        {
            spriteGroupCollection.RandomizeDungeonGroups();
        }

        private void RandomizeRooms(OptionFlags optionFlags)
        {
            roomCollection.LoadRooms();
            roomCollection.RandomizeRoomSpriteGroups(spriteGroupCollection, optionFlags);

            foreach (var room in roomCollection.Rooms)
            {
                if (RoomIdConstants.DontRandomizeRooms.Contains(room.RoomId))
                {
                    continue;
                }

                if (optionFlags.EasyModeEscape && RoomIdConstants.NoSpecialEnemiesRoomsInStandardMode.Contains(room.RoomId))
                {
                    continue;
                }

                room.RandomizeSprites(rand, optionFlags, spriteGroupCollection, spriteRequirementCollection);

                // randomize the pot sprite table
                // this isn't actually used yet (needs asm changes), but we will write it anyways
                room.RandomizePotSprites(rand, spriteGroupCollection, spriteRequirementCollection);
            }
        }

        private void WriteRom()
        {
            roomCollection.UpdateRom();
        }
    }
}
