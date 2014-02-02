using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Controls.Primitives;

namespace AvalonDock
{
    public class DocumentNavigatorWindow : Window, INotifyPropertyChanged
    {
        static DocumentNavigatorWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DocumentNavigatorWindow), new FrameworkPropertyMetadata(typeof(DocumentNavigatorWindow)));


            Window.AllowsTransparencyProperty.OverrideMetadata(typeof(DocumentNavigatorWindow), new FrameworkPropertyMetadata(true));
            Window.WindowStyleProperty.OverrideMetadata(typeof(DocumentNavigatorWindow), new FrameworkPropertyMetadata(WindowStyle.None));
            Window.ShowInTaskbarProperty.OverrideMetadata(typeof(DocumentNavigatorWindow), new FrameworkPropertyMetadata(false));
            Control.BackgroundProperty.OverrideMetadata(typeof(DocumentNavigatorWindow), new FrameworkPropertyMetadata(Brushes.Transparent));
        }

        public DocumentNavigatorWindow()
        {
        }

        void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Tab)
                Hide();
            else
            {
                e.Handled = true;
                MoveNextSelectedContent();
            }
        }

        void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Tab)
                Hide();
            else
            {
                e.Handled = true;
            }
        }

        DockingManager _manager;
        public DocumentNavigatorWindow(DockingManager manager)
            :this()
        {
            _manager = manager;
            Keyboard.AddKeyUpHandler(this, new KeyEventHandler(this.OnKeyUp));
            Keyboard.AddKeyDownHandler(this, new KeyEventHandler(this.OnKeyDown));
        }


        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            List<DocumentContent> listOfDocuments = _manager.FindContents<DocumentContent>();
            List<NavigatorWindowDocumentItem> docs = new List<NavigatorWindowDocumentItem>();
            listOfDocuments.ForEach((DocumentContent doc) =>
            {
                docs.Add(new NavigatorWindowDocumentItem(doc));
            });

            //docs.Sort((NavigatorWindowDocumentItem item1, NavigatorWindowDocumentItem item2) =>
            //{
            //    if (item1 == item2 ||
            //        item1.LastActivation == item2.LastActivation)
            //        return 0;
            //    return (item1.LastActivation < item2.LastActivation) ? 1 : -1;
            //});

            Documents = docs;

            _internalSelect = true;

            SelectedContent = Documents.Find((NavigatorWindowDocumentItem docItem) =>
            {
                return docItem.ItemContent == _manager.ActiveDocument;
            });

            _internalSelect = false;
        }

        protected override void OnDeactivated(EventArgs e)
        {
            if (_manager != null)
            {
                Window mainWindow = Window.GetWindow(_manager);
                if (mainWindow != null)
                {
                    mainWindow.Activate();
                    if (SelectedContent != null)
                    {
                        _manager.Show(SelectedContent.ItemContent as DocumentContent);
                        SelectedContent.ItemContent.SetAsActive();
                    }
                }
            }

            Hide();

            base.OnDeactivated(e);
        }

        ListBox _itemsControl;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _itemsControl = GetTemplateChild("PART_ScrollingPanel") as ListBox;
        }

        List<NavigatorWindowDocumentItem> _documents = new List<NavigatorWindowDocumentItem>();

        public List<NavigatorWindowDocumentItem> Documents
        {
            get { return _documents; }
            private
            set
            {
                _documents = value;
                NotifyPropertyChanged("Documents");
            }
        }

        NavigatorWindowDocumentItem _selectedContent;

        bool _internalSelect = false;

        public NavigatorWindowDocumentItem SelectedContent
        {
            get
            {
                return _selectedContent;
            }
            set
            {
                if (_selectedContent != value)
                {
                    _selectedContent = value;
                    NotifyPropertyChanged("SelectedContent");

                    if (!_internalSelect && _selectedContent != null)
                        Hide();
                    
                    if (_internalSelect && _itemsControl != null)
                        _itemsControl.ScrollIntoView(_selectedContent);
                }
            }
        }


        public void MoveNextSelectedContent()
        {
            if (_selectedContent == null)
                return;

            if (Documents.Contains(SelectedContent))
            {
                int indexOfSelecteContent = Documents.IndexOf(_selectedContent);

                if (indexOfSelecteContent == Documents.Count - 1)
                {
                    indexOfSelecteContent = 0;
                }
                else
                    indexOfSelecteContent++;
                
                _internalSelect = true;
                SelectedContent = Documents[indexOfSelecteContent];
                _internalSelect = false;
            }
        }

        

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

}
