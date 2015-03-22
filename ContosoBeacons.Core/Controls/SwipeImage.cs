using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContosoBeacons.Controls
{
    public class SwipedImage : Image
    {
        public event EventHandler Swiped;
        public void OnSwiped()
        {
            if (Swiped != null)
                Swiped(null, null);
        }
    }
}
