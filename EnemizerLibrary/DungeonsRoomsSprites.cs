﻿namespace EnemizerLibrary
{
    public class RoomSpriteCollection
    {
        readonly int[][] room_sprites = new int[292][];

        public int[][] RoomSprites
        {
            get
            {
                return room_sprites;
            }
        }

        //All the room randomized // Might add all the rooms and remove the sprites in the unchanged rooms to randomize the palettes in every rooms
        public int[] randomized_rooms =
        {
            2,4,9,10,11,14,17,19,21,22,23,25,26,27,30,31,33,34,36,38,39,40,42,43,46,49,50,52,53,54,55,56,57,58,59,
            60,61,62,63,64,65,66,67,68,69,70,73,74,75,76,78,80,81,82,83,84,85,86,87,88,89,91,92,93,94,95,96,97,98,99,
            100,101,102,103,104,106,107,109,110,113,114,115,116,117,118,119,123,124,125,126,127,128,129,130,131,132,133,
            135,139,140,141,142,145,146,147,149,151,152,153,155,156,157,158,159,160,161,165,166,167,168,169,170,171,174,
            175,176,177,178,179,182,183,184,186,187,188,190,192,193,194,195,196,197,201,203,204,206,208,209,210,213,214,
            216,217,218,219,220,223,224,228,232,238,239,240,249,251,235,254,263,264,268,269,291,267,185,286,181,150
        }; //127 removed

        public RoomSpriteCollection() // Will require a double check
        {
            for (int i = 0; i < 292; i++)
            {
                room_sprites[i] = null;
            }

            //all sprites contained in rooms that will be randomized

            room_sprites[2] = new int[] { 0x04D936, 0x04D939, 0x04D93C, 0x04D93F, 0x04D942, 0x04D960, 0x04D963 };

            room_sprites[4] = new int[] { 0x04D96B, 0x04D96E, 0x04D971, 0x04D974, 0x04D983, 0x04D98F, 0x04D992, 0x04D995 };

            room_sprites[9] = new int[] { 0x04D9D0, 0x04D9D3, 0x04D9D6 };

            room_sprites[10] = new int[] { 0x04D9DB, 0x04D9DE, 0x04D9E1, 0x04D9E4, 0x04D9EA, 0x04D9ED };

            room_sprites[11] = new int[] { 0x04D9F5, 0x04D9F8, 0x04D9FB, 0x04D9FE, 0x04DA01, 0x04DA04, 0x04DA07, 0x04DA0A, 0x04DA0D };

            room_sprites[14] = new int[] { 0x04DA1A, 0x04DA1D, 0x04DA20 };

            room_sprites[17] = new int[] { 0x04DA28, 0x04DA2B, 0x04DA2E, 0x04DA31, 0x04DA34, 0x04DA37, 0x04DA3A, 0x04DA3D };

            room_sprites[19] = new int[] { 0x04DA4D, 0x04DA50, 0x04DA53, 0x04DA56, 0x04DA5C, 0x04DA68, 0x04DA65, 0x04DA59 };

            room_sprites[21] = new int[] { 0x04DA99, 0x04DA9C, 0x04DA9F, 0x04DAA2, 0x04DAA5, 0x04DAA8 };

            room_sprites[22] = new int[] { 0x04DAAD, 0x04DAB0, 0x04DAB3, 0x04DAB6, 0x04DAB9, 0x04DABC, 0x04DABF };

            room_sprites[23] = new int[] { 0x04DACD, 0x04DAD0, 0x04DAD3, 0x04DAD6, 0x04DAD9, 0x04DADC };

            room_sprites[25] = new int[] { 0x04DAE1, 0x04DAE4, 0x04DAE7, 0x04DAEA };

            room_sprites[26] = new int[] { 0x04DAEF, 0x04DAF2, 0x04DAF5, 0x04DAF8, 0x04DAFB, 0x04DAFE, 0x04DB01, 0x04DB04, 0x04DB0A };

            room_sprites[27] = new int[] { 0x04DB18, 0x04DB1B, 0x04DB1E, 0x04DB21 };

            room_sprites[30] = new int[] { 0x04DB4C, 0x04DB4F, 0x04DB52, 0x04DB55, 0x04DB58, 0x04DB5B };

            room_sprites[31] = new int[] { 0x04DB60, 0x04DB63, 0x04DB66, 0x04DB69, 0x04DB6C, 0x04DB6F, 0x04DB72, 0x04DB75 };

            room_sprites[33] = new int[] { 0x04DB7F, 0x04DB85, 0x04DB88, 0x04DB8B, 0x04DB8E, 0x04DB91, 0x04DB94, 0x04DB97, 0x04DB9A, 0x04DB9D, 0x04DBA0 };

            room_sprites[34] = new int[] { 0x04DBA5, 0x04DBA8, 0x04DBAB, 0x04DBAE, 0x04DBB1, 0x04DBB4, 0x04DBB7 };

            room_sprites[36] = new int[] { 0x04DBCD, 0x04DBD0, 0x04DBD3, 0x04DBD6, 0x04DBD9, 0x04DBDC, 0x04DBDF };

            room_sprites[38] = new int[] { 0x04DC07, 0x04DBE6, 0x04DBE9, 0x04DBEC, 0x04DBEF, 0x04DBF2, 0x04DBF5, 0x04DBFB, 0x04DBFE, 0x04DC01, 0x04DC04 };

            room_sprites[39] = new int[] { 0x04DC0C, 0x04DC0F, 0x04DC12, 0x04DC15, 0x04DC18, 0x04DC1B, 0x04DC1E };

            room_sprites[40] = new int[] { 0x04DC2F };

            room_sprites[42] = new int[] { 0x04DC42, 0x04DC45, 0x04DC48, 0x04DC4B, 0x04DC4E, 0x04DC51 };

            room_sprites[43] = new int[] { 0x04DC5C, 0x04DC5F, 0x04DC62, 0x04DC65, 0x04DC68, 0x04DC6B };

            room_sprites[46] = new int[] { 0x04DC7E, 0x04DC81, 0x04DC84, 0x04DC87, 0x04DC8A, 0x04DC8D };

            room_sprites[49] = new int[] { 0x04DC9D, 0x04DCA0, 0x04DCA3, 0x04DCA6, 0x04DCA9, 0x04DCAC, 0x04DCAF, 0x04DCB2, 0x04DCB5, 0x04DCB8 };

            room_sprites[50] = new int[] { 0x04DCBD, 0x04DCC0, 0x04DCC3, 0x04DCC6, 0x04DCC9 };

            room_sprites[52] = new int[] { 0x04DCD9, 0x04DCDC, 0x04DCDF, 0x04DCE5, 0x04DCE8, 0x04DCEB, 0x04DCE2 };

            room_sprites[53] = new int[] { 0x04DCF6, 0x04DCF9, 0x04DCFC, 0x04DCFF, 0x04DD02, 0x04DD08, 0x04DD0B, 0x04DD0E, 0x04DD05 };

            room_sprites[54] = new int[] { 0x04DD16, 0x04DD19, 0x04DD22, 0x04DD28, 0x04DD2B }; //disabled for crash issue//0x04DD16,0x04DD19,0x04DD1C,0x04DD22,0x04DD28,0x04DD2B,0x04DD2E,0x04DD31

            room_sprites[55] = new int[] { 0x04DD39, 0x04DD3C, 0x04DD3F, 0x04DD42, 0x04DD48, 0x04DD4B, 0x04DD4E, 0x04DD51, 0x04DD45 };

            room_sprites[56] = new int[] { 0x04DD56, 0x04DD59, 0x04DD5C, 0x04DD5F, 0x04DD62, 0x04DD65, 0x04DD68 };

            room_sprites[57] = new int[] { 0x04DD6D, 0x04DD73, 0x04DD79, 0x04DD7C, 0x04DD7F, 0x04DD82 };

            room_sprites[58] = new int[] { 0x04DD87, 0x04DD8A, 0x04DD8D, 0x04DD90, 0x04DD93, 0x04DD96 };

            room_sprites[59] = new int[] { 0x04DD9B, 0x04DD9E, 0x04DDA1, 0x04DDA4, 0x04DDA7, 0x04DDAA, 0x04DDAD };

            room_sprites[60] = new int[] { 0x04DDB2, 0x04DDB5, 0x04DDB8 };

            room_sprites[61] = new int[] { 0x04DDC3, 0x04DDC9, 0x04DDCC, 0x04DDCF, 0x04DDD2, 0x04DDD5, 0x04DDDB, 0x04DDDE, 0x04DDE1, 0x04DDE4, 0x04DDE7 };

            room_sprites[62] = new int[] { 0x04DDEF, 0x04DDF2, 0x04DE04, 0x04DE07, 0x04DE0D, 0x04DE10 }; //Removed for crash issue

            room_sprites[63] = new int[] { 0x04DE18, 0x04DE1E, 0x04DE21 };

            room_sprites[64] = new int[] { 0x04DE26, 0x04DE29, 0x04DE2F, 0x04DE32, 0x04DE35 };

            room_sprites[65] = new int[] { 0x04DE3C, 0x04DE3F, 0x04DE42, 0x04DE45 };

            room_sprites[66] = new int[] { 0x04DE4A, 0x04DE4D, 0x04DE50, 0x04DE53, 0x04DE56, 0x04DE59 };

            room_sprites[67] = new int[] { 0x04DE5E, 0x04DE61 };

            room_sprites[68] = new int[] { 0x04DE6C, 0x04DE6F, 0x04DE72, 0x04DE75, 0x04DE78, 0x04DE7E };

            room_sprites[69] = new int[] { 0x04DE86, 0x04DE8C, 0x04DE8F, 0x04DE9B, 0x04DE9E, 0x04DEA1, 0x04DE89, 0x04DE92, 0x04DE95, 0x04DE98 };

            room_sprites[70] = new int[] { 0x04DEA6, 0x04DEAC, 0x04DEB2 };

            room_sprites[73] = new int[] { 0x04DEB9, 0x04DEBC, 0x04DEBF, 0x04DEC2, 0x04DEC5, 0x04DEC8, 0x04DECE, 0x04DED1, 0x04DED4, 0x04DED7, 0x04DEDA, 0x04DEDD };

            room_sprites[74] = new int[] { 0x04DEE5, 0x04DEE8 };

            room_sprites[75] = new int[] { 0x04DEED, 0x04DEF0, 0x04DEF3, 0x04DEF6, 0x04DEF9, 0x04DEFC, 0x04DEFF, 0x04DF02 };

            room_sprites[76] = new int[] { 0x04DF0D, 0x04DF10, 0x04DF13, 0x04DF16, 0x04DF19, 0x04DF1C };

            room_sprites[78] = new int[] { 0x04DF26, 0x04DF29, 0x04DF2C, 0x04DF2F };

            room_sprites[80] = new int[] { 0x04DF3F, 0x04DF42, 0x04DF45 };

            room_sprites[81] = new int[] { 0x04DF4D, 0x04DF50 };

            room_sprites[82] = new int[] { 0x04DF55, 0x04DF58, 0x04DF5B };

            room_sprites[83] = new int[] { 0x04DF60, 0x04DF63, 0x04DF66, 0x04DF69, 0x04DF6C, 0x04DF6F, 0x04DF72, 0x04DF75, 0x04DF78, 0x04DF7B, 0x04DF7E, 0x04DF81, 0x04DF84 };

            room_sprites[84] = new int[] { 0x04DF89, 0x04DF8C, 0x04DF8F, 0x04DF92, 0x04DF95, 0x04DF98, 0x04DF9B, 0x04DF9E };

            room_sprites[85] = new int[] { 0x04DFA6, 0x04DFA9 };

            room_sprites[86] = new int[] { 0x04DFB7, 0x04DFBA, 0x04DFBD, 0x04DFC0, 0x04DFC6, 0x04DFC9, 0x04DFCC, 0x04DFD2, 0x04DFCF };

            room_sprites[87] = new int[] { 0x04DFD7, 0x04DFDA, 0x04DFDD, 0x04DFE0, 0x04DFE3, 0x04DFE6, 0x04DFEC, 0x04DFEF, 0x04DFF2, 0x04DFF5, 0x04DFF8, 0x04DFFB, 0x04DFFE, 0x04E001 };

            room_sprites[88] = new int[] { 0x04E009, 0x04E00C, 0x04E012, 0x04E015, 0x04E01B, 0x04E01E, 0x04E021 };

            room_sprites[89] = new int[] { 0x04E026, 0x04E029, 0x04E032, 0x04E038, 0x04E03B, 0x04E03E, 0x04E041, 0x04E044, 0x04E047, 0x04E035 };

            room_sprites[91] = new int[] { 0x04E057, 0x04E05A, 0x04E05D, 0x04E060 };//remove some sprite for lag//0x04E063,0x04E066,0x04E069};

            room_sprites[92] = new int[] { };//canon rooms gtower

            room_sprites[93] = new int[] { 0x04E07F, 0x04E082, 0x04E085, 0x04E088, 0x04E08B, 0x04E091, 0x04E094, 0x04E097, 0x04E0A3, 0x04E09A, 0x04E09D, 0x04E0A0, 0x04E08E };

            room_sprites[94] = new int[] { 0x04E0AB, 0x04E0AE, 0x04E0B1, 0x04E0B4 };

            room_sprites[95] = new int[] { 0x04E0B9, 0x04E0BC, 0x04E0BF };

            room_sprites[96] = new int[] { 0x04E0C4 };

            room_sprites[97] = new int[] { 0x04E0C9, 0x04E0CC, 0x04E0CF };

            room_sprites[98] = new int[] { 0x04E0D4, 0x04E0D7, 0x04E0DA };

            room_sprites[99] = new int[] { 0x04E0E2, 0x04E0DF };

            room_sprites[100] = new int[] { 0x04E0E7, 0x04E0ED, 0x04E0F0, 0x04E0F3, 0x04E0F6, 0x04E0F9 };

            room_sprites[101] = new int[] { 0x04E110, 0x04E113, 0x04E116, 0x04E119, 0x04E11C };

            room_sprites[102] = new int[] { 0x04E121, 0x04E127, 0x04E12A, 0x04E133, 0x04E136, 0x04E139, 0x04E13C, 0x04E142 };

            room_sprites[103] = new int[] { 0x04E14A, 0x04E14D, 0x04E150, 0x04E153, 0x04E156, 0x04E159, 0x04E15C, 0x04E15F, 0x04E162 };

            room_sprites[104] = new int[] { 0x04E173, 0x04E179, 0x04E17C };

            room_sprites[106] = new int[] { 0x04E181, 0x04E184, 0x04E187, 0x04E18A, 0x04E18D, 0x04E190 };

            room_sprites[107] = new int[] { 0x04E19B, 0x04E19E, 0x04E1A1, 0x04E1A7, 0x04E1AA, 0x04E1AD, 0x04E1B0, 0x04E1B3, 0x04E1B6, 0x04E1B9, 0x04E1BC };

            room_sprites[109] = new int[] { 0x04E1D2, 0x04E1D5, 0x04E1D8, 0x04E1DB, 0x04E1DE, 0x04E1E1, 0x04E1E4, 0x04E1E7, 0x04E1EA };

            room_sprites[110] = new int[] { 0x04E1EF, 0x04E1F2, 0x04E1F5, 0x04E1F8, 0x04E1FB };

            room_sprites[113] = new int[] { 0x04E200, 0x04E203 };

            room_sprites[114] = new int[] { 0x04E20B, 0x04E211 };

            room_sprites[115] = new int[] { 0x04E216, 0x04E219, 0x04E21C, 0x04E21F, 0x04E222, 0x04E225 };

            room_sprites[116] = new int[] { 0x04E22D, 0x04E230, 0x04E233, 0x04E236, 0x04E239, 0x04E23C, 0x04E23F, 0x04E242 };

            room_sprites[117] = new int[] { 0x04E247, 0x04E24A, 0x04E24D, 0x04E250, 0x04E253, 0x04E256, 0x04E25F, 0x04E262 };

            room_sprites[118] = new int[] { 0x04E26A, 0x04E26D, 0x04E270, 0x04E273, 0x04E279 };

            room_sprites[119] = new int[] { 0x04E27E, 0x04E28A, 0x04E28D };

            room_sprites[123] = new int[] { 0x04E292, 0x04E295, 0x04E298, 0x04E29B, 0x04E29E, 0x04E2A1, 0x04E2A7, 0x04E2AA, 0x04E2AD, 0x04E2B0 };

            room_sprites[124] = new int[] { 0x04E2B5, 0x04E2B8, 0x04E2BB, 0x04E2BE, 0x04E2C1, 0x04E2C4 };

            room_sprites[125] = new int[] { 0x04E2D8, 0x04E2DB, 0x04E2E1, 0x04E2E4, 0x04E2EA, 0x04E2DE, 0x04E2E7, 0x04E2CC, 0x04E2CF, 0x04E2D2, 0x04E2D5, 0x04E2DE, 0x04E2E7 };

            room_sprites[126] = new int[] { 0x04E2F2, 0x04E2F5, 0x04E2FE, 0x04E301 };

            room_sprites[127] = new int[] { /* 0x04E306, 0x04E309, 0x04E30C, 0x04E30F, 0x04E312, 0x04E315, 0x04E318, 0x04E31B */ };

            room_sprites[128] = new int[] { 0x04E323, 0x04E326 };

            room_sprites[129] = new int[] { 0x04E32E, 0x04E331 };

            room_sprites[130] = new int[] { 0x04E336, 0x04E339, 0x04E33C };

            room_sprites[131] = new int[] { 0x04E341, 0x04E344, 0x04E347, 0x04E34A, 0x04E34D, 0x04E350, 0x04E353, 0x04E356, 0x04E359, 0x04E35C };

            room_sprites[132] = new int[] { 0x04E361, 0x04E364, 0x04E367, 0x04E36A, 0x04E36D, 0x04E370, 0x04E373 };

            room_sprites[133] = new int[] { 0x04E378, 0x04E37B, 0x04E37E, 0x04E381, 0x04E384, 0x04E387, 0x04E38A, 0x04E38D, 0x04E390, 0x04E393 };

            room_sprites[135] = new int[] { 0x04E39A, 0x04E39D, 0x04E3A0, 0x04E3A3, 0x04E3B2, 0x04E3B5, 0x04E3B8, 0x04E3BE, 0x04E3A6 };

            room_sprites[139] = new int[] { 0x04E3D4, 0x04E3D7, 0x04E3DA, 0x04E3DD, 0x04E3E0 };

            room_sprites[140] = new int[] { 0x04E3F7, 0x04E3FA, 0x04E3FD, 0x04E400, 0x04E406, 0x04E409, 0x04E40F, 0x04E40C, 0x04E403 };

            room_sprites[141] = new int[] { 0x04E41A, 0x04E41D, 0x04E420, 0x04E423, 0x04E426, 0x04E42C, 0x04E42F, 0x04E432, 0x04E435, 0x04E438, 0x04E43B, 0x04E417 };

            room_sprites[142] = new int[] { 0x04E443, 0x04E446, 0x04E449, 0x04E44C, 0x04E44F, 0x04E452, 0x04E455 };

            room_sprites[145] = new int[] { 0x04E462, 0x04E468, 0x04E46B, 0x04E46E, 0x04E471, 0x04E465 };

            room_sprites[146] = new int[] { 0x04E47C, 0x04E47F, 0x04E482, 0x04E485, 0x04E488, 0x04E48E, 0x04E491, 0x04E494, 0x04E497 };

            room_sprites[147] = new int[] { 0x04E49C, 0x04E49F, 0x04E4A2, 0x04E4A5, 0x04E4A8, 0x04E4AB, 0x04E4AE, 0x04E4B1 };

            room_sprites[149] = new int[] { 0x04E4B6, 0x04E4B9, 0x04E4BC, 0x04E4BF };

            room_sprites[152] = new int[] { 0x04E4DD, 0x04E4E0, 0x04E4E3, 0x04E4E6, 0x04E4E9 };

            room_sprites[150] = new int[] { };

            room_sprites[151] = new int[] { 0x04E4D8 };

            room_sprites[153] = new int[] { 0x04E4EE, 0x04E4F1, 0x04E4F4, 0x04E4F7, 0x04E4FD, 0x04E500, 0x04E503, 0x04E506, 0x04E509, 0x04E50C };

            room_sprites[155] = new int[] { 0x04E51A, 0x04E51D, 0x04E520, 0x04E523, 0x04E526, 0x04E529, 0x04E52C, 0x04E52F, 0x04E532, 0x04E535 };

            room_sprites[156] = new int[] { 0x04E53A, 0x04E53D, 0x04E540, 0x04E543, 0x04E546, 0x04E549 };

            room_sprites[157] = new int[] { 0x04E554, 0x04E557, 0x04E55A, 0x04E55D, 0x04E560, 0x04E563, 0x04E566, 0x04E569 };

            room_sprites[158] = new int[] { 0x04E56E, 0x04E571, 0x04E574, 0x04E577 };

            room_sprites[159] = new int[] { 0x04E58B, 0x04E58E }; // Might cause crashes -- 0x04E57F, 0x04E582, 0x04E585, 0x04E588, 0x04E58B, 0x04E58E

            room_sprites[160] = new int[] { 0x04E593, 0x04E596, 0x04E599 };

            room_sprites[161] = new int[] { 0x04E5A1, 0x04E5A4, 0x04E5A7, 0x04E5AA, 0x04E5AD, 0x04E5B0, 0x04E5B3, 0x04E5B6 };

            room_sprites[165] = new int[] { 0x04E5C8, 0x04E5CB, 0x04E5CE, 0x04E5D1, 0x04E5D4, 0x04E5D7, 0x04E5DA, 0x04E5DD, 0x04E5E6, 0x04E5E9 };

            room_sprites[166] = new int[] { /* 0x04E5EE, 0x04E5F1 */ };

            room_sprites[167] = new int[] { 0x04E5F6, 0x04E5F9 };

            room_sprites[168] = new int[] { 0x04E5FE, 0x04E601, 0x04E604, 0x04E607, 0x04E60A };

            room_sprites[169] = new int[] { 0x04E60F, 0x04E612, 0x04E621, 0x04E624, 0x04E615, 0x04E618, 0x04E61B, 0x04E61E };

            room_sprites[170] = new int[] { 0x04E629, 0x04E62C, 0x04E62F, 0x04E632, 0x04E635, 0x04E638 };

            room_sprites[171] = new int[] { 0x04E640, 0x04E643, 0x04E646, 0x04E649, 0x04E64C, 0x04E64F, 0x04E652 };

            room_sprites[174] = new int[] { 0x04E65C, 0x04E65F };

            room_sprites[175] = new int[] { };

            room_sprites[176] = new int[] { 0x04E669, 0x04E66C, 0x04E66F, 0x04E672, 0x04E675, 0x04E678, 0x04E67B, 0x04E67E, 0x04E681, 0x04E684, 0x04E687, 0x04E68D, 0x04E690 };

            room_sprites[177] = new int[] { 0x04E695, 0x04E698, 0x04E69B, 0x04E69E, 0x04E6A1, 0x04E6A4, 0x04E6A7, 0x04E6AA, 0x04E6AD, 0x04E6B0 };

            room_sprites[178] = new int[] { 0x04E6B5, 0x04E6B8, 0x04E6BB, 0x04E6BE, 0x04E6C1, 0x04E6C4, 0x04E6C7, 0x04E6CA, 0x04E6CD, 0x04E6D0, 0x04E6D3, 0x04E6D6, 0x04E6D9, 0x04E6DC };

            room_sprites[179] = new int[] { 0x04E6E1, 0x04E6E4, 0x04E6E7, 0x04E6EA, 0x04E6ED };

            room_sprites[185] = new int[] { }; //firesnake gfx

            room_sprites[182] = new int[] { 0x04E6FD, 0x04E700, 0x04E709, 0x04E70C, 0x04E715, 0x04E718 };

            room_sprites[183] = new int[] { 0x04E71D, 0x04E720 };

            room_sprites[184] = new int[] { 0x04E725, 0x04E728, 0x04E72B, 0x04E72E, 0x04E731, 0x04E734 };

            room_sprites[181] = new int[] { };

            room_sprites[185] = new int[] { };

            room_sprites[197] = new int[] { };

            room_sprites[213] = new int[] { };

            room_sprites[214] = new int[] { };

            room_sprites[228] = new int[] { };

            room_sprites[186] = new int[] { 0x04E73E, 0x04E741, 0x04E744, 0x04E747, 0x04E74A, 0x04E74D, 0x04E750 };

            room_sprites[187] = new int[] { 0x04E755, 0x04E758, 0x04E75B, 0x04E75E, 0x04E761, 0x04E764, 0x04E76A, 0x04E76D, 0x04E770, 0x04E773, 0x04E767 };

            room_sprites[188] = new int[] { 0x04E77B, 0x04E77E, 0x04E781, 0x04E784, 0x04E78A, 0x04E78D, 0x04E790, 0x04E799, 0x04E778, 0x04E787, 0x04E793, 0x04E796 };

            room_sprites[190] = new int[] { 0x04E7A0, 0x04E7A6, 0x04E7A9, 0x04E7AC, 0x04E7AF, 0x04E7B2 };

            room_sprites[192] = new int[] { 0x04E7BF, 0x04E7C2, 0x04E7C5, 0x04E7C8, 0x04E7CE, 0x04E7D1, 0x04E7D4, 0x04E7D7 };

            room_sprites[193] = new int[] { 0x04E7DF, 0x04E7E2, 0x04E7E5, 0x04E7E8, 0x04E7EE, 0x04E7F4, 0x04E7F7, 0x04E7FA, 0x04E7F1, 0x04E7EB, 0x04E800 };

            room_sprites[194] = new int[] { 0x04E80B, 0x04E80E, 0x04E811, 0x04E814, 0x04E81A, 0x04E817, 0x04E808, 0x04E805 };

            room_sprites[195] = new int[] { 0x04E81F, 0x04E831, 0x04E834 };

            room_sprites[196] = new int[] { 0x04E845, 0x04E848, 0x04E84B, 0x04E84E, 0x04E851, 0x04E854 };

            room_sprites[201] = new int[] { 0x04E8A1, 0x04E8A4, 0x04E8A7 };

            room_sprites[203] = new int[] { 0x04E8AC, 0x04E8B5, 0x04E8B8, 0x04E8BB, 0x04E8BE, 0x04E8C1, 0x04E8C4, 0x04E8C7, 0x04E8CA, 0x04E8CD, 0x04E8B2, 0x04E8AF };

            room_sprites[204] = new int[] { 0x04E8D2, 0x04E8D5, 0x04E8DB, 0x04E8DE, 0x04E8E1, 0x04E8EA, 0x04E8ED, 0x04E8F0, 0x04E8F3, 0x04E8F6, 0x04E8F9, 0x04E8D8, 0x04E8E4, 0x04E8E7 };

            room_sprites[206] = new int[] { 0x04E8FE, 0x04E901, 0x04E907, 0x04E90A, 0x04E90D, 0x04E910, 0x04E913 };

            room_sprites[208] = new int[] { 0x04E918, 0x04E91B, 0x04E91E, 0x04E921, 0x04E924, 0x04E927, 0x04E92A, 0x04E92D, 0x04E930, 0x04E933, 0x04E936 };

            room_sprites[209] = new int[] { 0x04E93B, 0x04E93E, 0x04E941, 0x04E944, 0x04E947, 0x04E94A, 0x04E94D, 0x04E950 };

            room_sprites[210] = new int[] { 0x04E955, 0x04E958, 0x04E95B, 0x04E95E, 0x04E961, 0x04E964, 0x04E967, 0x04E96A, 0x04E96D, 0x04E970 };

            room_sprites[216] = new int[] { 0x04E991, 0x04E994, 0x04E997, 0x04E99A, 0x04E99D, 0x04E9A0, 0x04E9A3, 0x04E9A6, 0x04E9A9, 0x04E9AC, 0x04E9AF };

            room_sprites[217] = new int[] { 0x04E9B7, 0x04E9BA, 0x04E9BD, 0x04E9B4 };

            room_sprites[218] = new int[] { 0x04E9C2, 0x04E9C5 };

            room_sprites[219] = new int[] { 0x04E9CA, 0x04E9CD, 0x04E9D0, 0x04E9D6, 0x04E9D3, 0x04E9DC, 0x04E9D9 };

            room_sprites[220] = new int[] { 0x04E9E4, 0x04E9E7, 0x04E9EA, 0x04E9ED, 0x04E9F0, 0x04E9F3, 0x04E9FF, 0x04E9E1, 0x04E9F6, 0x04E9F9, 0x04E9FC };

            room_sprites[223] = new int[] { 0x04EA0F, 0x04EA12 };

            room_sprites[224] = new int[] { 0x04EA17, 0x04EA1A, 0x04EA1D, 0x04EA20 };

            room_sprites[232] = new int[] { 0x04EA8D, 0x04EA90, 0x04EA93, 0x04EA96, };

            room_sprites[238] = new int[] { 0x04EAA5, 0x04EAA8, 0x04EAAB, 0x04EAAE, 0x04EAB1, };

            room_sprites[239] = new int[] { 0x04EAB6, 0x04EAB9, 0x04EABC, };

            room_sprites[249] = new int[] { 0x04EB13, 0x04EB16, 0x04EB19, 0x04EB1C, };

            room_sprites[240] = new int[] { };

            room_sprites[235] = new int[] { };

            room_sprites[251] = new int[] { };

            room_sprites[286] = new int[] { };

            room_sprites[254] = new int[] { 0x04EB4A, 0x04EB4D, 0x04EB50, 0x04EB53, 0x04EB56, };

            room_sprites[263] = new int[] { 0x04EB8C, 0x04EB8F };

            room_sprites[264] = new int[] { 0x04EB94, 0x04EB97, 0x04EB9A, 0x04EB9D, };

            room_sprites[267] = new int[] { 0x04EBBE };

            room_sprites[268] = new int[] { /* 0x04EBC3, 0x04EBC6, 0x04EBC9, 0x04EBCC, 0x04EBCF, 0x04EBD2, 0x04EBD5, 0x04EBD8 */ };

            room_sprites[269] = new int[] { 0x04EBDD, 0x04EBE0, };

            room_sprites[291] = new int[] { 0x04EC6F, 0x04EC72, 0x04EC75, 0x04EC78, };
        }
    }
}
