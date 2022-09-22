using System;
using System.Collections.Generic;

namespace EnemizerLibrary
{
    /*
     * 0x0 = "Nothing",
     * 0x1 = "Rupee",
     * 0x2 = "RockCrab",
     * 0x3 = "Bee",
     * 0x4 = "Random",
     * 0x5 = "Bomb",
     * 0x6 = "Heart",
     * 0x7 = "Blue Rupee",
     * 0x8 = "Key",
     * 0x9 = "Arrow",
     * 0xA = "Bomb",
     * 0xB = "Heart",
     * 0xC = "Magic",
     * 0xD = "Big Magic",
     * 0xE = "Chicken",
     * 0xF = "Green Soldier",
     * 0x10 = "AliveRock?",
     * 0x11 = "Blue Soldier",
     * 0x12 = "Ground Bomb",
     * 0x13 = "Heart",
     * 0x14 = "Fairy",
     * 0x15 = "Heart",
     *    ? = "Nothing",
     * 0x80 = "Hole",
     * 0x82 = "Warp",
     * 0x84 = "Staircase",
     * 0x86 = "Bombable",
     * 0x88 = "Switch"
    */
    public partial class Randomization
    {
        public static GameRoom[] RoomList = new GameRoom[] {
            new GameRoom {
                Id = 4,
                Pots = new EmptyPot[] { new(0xA2, 0x19), new(0x98, 0x19), new(0x98, 0x16), new(0xA2, 0x16), new(0xF0, 0x13), new(0xCC, 0x13) },
                Items = new byte[] { 0x0A, 0x0A },
            },
            new GameRoom {
                Id = 9,
                Pots = new EmptyPot[] { new(0x0C, 0x04), new(0x30, 0x04), new(0x0C, 0x0C) },
                Items = new byte[] { 0x01, 0x0B, 0x88 },
            },
            new GameRoom {
                Id = 10,
                Pots = new EmptyPot[] { new(0xCC, 0x0B), new(0x9C, 0x11), new(0x60, 0x08), new(0x64, 0x07), new(0xA0, 0x11), new(0x68, 0x08), new(0x64, 0x09) },
                Items = new byte[] { 0x0B, 0x0B, 0x88 },
            },
            new GameRoom {
                Id = 17,
                Pots = new EmptyPot[] { new(0x98, 0x13), new(0x98, 0x0F), new(0x90, 0x0F), new(0x0A, 0x0F), new(0x90, 0x13), new(0xA0, 0x13)  },
                Items = new byte[] { 0x0B, 0x0B, 0x0B, 0x0B },
            },
            new GameRoom {
                Id = 21,
                Pots = new EmptyPot[] { new(0x60, 0x04), new(0x64, 0x04), new(0x68, 0x04), new(0x6C, 0x04), new(0x70, 0x04), new(0x0C, 0x06), new(0x10, 0x06), new(0x14, 0x06), new(0x46, 0x0B) },
                Items = new byte[] { 0x01, 0x07, 0x09, 0x09, 0x0A, 0x0B, 0x0C, 0x0C, 0x0D },
            },
            new GameRoom {
                Id = 22,
                Pots = new EmptyPot[] { new(0xBC, 0x03), new(0xC0, 0x03), new(0xBC, 0x04), new(0xC0, 0x04), new(0xBC, 0x05), new(0xC0, 0x05), new(0xBC, 0x06), new(0xC0, 0x06), new(0xF0, 0x13) },
                Items = new byte[] { 0x08, 0x09, 0x09, 0x0A, 0x0A, 0x0B, 0x0B, 0x0C, 0x0C },
            },
            new GameRoom {
                Id = 26,
                Pots = new EmptyPot[] { new(0xE8, 0x13), new(0xD4, 0x13), new(0x1C, 0x05), new(0x20, 0x05), new(0x1C, 0x1B), new(0x20, 0x1B) },
                Items = new byte[] { 0x0A, 0x0A, 0x0A, 0x0A },
            },
            new GameRoom {
                Id = 33,
                Pots = new EmptyPot[] { new(0x64, 0x1C), new(0xA8, 0x18), new(0x30, 0x1C), new(0x52, 0x1C), new(0xA0, 0x14), new(0x68, 0x1C) },
                Items = new byte[] { 0x0B, 0x0C, 0x0C },
            },
            new GameRoom {
                Id = 35,
                Pots = new EmptyPot[] { new(0x56, 0x1A), new(0x5A, 0x1A), new(0x5E, 0x1A), new(0x62, 0x1A), new(0x66, 0x1A) },
                Items = new byte[] { 0x01, 0x0A, 0x0B },
            },
            new GameRoom {
                Id = 36,
                Pots = new EmptyPot[] { new(0x0C, 0x04), new(0x30, 0x04), new(0x0C, 0x0C), new(0x30, 0x0C) },
                Items = new byte[] { 0x01, 0x0B, 0x0C, 0x07 },
            },
            new GameRoom {
                Id = 38,
                Pots = new EmptyPot[] { new(0x1C, 0x04), new(0x0C, 0x08), new(0x96, 0x13, 2), new(0x16, 0x1A, 2), new(0xDC, 0x1A) },
                Items = new byte[] { 0x07, 0x09, 0x0A, 0x0C, 0x88 },
            },
            new GameRoom {
                Id = 39,
                Pots = new EmptyPot[] { new(0xD6, 0x13), new(0xD6, 0x14), new(0xA6, 0x14), new(0xD6, 0x15), new(0x28, 0x1C), new(0x2C, 0x1C), new(0x50, 0x1C), new(0x54, 0x1C), new(0x66, 0x11), new(0x62, 0x11), new(0x6A, 0x11), new(0xA6, 0x15), new(0xA6, 0x13), new(0x5C, 0x0C), new(0xA0, 0x0C) },
                Items = new byte[] { 0x01, 0x01, 0x0A, 0x0B, 0x07, 0x07 },
            },
            new GameRoom {
                Id = 43,
                Pots = new EmptyPot[] { new(0x10, 0x05, 2), new(0x2C, 0x05, 2), new(0x10, 0x06, 2), new(0x2C, 0x06, 2), new(0x10, 0x07, 2), new(0x2C, 0x07, 2), new(0x92, 0x15), new(0xAA, 0x15), new(0x92, 0x16), new(0xAA, 0x16) },
                Items = new byte[] { 0x09, 0x09, 0x0A, 0x0A, 0x0A, 0x0A, 0x0B, 0x0B, 0x0B, 0x88 },
            },
            new GameRoom {
                Id = 47,
                Pots = new EmptyPot[] { new(0x1C, 0x07), new(0x20, 0x07), new(0x1C, 0x09), new(0x20, 0x09), new(0xAC, 0x13), new(0xB4, 0x13), new(0x68, 0x1B), new(0x68, 0x1C) },
                Items = new byte[] { 0x07, 0x07, 0x07, 0x07, 0x0B, 0x0B, 0x0B, 0x0B },
            },
            new GameRoom {
                Id = 53,
                Pots = new EmptyPot[] { new(0x3C, 0x06, 1), new(0x14, 0x08), new(0x18, 0x08), new(0x1C, 0x08), new(0x20, 0x08), new(0x24, 0x08), new(0x30, 0x14), new(0x4C, 0x17, 1), new(0x58, 0x17, 1), new(0x64, 0x1B, 1), new(0xF2, 0x1C, 1), new(0xF0, 0x16, 1), new(0x4C, 0x1C, 1) },
                Items = new byte[] { 0x07, 0x07, 0x07, 0x07, 0x07, 0x08, 0x0B },
            },
            new GameRoom {
                Id = 54,
                Pots = new EmptyPot[] { new(0x6C, 0x04), new(0x70, 0x04), new(0x0A, 0x10), new(0x72, 0x10) },
                Items = new byte[] { 0x08, 0x0A, 0x0B },
            },
            new GameRoom {
                Id = 55,
                Pots = new EmptyPot[] { new(0x30, 0x14), new(0x3C, 0x06) },
                Items = new byte[] { 0x08 },
            },
            new GameRoom {
                Id = 56,
                Pots = new EmptyPot[] { new(0xA4, 0x0C), new(0xA4, 0x0D), new(0xA4, 0x12), new(0xA4, 0x13) },
                Items = new byte[] { 0x08, 0x07, 0x0A, 0x0A },
            },
            new GameRoom {
                Id = 57,
                Pots = new EmptyPot[] { new(0x0C, 0x14), new(0x64, 0x16), new(0x64, 0x1A), new(0x30, 0x1C) },
                Items = new byte[] { 0x09, 0x09, 0x0B, 0x0C },
            },
            new GameRoom {
                Id = 60,
                Pots = new EmptyPot[] { new(0x18, 0x08), new(0x40, 0x0C), new(0x14, 0x0E), new(0x44, 0x12), new(0x60, 0x13), new(0x40, 0x14), new(0x40, 0x1A) },
                Items = new byte[] { 0x01, 0x07, 0x07, 0x07, 0x07, 0x0B, 0x0C },
            },
            new GameRoom {
                Id = 61,
                Pots = new EmptyPot[] { new(0x4C, 0x0C), new(0x70, 0x0C), new(0x18, 0x16), new(0x28, 0x16), new(0x20, 0x18), new(0x14, 0x1A), new(0x24, 0x1A) },
                Items = new byte[] { 0x09, 0x07, 0x0A, 0x0A, 0x0B, 0x0B, 0x0D },
            },
            new GameRoom {
                Id = 62,
                Pots = new EmptyPot[] { new(0x60, 0x06), new(0x64, 0x06), new(0x58, 0x0A), new(0x5C, 0x0A) },
                Items = new byte[] { 0x0A, 0x0B, 0x0C, 0x0C },
            },
            new GameRoom {
                Id = 63,
                Pots = new EmptyPot[] { new(0x0C, 0x19), new(0x14, 0x19), new(0x0C, 0x1A), new(0x14, 0x1A), new(0x0C, 0x1B), new(0x14, 0x1B), new(0x1C, 0x17) },
                Items = new byte[] { 0x01, 0x01, 0x08, 0x0A, 0x0A, 0x0B, 0x88 },
            },
            new GameRoom {
                Id = 65,
                Pots = new EmptyPot[] { new(0x64, 0x0A), new(0x34, 0x0F), new(0x34, 0x10), new(0x94, 0x16) },
                Items = new byte[] { 0x01, 0x0B, 0x0C, 0x0C },
            },
            new GameRoom {
                Id = 67,
                Pots = new EmptyPot[] { new(0x70, 0x1C, 1), new(0x4C, 0x1C, 1), new(0x4C, 0x14, 1), new(0x42, 0x04), new(0x4E, 0x04), new(0x42, 0x09), new(0x4E, 0x09), new(0x70, 0x14, 1) },
                Items = new byte[] { 0x08, 0x09, 0x0B, 0x0B, 0x0C },
            },
            new GameRoom {
                Id = 69,
                Pots = new EmptyPot[] { new(0x0C, 0x04), new(0x6C, 0x0B), new(0x30, 0x0C), new(0xDC, 0x10), new(0xEC, 0x10) },
                Items = new byte[] { 0x09, 0x09, 0x0B, 0x0B, 0x0C },
            },
            new GameRoom {
                Id = 73,
                Pots = new EmptyPot[] { new(0x9C, 0x1B), new(0xAC, 0x18), new(0xAC, 0x17), new(0x90, 0x14), new(0x68, 0x0F), new(0x68, 0x10), new(0x90, 0x13), new(0xAC, 0x14), new(0x90, 0x1B), new(0xAC, 0x1C), new(0xA0, 0x1B) },
                Items = new byte[] { 0x0B, 0x0B, 0x0C, 0x0C, 0x0C, 0x0C },
            },
            // new GameRoom {
            //     Id = 74, // PoD Entrance
            //     Pots = new EmptyPot[] {
            //         // new(0x0E, 0x05), // switch
            //         new(0x20, 0x05),
            //         new(0x5C, 0x05),
            //         // new(0x6E, 0x05), // switch
            //         new(0x38, 0x08),
            //         new(0x44, 0x08),
            //         new(0x0E, 0x0B),
            //         new(0x20, 0x0B),
            //         new(0x5C, 0x0B),
            //         new(0x6E, 0x0B),
            //     },
            //     Items = new byte[] { 0x0B, 0x0B, 0x0A, 0x0A, 0x0A, 0x0A, 0x01, 0x01 /*, 0x88, 0x88 */ },
            // },
            new GameRoom {
                Id = 78,
                Pots = new EmptyPot[] { new(0x30, 0x0A, 2), new(0x8C, 0x0B, 2), new(0x1C, 0x0C, 2), new(0x70, 0x0C) },
                Items = new byte[] { 0x88, 0x0B, 0x0C },
            },
            new GameRoom {
                Id = 83,
                Pots = new EmptyPot[] { new(0x5C, 0x0B), new(0x60, 0x0B), new(0x64, 0x0B), new(0x68, 0x0B) },
                Items = new byte[] { 0x08, 0x0B, 0x0B, 0x0C },
            },
            new GameRoom {
                Id = 84,
                Pots = new EmptyPot[] { new(0xBA, 0x19), new(0xBA, 0x1A), new(0xBA, 0x1B), new(0xBA, 0x1C) },
                Items = new byte[] { 0x07, 0x0B, 0x0B, 0x0B },
            },
            new GameRoom {
                Id = 86,
                Pots = new EmptyPot[] { new(0x64, 0x06, 1), new(0x60, 0x0A, 1), new(0x5C, 0x0A, 1), new(0x30, 0x14, 1), new(0x14, 0x06), new(0x28, 0x06), new(0x18, 0x07), new(0x24, 0x07), new(0x0C, 0x08), new(0x30, 0x08), new(0x18, 0x09), new(0x24, 0x09), new(0x14, 0x0A), new(0x28, 0x0A), new(0x0C, 0x14, 1) },
                Items = new byte[] { 0x07, 0x07, 0x0B, 0x0B, 0x08, 0x0C, 0x0C, 0x0C, 0x0C, 0x0C, 0x0C },
            },
            new GameRoom {
                Id = 87,
                Pots = new EmptyPot[] { new(0x5C, 0x07), new(0x0C, 0x14, 2), new(0x5C, 0x17), new(0x64, 0x17), new(0x54, 0x19), new(0x4C, 0x1B), new(0x30, 0x14, 2), new(0x1E, 0x16, 2) },
                Items = new byte[] { 0x07, 0x0A, 0x0B, 0x0C, 0x0C, 0x0C, 0x0D, 0x88 },
            },
            new GameRoom {
                Id = 88,
                Pots = new EmptyPot[] { new(0x60, 0x09), new(0x5C, 0x08), new(0x6C, 0x08), new(0x6C, 0x06), new(0x68, 0x05), new(0x5C, 0x06), new(0x0C, 0x0C), new(0x10, 0x07), new(0x60, 0x05), new(0x64, 0x05), new(0x0C, 0x07), new(0x5C, 0x07), new(0x6C, 0x07), new(0x10, 0x08), new(0x64, 0x09), new(0x68, 0x09) },
                Items = new byte[] { 0x0A, 0x0A, 0x0B, 0x0B, 0x0C, 0x0C, 0x0C, 0x0C },
            },
            new GameRoom {
                Id = 91,
                Pots = new EmptyPot[] { new(0xDA, 0x25), new(0xDE, 0x25), new(0xE2, 0x25) },
                Items = new byte[] { 0x88 },
            },
            new GameRoom {
                Id = 92,
                Pots = new EmptyPot[] { new(0xE4, 0x19), new(0x68, 0x18), new(0xE4, 0x16), new(0xD8, 0x19), new(0x54, 0x18), new(0xD8, 0x16), new(0x5E, 0x16), new(0x5E, 0x1A) },
                Items = new byte[] { 0x0A, 0x0D },
            },
            new GameRoom {
                Id = 93,
                Pots = new EmptyPot[] { new(0x10, 0x05), new(0x2C, 0x05), new(0x10, 0x0B), new(0x2C, 0x0B), new(0x0C, 0x14), new(0x30, 0x14), new(0x0C, 0x1C), new(0x30, 0x1C) },
                Items = new byte[] { 0x01, 0x07, 0x09, 0x09, 0x0A, 0x0A, 0x0A, 0x0C },
            },
            new GameRoom {
                Id = 94,
                Pots = new EmptyPot[] { new(0x5C, 0x04), new(0x60, 0x04), new(0x4C, 0x08), new(0x70, 0x08) },
                Items = new byte[] { 0x0B, 0x0B, 0x0C, 0x0C },
            },
            new GameRoom {
                Id = 99,
                Pots = new EmptyPot[] { new(0x30, 0x04), new(0x0C, 0x04), new(0x0C, 0x08), new(0x30, 0x0C), new(0x30, 0x08), new(0x0C, 0x0C) },
                Items = new byte[] { 0x08, 0x0B },
            },
            new GameRoom {
                Id = 100,
                Pots = new EmptyPot[] { new(0x0C, 0x16), new(0x10, 0x16), new(0x14, 0x16), new(0x24, 0x1C), new(0x28, 0x1C), new(0x2C, 0x1C), new(0x30, 0x1C) },
                Items = new byte[] { 0x0A, 0x0A, 0x0A, 0x0A, 0x0C, 0x0C, 0x88 },
            },
            new GameRoom {
                Id = 102,
                Pots = new EmptyPot[] { new(0x30, 0x25), new(0x34, 0x25), new(0x38, 0x25), new(0x54, 0x05), new(0x68, 0x05), new(0x30, 0x26), new(0x34, 0x26), new(0x38, 0x26), new(0x54, 0x06), new(0x68, 0x06) },
                Items = new byte[] { 0x07, 0x07, 0x09, 0x09, 0x09, 0x0A, 0x0A, 0x0A, 0x0B, 0x0B },
            },
            new GameRoom {
                Id = 103,
                Pots = new EmptyPot[] { new(0x16, 0x1A), new(0x12, 0x16), new(0x5C, 0x09), new(0x54, 0x1C), new(0x0C, 0x07), new(0x30, 0x07), new(0x60, 0x13), new(0x4A, 0x14), new(0x12, 0x17), new(0x12, 0x1A), new(0x68, 0x1C) },
                Items = new byte[] { 0x09, 0x0B, 0x0B, 0x0B, 0x0C, 0x0C, 0x0C },
            },
            new GameRoom {
                Id = 104,
                Pots = new EmptyPot[] { new(0x54, 0x0E), new(0x54, 0x0D), new(0x58, 0x0C), new(0x58, 0x06), new(0x58, 0x05), new(0x58, 0x04), new(0x40, 0x11), new(0x40, 0x0F), new(0x40, 0x07), new(0x58, 0x07), new(0x40, 0x10), new(0x40, 0x18), new(0x40, 0x19) },
                Items = new byte[] { 0x0B, 0x0B, 0x0B, 0x0C, 0x0C },
            },
            new GameRoom {
                Id = 115,
                Pots = new EmptyPot[] { new(0x9A, 0x15), new(0x9E, 0x15), new(0x14, 0x17), new(0x24, 0x17), new(0x90, 0x18), new(0xA8, 0x18), new(0x14, 0x1A), new(0x24, 0x1A), new(0x9A, 0x1B), new(0x9E, 0x1B) },
                Items = new byte[] { 0x01, 0x01, 0x0B, 0x0B, 0x07, 0X07, 0x09, 0x09, 0x0C, 0x88 },
            },
            new GameRoom {
                Id = 116,
                Pots = new EmptyPot[] { new(0x1E, 0x05), new(0x3E, 0x05), new(0x5E, 0x05), new(0x0E, 0x0B), new(0x2E, 0x0B), new(0x4E, 0x0B), new(0x6E, 0x0B) },
                Items = new byte[] { 0x09, 0x09, 0x0B, 0x0B, 0x0C, 0x0C, 0x88 },
            },
            new GameRoom {
                Id = 117,
                Pots = new EmptyPot[] { new(0x94, 0x16), new(0xA0, 0x16), new(0xAC, 0x16) },
                Items = new byte[] { 0x09, 0x0B, 0x0C },
            },
            new GameRoom {
                Id = 123,
                Pots = new EmptyPot[] { new(0x30, 0x0A), new(0x58, 0x0A), new(0x4C, 0x07), new(0x3C, 0x04), new(0x40, 0x04) },
                Items = new byte[] { 0x0B, 0x08 },
            },
            new GameRoom {
                Id = 124,
                Pots = new EmptyPot[] { new(0x24, 0x15), new(0x18, 0x0B), new(0x1C, 0x04), new(0x20, 0x04) },
                Items = new byte[] { 0x0B, 0x0B },
            },
            new GameRoom {
                Id = 125,
                Pots = new EmptyPot[] { new(0x2C, 0x0C), new(0x2C, 0x06), new(0x70, 0x06), new(0x6C, 0x14), new(0x72, 0x14), new(0x4C, 0x1C) },
                Items = new byte[] { 0x09, 0x0A, 0x0A, 0x0B },
            },
            new GameRoom {
                Id = 126,
                Pots = new EmptyPot[] { new(0x56, 0x0F), new(0x52, 0x1A), new(0x64, 0x1A), new(0x68, 0x1A) },
                Items = new byte[] { 0x0B, 0x0C, 0x88 },
            },
            new GameRoom {
                Id = 130,
                Pots = new EmptyPot[] { new(0x32, 0x05), new(0x32, 0x0A), new(0x4C, 0x32) },
                Items = new byte[] { 0x0B },
            },
            new GameRoom {
                Id = 131,
                Pots = new EmptyPot[] { new(0x4C, 0x04), new(0x50, 0x04), new(0x4C, 0x1C), new(0x50, 0x1C) },
                Items = new byte[] { 0x01, 0x07, 0x09, 0x09 },
            },
            new GameRoom {
                Id = 132,
                Pots = new EmptyPot[] { new(0x40, 0x11), new(0x3C, 0x11), new(0x50, 0x0E), new(0x2C, 0x0E), new(0x64, 0x06), new(0x18, 0x06), new(0x18, 0x07), new(0x64, 0x07) },
                Items = new byte[] { 0x09, 0x09 },
            },
            new GameRoom {
                Id = 135,
                Pots = new EmptyPot[] { new(0x0C, 0x0B), new(0x4C, 0x14), new(0x70, 0x14), new(0x10, 0x0C), new(0x28, 0x0C), new(0x20, 0x0C), new(0x18, 0x0C), new(0x10, 0x0B) },
                Items = new byte[] { 0x0C, 0x0D },
            },
            new GameRoom {
                Id = 139,
                Pots = new EmptyPot[] { new(0x4C, 0x14), new(0x4C, 0x0C, 1), new(0x20, 0x17, 1), new(0x1C, 0x17, 1), new(0x70, 0x0C, 1), new(0x20, 0x09, 1), new(0x4C, 0x1C) },
                Items = new byte[] { 0x08, 0x0B, 0x0C },
            },
            new GameRoom {
                Id = 140,
                Pots = new EmptyPot[] { new(0x4C, 0x0C, 2), new(0x70, 0x0C, 2), new(0x4C, 0x14), new(0x5C, 0x14), new(0x64, 0x15), new(0x68, 0x1A), new(0x58, 0x1B) },
                Items = new byte[] { 0x09, 0x0A, 0x0A, 0x0A, 0x0A, 0x0C, 0x88 },
            },
            new GameRoom {
                Id = 145,
                Pots = new EmptyPot[] { new(0x54, 0x04), new(0x68, 0x04) },
                Items = new byte[] { 0x0B, 0x0C },
            },
            new GameRoom {
                Id = 150,
                Pots = new EmptyPot[] { new(0x0E, 0x12), new(0x20, 0x05), new(0x20, 0x11), new(0x20, 0x18), new(0x4C, 0x15), new(0x70, 0x15), new(0x0E, 0x18) },
                Items = new byte[] { 0x0B, 0x0C, 0x0C, 0x0D },
            },
            new GameRoom {
                Id = 155,
                Pots = new EmptyPot[] { new(0x30, 0x04), new(0x30, 0x0C) },
                Items = new byte[] { 0x08, 0x0C },
            },
            new GameRoom {
                Id = 157,
                Pots = new EmptyPot[] { new(0x20, 0x07), new(0x28, 0x09), new(0x4C, 0x04), new(0x54, 0x04) },
                Items = new byte[] { 0x0A, 0x0C },
            },
            new GameRoom {
                Id = 159,
                Pots = new EmptyPot[] { new(0x8A, 0x14), new(0x8A, 0x13), new(0xB2, 0x13), new(0x28, 0x15), new(0x8A, 0x15), new(0x14, 0x1B), new(0x8A, 0x1B), new(0xB2, 0x1C), new(0xB2, 0x15), new(0xB2, 0x14), new(0x28, 0x1B), new(0xB2, 0x1B), new(0xB2, 0x1A), new(0x8A, 0x1C), new(0x8A, 0x1A), new(0x14, 0x15) },
                Items = new byte[] { 0x08, 0x0B, 0x0B, 0x0B, 0x0B, 0x0B, 0x88 },
            },
            new GameRoom {
                Id = 161,
                Pots = new EmptyPot[] { new(0x60, 0x1B), new(0x5C, 0x15), new(0x96, 0x06), new(0x64, 0x0B), new(0x68, 0x0C), new(0x6C, 0x0D), new(0x70, 0x0E), new(0x60, 0x17), new(0x4C, 0x1C), new(0x70, 0x1C) },
                Items = new byte[] { 0x08, 0x0B, 0x0B, 0x0B, 0x0C, 0x0C },
            },
            new GameRoom {
                Id = 168,
                Pots = new EmptyPot[] { new(0x8A, 0x1C), new(0xB2, 0x1C), new(0xB2, 0x13), new(0x8A, 0x13), new(0x1E, 0x18) },
                Items = new byte[] { 0x01, 0x0B },
            },
            new GameRoom {
                Id = 169,
                Pots = new EmptyPot[] { new(0x0C, 0x13), new(0x70, 0x13), new(0x90, 0x2B), new(0xEC, 0x2B), new(0x90, 0x2C), new(0xEC, 0x2C), new(0x10, 0x14), new(0x6C, 0x14) },
                Items = new byte[] { 0x0B, 0x0B, 0x0B, 0x09, 0x09, 0x09 },
            },
            new GameRoom {
                Id = 170,
                Pots = new EmptyPot[] { new(0xD4, 0x0A, 2), new(0xE8, 0x0A, 2), new(0xE8, 0x05, 2), new(0xD4, 0x05, 2), new(0x5E, 0x08, 2), new(0x6C, 0x37), new(0x6C, 0x38), new(0x6C, 0x39) },
                Items = new byte[] { 0x0B, 0x0B, 0x0B, 0x0B, 0x88 },
            },
            new GameRoom {
                Id = 176,
                Pots = new EmptyPot[] { new(0x14, 0x1B), new(0x18, 0x18), new(0x2C, 0x19), new(0x14, 0x15), new(0x1C, 0x15), new(0x20, 0x15), new(0x28, 0x15), new(0x10, 0x17), new(0x2C, 0x17), new(0x24, 0x18), new(0x10, 0x19), new(0x1C, 0x1B), new(0x28, 0x1B), new(0x20, 0x1B) },
                Items = new byte[] { 0x01, 0x01, 0x07, 0x07, 0x09, 0x09, 0x0A, 0x0A, 0x0B, 0x0B },
            },
            new GameRoom {
                Id = 179,
                Pots = new EmptyPot[] { new(0x0C, 0x14), new(0x30, 0x14), new(0x30, 0x1C) },
                Items = new byte[] { 0x08, 0x0C, 0x88 },
            },
            new GameRoom {
                Id = 180,
                Pots = new EmptyPot[] { new(0x2C, 0x1C), new(0x30, 0x1C) },
                Items = new byte[] { 0x0B, 0x0D },
            },
            new GameRoom {
                Id = 181,
                Pots = new EmptyPot[] { new(0x70, 0x04), new(0x70, 0x0F), new(0x4C, 0x10), new(0x70, 0x10), new(0x70, 0x11), new(0x70, 0x1C) },
                Items = new byte[] { 0x07, 0x0A, 0x0B, 0x0B, 0x0D, 0x88 },
            },
            new GameRoom {
                Id = 184,
                Pots = new EmptyPot[] { new(0x60, 0x0D), new(0x58, 0x10), new(0x68, 0x10) },
                Items = new byte[] { 0x0B, 0x0B, 0x88 },
            },
            new GameRoom {
                Id = 185,
                Pots = new EmptyPot[] { new(0x5C, 0x12), new(0x60, 0x12), new(0x68, 0x12), new(0x6C, 0x12) },
                Items = new byte[] { 0x01, 0x01, 0x07, 0x07 },
            },
            new GameRoom {
                Id = 186,
                Pots = new EmptyPot[] { new(0x64, 0x08), new(0x58, 0x08), new(0x5E, 0x04), new(0x4C, 0x06), new(0x70, 0x06), new(0x4C, 0x0A), new(0x70, 0x0A), new(0x5E, 0x0C) },
                Items = new byte[] { 0x01, 0x01, 0x08, 0x0B, 0x0B, 0x0C },
            },
            new GameRoom {
                Id = 188,
                Pots = new EmptyPot[] { new(0x8A, 0x03, 2), new(0xB2, 0x03, 2), new(0x56, 0x04, 1), new(0x66, 0x04, 1), new(0x8A, 0x0C, 2), new(0xB2, 0x0C, 2), new(0x30, 0x14), new(0x1C, 0x15), new(0x20, 0x15), new(0x1C, 0x1B), new(0x20, 0x1B), new(0x0C, 0x1C), new(0x30, 0x1C) },
                Items = new byte[] { 0x07, 0x07, 0x07, 0x07, 0x08, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0B, 0x0B, 0x88 },
            },
            new GameRoom {
                Id = 191,
                Pots = new EmptyPot[] { new(0x28, 0x14), new(0x2C, 0x14), new(0x30, 0x14), new(0x28, 0x1C), new(0x2C, 0x1C), new(0x30, 0x1C) },
                Items = new byte[] { 0x09, 0x0A, 0x0B, 0x0C, 0x0C, 0x0C },
            },
            new GameRoom {
                Id = 192,
                Pots = new EmptyPot[] { new(0x30, 0x0A), new(0x0C, 0x0E), new(0x0C, 0x1A), new(0x1C, 0x1B) },
                Items = new byte[] { 0x01, 0x07, 0x0A, 0x0B },
            },
            new GameRoom {
                Id = 194,
                Pots = new EmptyPot[] { new(0xB4, 0x07), new(0x64, 0x2E), new(0x44, 0x30), new(0x40, 0x34) },
                Items = new byte[] { 0x01, 0x09, 0x0C, 0x88 },
            },
            new GameRoom {
                Id = 196,
                Pots = new EmptyPot[] { new(0x54, 0x09), new(0x18, 0x0E), new(0x38, 0x11), new(0x54, 0x11), new(0x0C, 0x15), new(0x4C, 0x17), new(0x30, 0x19), new(0x0C, 0x1A) },
                Items = new byte[] { 0x01, 0x09, 0x0C, 0x07, 0x0A, 0x0A, 0x0B, 0x0B },
            },
            new GameRoom {
                Id = 199,
                Pots = new EmptyPot[] { new(0x0C, 0x0A), new(0x0C, 0x0B), new(0x0C, 0x16), new(0x0C, 0x1C) },
                Items = new byte[] { 0x09, 0x0C, 0x0B, 0x0D },
            },
            new GameRoom {
                Id = 201,
                Pots = new EmptyPot[] { new(0x1E, 0x16), new(0x5E, 0x16), new(0x3C, 0x16) },
                Items = new byte[] { 0x01, 0x01, 0x88 },
            },
            new GameRoom {
                Id = 203,
                Pots = new EmptyPot[] { new(0x58, 0x10), new(0x58, 0x1C) },
                Items = new byte[] { 0x07, 0x0B },
            },
            new GameRoom {
                Id = 204,
                Pots = new EmptyPot[] { new(0x24, 0x04), new(0x70, 0x04), new(0x24, 0x1C), new(0x70, 0x1C) },
                Items = new byte[] { 0x07, 0x0B, 0x07, 0x0A },
            },
            new GameRoom {
                Id = 206,
                Pots = new EmptyPot[] { new(0x4C, 0x08), new(0x50, 0x08), new(0x6C, 0x0C), new(0x70, 0x0C), new(0xCC, 0x0B, 3) },
                Items = new byte[] { 0x09, 0x0C, 0x0C, 0x0A, 0x80 },
            },
            new GameRoom {
                Id = 208,
                Pots = new EmptyPot[] { new(0x9E, 0x05), new(0x8C, 0x0B), new(0x2A, 0x0D), new(0x30, 0x10), new(0xB0, 0x14), new(0x92, 0x17), new(0x0C, 0x1C) },
                Items = new byte[] { 0x01, 0x01, 0x07, 0x0B, 0x0B, 0x0C, 0x0C },
            },
            new GameRoom {
                Id = 209,
                Pots = new EmptyPot[] { new(0x4C, 0x0C), new(0x30, 0x04), new(0x4C, 0x04), new(0x70, 0x04), new(0xA8, 0x07), new(0x70, 0x0C) },
                Items = new byte[] { 0x09, 0x01, 0x01, 0x01, 0x0D },
            },
            new GameRoom {
                Id = 214,
                Pots = new EmptyPot[] { new(0x5C, 0x16), new(0x60, 0x16) },
                Items = new byte[] { 0x0A, 0x0D },
            },
            new GameRoom {
                Id = 216,
                Pots = new EmptyPot[] { new(0xCA, 0x08), new(0xF2, 0x08), new(0xCA, 0x0A), new(0xF2, 0x0A), new(0xCA, 0x0C), new(0xF2, 0x0C), new(0x5C, 0x18), new(0x60, 0x18) },
                Items = new byte[] { 0x09, 0x09, 0x09, 0x09, 0x09, 0x0B, 0x0B, 0x0B },
            },
            new GameRoom {
                Id = 218,
                Pots = new EmptyPot[] { new(0x18, 0x17), new(0x24, 0x17), new(0x18, 0x19), new(0x24, 0x19) },
                Items = new byte[] { 0x09, 0x09, 0x0B, 0x88 },
            },
            new GameRoom {
                Id = 219,
                Pots = new EmptyPot[] { new(0x0C, 0x04), new(0x3E, 0x13), new(0x70, 0x04), new(0x58, 0x10) },
                Items = new byte[] { 0x07, 0x0B },
            },
            new GameRoom {
                Id = 220,
                Pots = new EmptyPot[] { new(0x38, 0x04), new(0x70, 0x04), new(0x44, 0x10), new(0x0C, 0x1C) },
                Items = new byte[] { 0x07, 0x09, 0x0A, 0x0B },
            },
            new GameRoom {
                Id = 235,
                Pots = new EmptyPot[] { new(0xCE, 0x08), new(0xD2, 0x08), new(0x58, 0x0E), new(0x5C, 0x0E), new(0x60, 0x0E) },
                Items = new byte[] { 0x07, 0x07, 0x0B, 0x0C, 0x0C },
            },
        };

        public void RandomizePots(int seed)
        {
            FixRetroArrows();

            var r = new Random(seed);
            foreach (var g in RoomList)
            {
                // scan all items and pots to see if there is a key or switch and pots reserved
                var reservedkeys = 0;
                var reservedswitches = 0;
                var roomItems = new List<byte>();
                var roomEmptyPots = new List<EmptyPot>();
                var roomPots = new List<FilledPot>();
                for (var i = 0; i < g.Items.Length; i++)
                {
                    if (g.Items[i] != 0x80) // if it a hole we don't want it
                    {
                        roomItems.Add(g.Items[i]);
                    }
                }

                for (var i = 0; i < g.Pots.Length; i++)
                {
                    if (g.Pots[i].reserved == 3)
                    {
                        roomPots.Add(new FilledPot(g.Pots[i].x, g.Pots[i].y, 0x80)); // if it a hole it stays in the default pot
                    }
                    else
                    {
                        roomEmptyPots.Add(g.Pots[i]); // as long as it not a hole we push a possible pot in empty pots list
                    }
                    if (g.Pots[i].reserved == 1)
                    {
                        reservedkeys++;
                    }
                    if (g.Pots[i].reserved == 2)
                    {
                        reservedswitches++;
                    }
                }

                while (reservedkeys > 0 || reservedswitches > 0) // loop until we find a spot for a key and switch if they have reserved spot
                {
                    var pid = r.Next(0, roomEmptyPots.Count);

                    if (reservedkeys > 0 && roomEmptyPots[pid].reserved == 1) // try to place a key in a reserved pot
                    {
                        roomItems.Remove(0x08);
                        roomPots.Add(new FilledPot(roomEmptyPots[pid].x, roomEmptyPots[pid].y, 0x08));
                        roomEmptyPots.RemoveAt(pid);
                        reservedkeys = roomItems.Contains(0x08) ? reservedkeys - 1 : 0;
                    }

                    if (reservedswitches > 0 && roomEmptyPots[pid].reserved == 2) // try to place a switch in a reserved pot
                    {
                        roomItems.Remove(0x88);
                        roomPots.Add(new FilledPot(roomEmptyPots[pid].x, roomEmptyPots[pid].y, 0x88));
                        roomEmptyPots.RemoveAt(pid);
                        reservedswitches = roomItems.Contains(0x88) ? reservedswitches - 1 : 0;
                    }
                }

                while (roomItems.Count > 0) // as long we have items to place we place them in an empty pot and remove the empty pot from the list
                {
                    var pid = r.Next(0, roomEmptyPots.Count);
                    var oid = (byte)roomItems[r.Next(0, roomItems.Count)];
                    if (optionFlags.HeroMode == true)
                    {
                        if (oid == 0x0B)
                        {
                            byte nid;
                            while (true)
                            {
                                nid = (byte)r.Next(0, 0x13);
                                if (nid != 0x08 && nid != 0x0F && nid != 0x10 && nid != 0x11 && nid != 0x0B)
                                {
                                    break;
                                }
                            }
                            roomPots.Add(new FilledPot(roomEmptyPots[pid].x, roomEmptyPots[pid].y, 0x0B));
                            roomItems.Remove(oid);
                            roomEmptyPots.RemoveAt(pid);
                            continue;
                        }
                    }

                    roomPots.Add(new FilledPot(roomEmptyPots[pid].x, roomEmptyPots[pid].y, oid));
                    roomItems.Remove(oid);
                    roomEmptyPots.RemoveAt(pid);
                    if (roomItems.Count == 0) break;
                }

                // Zarby Note : wow what is that code :scream:
                var itemPointer = new byte[4];
                itemPointer[2] = 01;
                itemPointer[0] = ROM_DATA[(0xDB67 + ((int)g.Id * 2)) + 0];
                itemPointer[1] = ROM_DATA[(0xDB67 + ((int)g.Id * 2)) + 1];
                var itemaddress = BitConverter.ToInt32(itemPointer, 0);
                var addr = Utilities.SnesToPCAddress(itemaddress);

                // replace hearts in hera if hero mode is on
                if (optionFlags.HeroMode)
                {
                    if (g.Id == 23) // if room id == 23 then change all the pots by something else than hearts
                    {
                        for (var i = 0; i < 12; i++)
                        {
                            byte nid;
                            while (true)
                            {
                                nid = (byte)r.Next(0, 0x13);
                                if (nid != 0x08 && nid != 0x0F && nid != 0x10 && nid != 0x11 && nid != 0x0B)
                                {
                                    ROM_DATA[addr + (i * 3) + 2] = nid;
                                    break;
                                }
                            }
                        }
                    }
                }

                for (var i = 0; i < roomPots.Count; i++)
                {
                    ROM_DATA[addr + (i * 3) + 0] = roomPots[i].x;
                    ROM_DATA[addr + (i * 3) + 1] = roomPots[i].y;
                    ROM_DATA[addr + (i * 3) + 2] = roomPots[i].id;
                }
            }
        }

        void FixRetroArrows()
        {
            // check if retro mode arrows set
            if (ROM_DATA[0x180175] == 0x0) return;

            foreach (var g in RoomList)
            {
                for (var i = 0; i < g.Items.Length; ++i)
                {
                    if (g.Items[i] == 0x9) // arrows
                    {
                        g.Items[i] = 0x7; // blue rupees
                    }
                }
            }
        }
    }

    public class GameRoom
    {
        public int Id { get; set; }
        public EmptyPot[] Pots { get; set; }
        public byte[] Items { get; set; }
    }

    public class EmptyPot
    {
        public byte x, y, reserved;
        public EmptyPot(byte x, byte y, byte reserved = 0)
        {
            // Reserved
            // 0 anything can go here, 1 reserved for key, 2 reserved for switch, 3 [0x80 go there]
            this.x = x;
            this.y = y;
            this.reserved = reserved;
        }
    }

    public class FilledPot
    {
        public byte x, y, id;
        public FilledPot(byte x, byte y, byte id)
        {
            this.x = x;
            this.y = y;
            this.id = id;
        }
    }
}
