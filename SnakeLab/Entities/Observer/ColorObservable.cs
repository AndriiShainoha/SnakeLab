using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace SnakeLab.Entities.Observer
{
    class ColorObservable : IObservable
    {
        private Color _Color = Colors.Black;

        public Color Color
        {
            get
            {
                return _Color;
            }
            set
            {
                _Color = value;
                Notify();
            }
        }

        private List<IObserver> _observers = new List<IObserver>();

        public void Notify()
        {
            _observers.ToList().ForEach(o => o.ColorChanged(Color));
        }

        public void Register(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unregister(IObserver observer)
        {
            _observers.Remove(observer);
        }
    }
}
