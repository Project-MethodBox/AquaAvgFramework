using AquaAvgFramework.Animation;
using AquaAvgFramework.GameElements;
using AquaAvgFramework.StoryLineComponents;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace AquaAvgFramework.Controls
{
    /// <summary>
    /// GamePanel.xaml 的交互逻辑
    /// </summary>
    public partial class GamePanel
    {
        public List<StoryLine>? StoryLines;
        private List<IAnimationExecutable> _elementBuffer = new();
        internal StoryLine? CurrentStoryLine;
        internal MediaPlayer MediaPlayer = new();
        private readonly Dispatcher _currentDispatcher;
        private int _timeStamp;
        private IGameElement? _nextElement;
        private bool _isBlocking, _isApplyAnimation, _isSpirit;

        public GamePanel()
        {
            InitializeComponent();

            // Catch current dispatcher
            _currentDispatcher = Dispatcher.CurrentDispatcher;
        }

        private void HandleStory(object sender, MouseButtonEventArgs e)
        {
            if (e.Timestamp == _timeStamp) return;
            _timeStamp = e.Timestamp;

            MoveNext();
        }

        private void GamePanel_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (StoryLines is null || StoryLines.Count == 0)
            {
                return;
            }

            // Find main line
            CurrentStoryLine = StoryLines.First(line => line.ElementId == 0);
            MoveNext();
        }

        private void MoveNext()
        {
            // Display control _instance
            do
            {
                // Polling buffer
                for (int i = 0; i < _elementBuffer.Count; i++)
                {
                    if (_elementBuffer[i].ExitContext is null)
                    {
                        _elementBuffer[i].RemoveFromGrid(this);
                        _elementBuffer.RemoveAt(i);
                    }
                    else if (CurrentStoryLine!.ElementId == _elementBuffer[i].ExitContext!.ExitStoryLineId &&
                        _nextElement!.ElementId == _elementBuffer[i].ExitContext!.ExitElementId)
                    {
                        _elementBuffer[i].Exit(this);
                        _elementBuffer.RemoveAt(i);
                    }
                }

                if (_isApplyAnimation)
                {
                    // Set a buffer pool in order to display full of effect
                    var beforeElement = ((IAnimationExecutable)_nextElement!);
                    if (beforeElement.EnterContext is not null)
                    {
                        var maxDisplayTime = 0;
                        beforeElement.ExitContext?.ExitAnimations.ForEach(a =>
                            maxDisplayTime = maxDisplayTime < a.DurationMillisecond
                                ? a.DurationMillisecond
                                : maxDisplayTime);

                        // Delay for buffer
                        Task.Run(() =>
                        {
                            Thread.Sleep(maxDisplayTime);
                            _currentDispatcher.Invoke(() =>
                            {
                                beforeElement.RemoveFromGrid(this);
                            });
                        });
                    }
                    else if (!_isSpirit)
                    {
                        beforeElement.RemoveFromGrid(this);
                    }
                    beforeElement.Exit(this);
                }

                // Case spirit, insert into buffer list
                if (_isSpirit) _elementBuffer.Add((IAnimationExecutable)_nextElement!);

                _nextElement = CurrentStoryLine!.GetNextElement();

                // Reset flags
                _isApplyAnimation = _isBlocking = _isSpirit = false;

                // Set corresponding flags
                _nextElement.GetType().GetCustomAttributes(false).ToList().ForEach(attr =>
                {
                    switch (attr)
                    {
                        case Attributes.ApplyAnimationAttribute:
                            _isApplyAnimation = true;
                            break;
                        case Attributes.BlockExecutionAttribute:
                            _isBlocking = true;
                            break;
                        case Attributes.LimitExecutionAttribute:
                            _isSpirit = true;
                            break;
                    }
                });

                _nextElement?.Enter(this);
            } while (_nextElement is not null && !_isBlocking);
        }
    }
}