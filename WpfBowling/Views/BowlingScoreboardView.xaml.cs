using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfBowling.Views
{
    /// <summary>
    /// Interaction logic for BowlingScoreboardView.xaml
    /// </summary>
    public partial class BowlingScoreboardView : UserControl
    {
        public BowlingScoreboardView()
        {
            InitializeComponent();
        }

        //moving the text box forward
        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            bool strike = false;

            if (e.Key != Key.Tab && e.Key != Key.Back)
            {
                //a MoveFocus request that places focus back on the first text box
                FocusNavigationDirection focusDirection = FocusNavigationDirection.Right;

                TraversalRequest request = new TraversalRequest(focusDirection);

                UIElement elementWithFocus = Keyboard.FocusedElement as UIElement;

                if (elementWithFocus != null)
                {
                    elementWithFocus.MoveFocus(request);
                    if (e.Key == Key.X)
                    {
                        elementWithFocus = Keyboard.FocusedElement as UIElement;
                        if (elementWithFocus != null)
                        {
                            elementWithFocus.MoveFocus(request);
                        }
                    }
                }
            }
        }

        //moving the text box forward on frame 10
        private void TextBox_KeyUp2(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Tab && e.Key != Key.Back)
            {
                //a MoveFocus request that places focus back on the first text box
                FocusNavigationDirection focusDirection = FocusNavigationDirection.Right;

                TraversalRequest request = new TraversalRequest(focusDirection);

                UIElement elementWithFocus = Keyboard.FocusedElement as UIElement;

                if (elementWithFocus != null)
                {
                    elementWithFocus.MoveFocus(request);
                }
            }
        }
    }
}
