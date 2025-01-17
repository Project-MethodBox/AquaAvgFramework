using AquaAvgFramework.Controls;
using AquaAvgFramework.Global;

namespace AquaAvgFramework.GameElements.Events
{
    public class ValueEvent : IGameElement
    {
        public int ElementId { get; set; }
        public (string, string) NameCommand { get; set; }

        public void Enter(GamePanel _)
        {
            // Unpack params
            var (name, updateCommand) = NameCommand;
            var nameCommandArray = updateCommand.Split(' ');
            switch (nameCommandArray[0])
            {
                case "set":
                    {
                        if (!ValueManager.Shared.ReSetValue(name, Convert.ToInt32(nameCommandArray[1])))
                        {
                            ValueManager.Shared.RegisterValue(name, Convert.ToInt32(nameCommandArray[1]));
                        }

                        break;
                    }
                case "update":
                    {
                        var nameValue = ValueManager.Shared.GetValue(name);
                        nameValue += Convert.ToInt32(nameCommandArray[1]);
                        ValueManager.Shared.ReSetValue(name, nameValue);
                        break;
                    }
                default:
                    throw new NotImplementedException("This parameter has not been implemented yet." +
                                                      "Please check the predicate verb of the operation.");
            }
        }
    }
}