using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Input;

using AvalonDock;

namespace MetadataDesigner
{
	class ObjectWindow : DocumentContent
	{
		public core.DataObject This;

        public ObjectWindow()
        {
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }


        private void OnCanClose(object sender, CanExecuteRoutedEventArgs e)
        {
            //e.Handled = true;
            //e.CanExecute = false;
        }

        public static readonly RoutedCommand ViewCommand = new RoutedCommand();
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
	}
}
