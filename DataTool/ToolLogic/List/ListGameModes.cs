﻿using System;
using System.Collections.Generic;
using DataTool.DataModels;
using DataTool.Flag;
using TankLib.STU.Types;
using static DataTool.Program;
using static DataTool.Helper.STUHelper;
using static DataTool.Helper.Logger;

namespace DataTool.ToolLogic.List {
    [Tool("list-gamemodes", Description = "List game modes", IsSensitive = true, TrackTypes = new ushort[] {0xC5}, CustomFlags = typeof(ListFlags))]
    public class ListGameModes : JSONTool, ITool {
        public void IntegrateView(object sender) {
            throw new NotImplementedException();
        }

        public List<GameMode> GetGameModes() {
            List<GameMode> gameModes = new List<GameMode>();
            foreach (var guid in TrackedFiles[0xC5]) {
                STUGameMode gameMode = GetInstance<STUGameMode>(guid);
                if (gameMode == null) continue;

                gameModes.Add(new GameMode(gameMode));
            }

            return gameModes;
        }

        public void Parse(ICLIFlags toolFlags) {
            List<GameMode> gameModes = GetGameModes();
            
            if (toolFlags is ListFlags flags)
                if (flags.JSON) {
                    ParseJSON(gameModes, flags);
                    return;
                }


            foreach (GameMode gameMode in gameModes) {
                if (string.IsNullOrWhiteSpace(gameMode.DisplayName)) continue;
                Log(gameMode.DisplayName);
            }
        }
    }
}