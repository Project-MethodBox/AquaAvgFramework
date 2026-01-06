using AquaAvgFramework.GameElements;
using AquaAvgFramework.GameElements.Blocks;
using AquaAvgFramework.GameElements.Events;
using AquaAvgFramework.Global;

namespace AquaAvgFramework.StoryLineComponents;


public interface IStoryLineComponent : IGameElement { }

/// <summary>
/// Representing a linear storage object that concatenates all story nodes
/// </summary>
[Serializable]
public class StoryLine
{
    private int _pivot = 0;
    private int _timexMs = 0;
    private List<IGameElement> _elementBuffer = new();

    /// <summary>
    /// Append a new instance to current <code>StoryLine</code>
    /// </summary>
    /// <param name="gameElement">An instance implementing the <code>IGameElement</code> interface</param>
    public void Add(IGameElement gameElement) => GameElements!.Add(gameElement);

    /// <summary>
    /// Remove an instance from current <code>StoryLine</code>
    /// </summary>
    /// <param name="gameElement">An instance implementing the <code>IGameElement</code> interface</param>
    /// <returns>oo00Ooo0O0O0ooo0OoO0oo</returns>
    public bool Remove(IGameElement gameElement) => GameElements!.Remove(gameElement);

    /// <summary>
    /// Append a range of new instance to current <code>StoryLine</code>
    /// </summary>
    /// <param name="gameElements"></param>
    public void AddRange(IList<IGameElement> gameElements) => GameElements!.AddRange(gameElements);

    public StoryLine()
    {
        GameElements = [];
    }

    public IGameElement GetNextElement(IGameElement? insertElement = null)
    {
        //MessageBox.Show("Stack trace arrived!");
        if (DateTime.Now.Millisecond == _timexMs) return null!;
        _timexMs = DateTime.Now.Millisecond;
        _pivot++;

        if (_pivot >= 2 && GameElements![_pivot - 2].GetType() == typeof(ChoiceDialogue) && _pivot >= GameElements.Count)
        {
            var choiceDialogue = (ChoiceDialogue)GameElements![_pivot - 2];
            var choice = ValueManager.Shared.GetValue("%Selected%");
            var lastElement = choiceDialogue.ChoiceResults![choice].NextElement!;
            if (lastElement.GetType() == typeof(EndStoryLine)) _pivot = 0;
            return lastElement;
        }
        if (GameElements![_pivot - 1].GetType() == typeof(SwitchContextEvent))
        {
            var lastContext = ((SwitchContextEvent)GameElements![_pivot - 1]).GetResult();
            if (lastContext.GetType() == typeof(EndStoryLine)) _pivot = 0;
            return lastContext;
        }

        if (GameElements is null || _pivot > GameElements.Count)
        {
            throw new IndexOutOfRangeException("Game elements is empty or out of range," +
                                               "please check the elements set of current story line.");
        }

        // Reset pivot
        var lastGameElement = GameElements![_pivot - 1];
        if (lastGameElement.GetType() == typeof(EndStoryLine)) _pivot = 0;

        Thread.Sleep(1);
        return lastGameElement;
    }


    public int ElementId { get; set; }
    public List<IGameElement>? GameElements { get; set; } = null;
}