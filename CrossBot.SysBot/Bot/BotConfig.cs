﻿using System;
using SysBot.Base;

namespace CrossBot.SysBot
{
    /// <summary>
    /// Serialized configuration for the <see cref="Bot"/>, containing overall permissions and setup parameters.
    /// </summary>
    [Serializable]
    public sealed record BotConfig : SwitchConnectionConfig
    {
        /// <summary> When enabled, the bot will accept commands from users. </summary>
        public bool AcceptingCommands { get; set; } = true;

        /// <summary> Skips creating bots when the program is started; helpful for testing integrations. </summary>
        public bool SkipConsoleBotCreation { get; set; }

        /// <summary> Offset the items are injected at. This should be the player inventory slot you have currently selected in-game. </summary>
        public uint Offset { get; set; } = 0xABC25840;

        /// <summary> When enabled, the Bot will not allow RAM edits if the player's item metadata is invalid. </summary>
        /// <remarks> Only disable this as a last resort, and you have corrupted your item metadata through other means. </remarks>
        public bool RequireValidInventoryMetadata { get; set; } = true;

        /// <summary> Require the players to <see cref="IslandState.Arrive(string)"/> prior to being able to accept commands. </summary>
        public bool RequireJoin { get; set; } = true;

        /// <summary> Maximum amount of people that can visit the bot at a time. </summary>
        public int MaxVisitorCount { get; set; } = 7;

        public DropBotConfig DropConfig { get; set; } = new();

        public FieldItemConfig FieldItemConfig { get; set; } = new();

        public ViewStateConfig ViewConfig { get; set; } = new();

        /// <summary> When enabled, users in Discord can request the bot to pick up items (spamming Y a <see cref="DropBotConfig.PickupCount"/> times). </summary>
        public bool AllowClean { get; set; }

        /// <summary>
        /// When enabled, users in Discord can request the bot to validate the inventory offset.
        /// </summary>
        /// <remarks>
        /// If <see cref="RequireValidInventoryMetadata"/> is enabled and validation fails, the bot will set <see cref="AcceptingCommands"/> to false.
        /// </remarks>
        public bool AllowValidate { get; set; } = true;

        /// <summary>
        /// Tries to restart the bot if it has crashed.
        /// </summary>
        public bool RestartOnCrash { get; set; } = true;

        /// <summary>
        /// Amount of time to try restarting the bot in the event of it crashing.
        /// </summary>
        public int MaximumRestarts { get; set; } = 20;

        /// <summary>
        /// Amount of up-time (in seconds) to determine if the bot is running without fault.
        /// </summary>
        public int UptimeThreshold { get; set; } = 60;

        /// <summary>
        /// Maximum amount of data to push over the connection. Leave at 0 or negative to not override the default connection maximums from SysBot.NET
        /// </summary>
        public int MaximumTransferSize { get; set; } = -1;
    }
}
