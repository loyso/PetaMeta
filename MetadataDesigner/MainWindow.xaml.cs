using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using System.IO;
using System.Reflection;

using metadata;

using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace MetadataDesigner
{
    public partial class MainWindow : Window
    {
		public metadata.MetadataProject Project = null;
		public tree.Tree				ProjectTree = new tree.Tree( false, null, null );
		readonly string					FileDialogFilter;

        public MainWindow()
        {
			FileDialogFilter = "Metadata Project files (*" + Project.ProjectExtension() + ")|*" + Project.ProjectExtension() + "|All files (*.*)|*.*";
            InitializeComponent();

            this.CommandBindings.Add(new CommandBinding(ApplicationCommands.New, New_Executed));
            this.CommandBindings.Add(new CommandBinding(ApplicationCommands.Open, Open_Executed));
            this.CommandBindings.Add(new CommandBinding(ApplicationCommands.Save, Save_Executed));
            this.CommandBindings.Add(new CommandBinding(ApplicationCommands.SaveAs, SaveAs_Executed));
        }

		private void New_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
			dialog.Filter = FileDialogFilter;
			if ( !dialog.ShowDialog(this) ?? false )
				return;

			Project = Project.ProjectCreate( dialog.FileName );
			Project.NewGuids();
			Project.NewNames();

			ProjectExplorerInit();

			Project.Save();
		}

		private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
			dialog.Filter = FileDialogFilter;
			if ( dialog.ShowDialog(this) ?? false )
			{
				WindowsLayoutRestore();

				Project = Project.ProjectLoad( dialog.FileName );
				Project.Load();
				ProjectExplorerInit();
			}
		}

		private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			if ( Project != null )
				Project.Save();
		}

		private void SaveAs_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			if ( Project == null )
				return;

			Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
			dialog.Filter = FileDialogFilter;
			if ( dialog.ShowDialog(this) ?? false )
				Project.SaveAs( dialog.FileName );
		}

		private void ProjectExplorerInit()
		{
			ProjectTree.CreateTreeView( Project, Project.ProjectName );
			ProjectExplorer.Content = ProjectTree.TreeView;
		}

		private void WindowsLayoutRestore()
		{
            string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\PetaMetaDesigner.Layout.xml";
            if (!File.Exists(path))
                return;

			FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            DockingManager.RestoreLayout(fs);
            fs.Close();
		}

		private void WindowsLayoutStore()
		{
            string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\PetaMetaDesigner.Layout.xml";
            DockingManager.SaveLayout(path);
		}


		private void PetaMainWindow_Loaded(object sender, RoutedEventArgs e)
		{
		}

		private void PetaMainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			WindowsLayoutStore();
		}
    }
}
