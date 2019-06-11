using Tanks.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;


namespace Tanks
{
    public class MainViewModel : ViewModel
    {
        public EntityCollection EntityCollection { get; set; }

        public Tank PlayerA { get; private set; }
        public Tank PlayerB { get; private set; }

        private DispatcherTimer ClockTimer;

        public MainViewModel()
        {
            EntityCollection = new EntityCollection();

            ResetGame();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            ClockTimer = new DispatcherTimer();
            ClockTimer.Tick += (o, a) => EntityCollection.ExecuteEntities();
            ClockTimer.Interval = TimeSpan.FromMilliseconds(40);
            ClockTimer.IsEnabled = true;
        }

        public void ResetGame()
        {
            EntityCollection.Clear();

            PlayerA = new Tank(new EntityPosition(525, 525), Player.PlayerA) { Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#8FD354")), Orientation = EntityOrientation.Up };
            EntityCollection.Add(PlayerA);

            //PlayerB = new Tank(new EntityPosition(1000, 325), Player.PlayerB) { Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4A30DE")), Orientation = EntityOrientation.Left };
            //EntityCollection.Add(PlayerB);

            AddWalls();
        }

        private void AddWalls()
        {
            // Outer Walls
            for (int i = 0; i <= 1070; i += 30)
            {
                EntityCollection.Add(new Wall(new EntityPosition(i, 0), 30, 30));
                EntityCollection.Add(new Wall(new EntityPosition(0, i+30), 30, 30));
                EntityCollection.Add(new Wall(new EntityPosition(1050, i + 30), 30, 30));
                //EntityCollection.Add(new Wall(new EntityPosition(990 - i, 700), 30, 30));
            }


            // Vertical Obstacle Left
            EntityCollection.Add(new Wall(new EntityPosition(170, 230), 30, 30));
            EntityCollection.Add(new Wall(new EntityPosition(170, 260), 30, 30));
            EntityCollection.Add(new Wall(new EntityPosition(170, 290), 30, 30));
            EntityCollection.Add(new Wall(new EntityPosition(170, 310), 30, 30));
            EntityCollection.Add(new Wall(new EntityPosition(170, 340), 30, 30));
            EntityCollection.Add(new Wall(new EntityPosition(170, 370), 30, 30));
            EntityCollection.Add(new Wall(new EntityPosition(170, 400), 30, 30));
            EntityCollection.Add(new Wall(new EntityPosition(140, 230), 30, 30));
            EntityCollection.Add(new Wall(new EntityPosition(170, 230), 30, 30));
            EntityCollection.Add(new Wall(new EntityPosition(140, 430), 30, 30));
            EntityCollection.Add(new Wall(new EntityPosition(170, 430), 30, 30));
        

            // Vertical Obstacle Right
            EntityCollection.Add(new Wall(new EntityPosition(900, 230), 30, 200));
            EntityCollection.Add(new Wall(new EntityPosition(900, 220), 60, 30));
            EntityCollection.Add(new Wall(new EntityPosition(900, 430), 60, 30));

            // Horizontal Obstacles
            EntityCollection.Add(new Wall(new EntityPosition(170, 100), 80, 30));
            EntityCollection.Add(new Wall(new EntityPosition(170, 570), 80, 30));
            EntityCollection.Add(new Wall(new EntityPosition(830, 100), 80, 30));
            EntityCollection.Add(new Wall(new EntityPosition(830, 570), 80, 30));

            // Inner Square Blocks
            EntityCollection.Add(new Wall(new EntityPosition(280, 325), 30, 30));
            EntityCollection.Add(new Wall(new EntityPosition(770, 325), 30, 30));

            // Wall Square Blocks
            EntityCollection.Add(new Wall(new EntityPosition(525, 30), 30, 30));
            EntityCollection.Add(new Wall(new EntityPosition(525, 620), 30, 30));

            // Corner Blocks Left
            EntityCollection.Add(new Wall(new EntityPosition(390, 130), 80, 30));
            EntityCollection.Add(new Wall(new EntityPosition(390, 130), 30, 60));
            EntityCollection.Add(new Wall(new EntityPosition(390, 520), 80, 30));
            EntityCollection.Add(new Wall(new EntityPosition(390, 490), 30, 60));

            // Corner Blocks Right
            EntityCollection.Add(new Wall(new EntityPosition(630, 130), 80, 30));
            EntityCollection.Add(new Wall(new EntityPosition(680, 130), 30, 60));
            EntityCollection.Add(new Wall(new EntityPosition(630, 520), 80, 30));
            EntityCollection.Add(new Wall(new EntityPosition(680, 490), 30, 60));
        }
    }
}
