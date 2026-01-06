using AquaAvgFramework.Animation;
using AquaAvgFramework.Animation.Common;
using AquaAvgFramework.Animation.Switch;
using AquaAvgFramework.Controls;
using AquaAvgFramework.Customize;
using AquaAvgFramework.GameElements.Blocks;
using AquaAvgFramework.GameElements.Events;
using AquaAvgFramework.Pools;
using AquaAvgFramework.Spirits;
using AquaAvgFramework.StoryLineComponents;
using System.Text.Json.Serialization;

namespace AquaAvgFramework.GameElements
{
    [JsonDerivedType(typeof(Alert), "Alert")]
    [JsonDerivedType(typeof(AnimationEvent), "AnimationEvent")]
    [JsonDerivedType(typeof(Avatar), "Avatar")]
    [JsonDerivedType(typeof(BackgroundChangeEvent), "BackgroundChangeEvent")]
    [JsonDerivedType(typeof(BeginStoryLine), "BeginStoryLine")]
    [JsonDerivedType(typeof(BitImage), "BitImage")]
    [JsonDerivedType(typeof(ChoiceDialogue), "ChoiceDialogue")]
    [JsonDerivedType(typeof(EndStoryLine), "EndStoryLine")]
    [JsonDerivedType(typeof(PlainDialogue), "PlainDialogue")]
    [JsonDerivedType(typeof(SwitchContextEvent), "SwitchContextEvent")]
    [JsonDerivedType(typeof(Text), "Text")]
    [JsonDerivedType(typeof(ValueEvent), "ValueEvent")]
    [JsonDerivedType(typeof(MusicPool), "MusicPool")]
    public interface IGameElement
    {
        /// <summary>
        /// The ID of current element
        /// </summary>
        public int ElementId { get; set; }

        /// <summary>
        /// The event when the object was set off
        /// </summary>
        /// <param name="gamePanel"></param>
        public void Enter(GamePanel gamePanel);
    }

    public interface IBlocking : IAnimationExecutable;
}